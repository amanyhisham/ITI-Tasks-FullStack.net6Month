 

// ── CONFIG ────────────────────────────────────────
const CONFIG = {
  apiKey: "fw_CA8HK5pKmVAv8TuGxbKJp",
  baseUrl: "https://api.fireworks.ai/inference/v1",
  chatModel: "accounts/fireworks/models/gpt-oss-120b",
  imgModel:  "accounts/fireworks/models/flux-1-schnell-fp8",
  editModel: "accounts/fireworks/models/flux-kontext-pro",
  maxTokens: 16384,
  temperature: 0.6,
};

// ── STATE ─────────────────────────────────────────
let state = {
  chats: {},         // { id: { id, title, mode, messages } }
  activeChatId: null,
  isLoading: false,
  uploadedImageBase64: null,
  uploadedImageType: null,
};

// ── DOM REFS ──────────────────────────────────────
const chatArea    = document.getElementById("chatArea");
const chatList    = document.getElementById("chatList");
const promptInput = document.getElementById("promptInput");
const sendBtn     = document.getElementById("sendBtn");
const modeSelect  = document.getElementById("modeSelect");
const uploadRow   = document.getElementById("uploadRow");
const uploadLabel = document.getElementById("uploadLabel");
const imageFile   = document.getElementById("imageFile");
const previewWrap = document.getElementById("previewWrap");
const previewImg  = document.getElementById("previewImg");
const topbarTitle = document.getElementById("topbarTitle");
const sidebar     = document.getElementById("sidebar");
const overlay     = document.getElementById("overlay");

// ── INIT ──────────────────────────────────────────
document.addEventListener("DOMContentLoaded", () => {
  loadFromStorage();

  if (Object.keys(state.chats).length === 0) {
    createNewChat();
  } else {
    const saved = localStorage.getItem("activeChatId");
    switchChat(saved && state.chats[saved] ? saved : Object.keys(state.chats).at(-1));
  }

  renderSidebar();
  bindEvents();
});

// ── PERSISTENCE ───────────────────────────────────
function saveToStorage() {
  try {
    localStorage.setItem("chats", JSON.stringify(state.chats));
    localStorage.setItem("activeChatId", state.activeChatId || "");
  } catch (e) {
    console.warn("Storage save failed:", e);
  }
}

function loadFromStorage() {
  try {
    const raw = localStorage.getItem("chats");
    if (raw) state.chats = JSON.parse(raw);
  } catch (e) {
    state.chats = {};
  }
}

// ── CHAT MANAGEMENT ───────────────────────────────
function createNewChat() {
  const id    = "chat_" + Date.now();
  const mode  = modeSelect ? modeSelect.value : "chat";
  state.chats[id] = {
    id,
    title: "New Chat",
    mode,
    messages: [],
  };
  state.activeChatId = id;
  saveToStorage();
  renderSidebar();
  renderChatArea();
  if (modeSelect) modeSelect.value = mode;
  handleModeChange();
}

function switchChat(id) {
  if (!state.chats[id]) return;
  state.activeChatId = id;
  const chat = state.chats[id];
  if (modeSelect) modeSelect.value = chat.mode;
  saveToStorage();
  renderSidebar();
  renderChatArea();
  handleModeChange();
  closeSidebar();
}

function getActiveChat() {
  return state.chats[state.activeChatId] || null;
}

// ── SIDEBAR ───────────────────────────────────────
function renderSidebar() {
  chatList.innerHTML = "";
  const ids = Object.keys(state.chats).reverse();

  if (ids.length === 0) {
    chatList.innerHTML = `<p style="padding:12px;font-size:13px;color:var(--text-dim);text-align:center">No chats yet</p>`;
    return;
  }

  ids.forEach(id => {
    const chat = state.chats[id];
    const btn  = document.createElement("button");
    btn.className = "chat-item" + (id === state.activeChatId ? " active" : "");
    btn.textContent = chat.title;
    btn.title = chat.title;
    btn.addEventListener("click", () => switchChat(id));
    chatList.appendChild(btn);
  });
}

// ── CHAT AREA RENDER ──────────────────────────────
function renderChatArea() {
  const chat = getActiveChat();
  if (!chat) return;

  topbarTitle.textContent = chat.title;

  if (chat.messages.length === 0) {
    chatArea.innerHTML = `
      <div class="empty-state">
        <div class="empty-icon">
          <svg width="22" height="22" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8"><path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"/></svg>
        </div>
        <h3>AmanyHeshamAI</h3>
        <p>${getModeHint(chat.mode)}</p>
      </div>`;
    return;
  }

  chatArea.innerHTML = `<div class="chat-inner" id="chatInner"></div>`;
  const inner = document.getElementById("chatInner");

  chat.messages.forEach(msg => {
    inner.appendChild(buildMessageEl(msg));
  });

  scrollToBottom();
}

function getModeHint(mode) {
  if (mode === "image") return "Describe an image and I'll generate it for you";
  if (mode === "edit")  return "Upload an image and tell me what to edit";
  return "Ask me anything — I'm here to help";
}

// ── MESSAGE ELEMENT ───────────────────────────────
function buildMessageEl(msg) {
  const row = document.createElement("div");
  row.className = "msg-row " + (msg.role === "user" ? "user" : "ai");

  const avatarEl = document.createElement("div");
  avatarEl.className = "avatar " + (msg.role === "user" ? "avatar-user" : "avatar-ai");
  avatarEl.textContent = msg.role === "user" ? "U" : "AI";

  const bubble = document.createElement("div");
  bubble.className = "bubble " + (msg.role === "user" ? "bubble-user" : "bubble-ai");

  if (msg.type === "image" && msg.content) {
    const img = document.createElement("img");
    img.className = "chat-img";
    img.src = msg.content;
    img.alt = msg.prompt || "Generated image";
    img.loading = "lazy";
    img.onerror = () => {
      img.replaceWith(errorNote("Image failed to load"));
    };

    bubble.appendChild(img);

    if (msg.prompt) {
      const cap = document.createElement("p");
      cap.className = "img-caption";
      cap.textContent = "📝 " + msg.prompt;
      bubble.appendChild(cap);
    }
  } else {
    bubble.innerHTML = formatText(msg.content || "");
  }

  row.appendChild(avatarEl);
  row.appendChild(bubble);
  return row;
}

function appendMessage(msg) {
  let inner = document.getElementById("chatInner");
  if (!inner) {
    chatArea.innerHTML = `<div class="chat-inner" id="chatInner"></div>`;
    inner = document.getElementById("chatInner");
  }

  // Remove empty state if present
  const emptyState = chatArea.querySelector(".empty-state");
  if (emptyState) {
    chatArea.innerHTML = `<div class="chat-inner" id="chatInner"></div>`;
    inner = document.getElementById("chatInner");
  }

  inner.appendChild(buildMessageEl(msg));
  scrollToBottom();
}

// ── TYPING INDICATOR ──────────────────────────────
function showTyping() {
  let inner = document.getElementById("chatInner");
  if (!inner) {
    chatArea.innerHTML = `<div class="chat-inner" id="chatInner"></div>`;
    inner = document.getElementById("chatInner");
  }

  const row = document.createElement("div");
  row.className = "msg-row ai";
  row.id = "typingRow";

  const av = document.createElement("div");
  av.className = "avatar avatar-ai";
  av.textContent = "AI";

  const bubble = document.createElement("div");
  bubble.className = "bubble bubble-ai";
  bubble.innerHTML = `<div class="typing-indicator"><div class="dot"></div><div class="dot"></div><div class="dot"></div></div>`;

  row.appendChild(av);
  row.appendChild(bubble);
  inner.appendChild(row);
  scrollToBottom();
}

function hideTyping() {
  const el = document.getElementById("typingRow");
  if (el) el.remove();
}

// ── SEND HANDLER ──────────────────────────────────
async function handleSend() {
  if (state.isLoading) return;

  const text = promptInput.value.trim();
  if (!text) return;

  const chat = getActiveChat();
  if (!chat) return;

  // Lock mode
  chat.mode = modeSelect.value;

  // Validate image edit mode
  if (chat.mode === "edit" && !state.uploadedImageBase64) {
    alert("Please upload an image for editing.");
    return;
  }

  const userMsg = {
    role: "user",
    type: "text",
    content: text,
    timestamp: Date.now(),
  };

  chat.messages.push(userMsg);
  promptInput.value = "";
  autoResizeTextarea();

  // Auto-title from first user message
  if (chat.messages.filter(m => m.role === "user").length === 1) {
    chat.title = text.length > 30 ? text.slice(0, 30) + "…" : text;
    topbarTitle.textContent = chat.title;
    renderSidebar();
  }

  appendMessage(userMsg);
  setLoading(true);
  showTyping();

  try {
    let aiMsg;

    if (chat.mode === "image") {
      aiMsg = await generateImage(text);
    } else if (chat.mode === "edit") {
      aiMsg = await editImage(text, state.uploadedImageBase64, state.uploadedImageType);
      removeUpload();
    } else {
      const replyText = await sendChat(buildApiMessages(chat.messages));
      aiMsg = { role: "assistant", type: "text", content: replyText, timestamp: Date.now() };
    }

    chat.messages.push(aiMsg);
  } catch (err) {
    const errMsg = {
      role: "assistant",
      type: "text",
      content: "⚠️ " + (err.message || "Something went wrong. Please try again."),
      timestamp: Date.now(),
    };
    chat.messages.push(errMsg);
  }

  hideTyping();
  saveToStorage();
  const lastMsg = chat.messages.at(-1);
  if (lastMsg) appendMessage(lastMsg);
  setLoading(false);
}

// ── API: TEXT CHAT ────────────────────────────────
async function sendChat(apiMessages) {
  const res = await fetch(`${CONFIG.baseUrl}/chat/completions`, {
    method: "POST",
    headers: {
      "Accept": "application/json",
      "Content-Type": "application/json",
      "Authorization": `Bearer ${CONFIG.apiKey}`,
    },
    body: JSON.stringify({
      model: CONFIG.chatModel,
      max_tokens: CONFIG.maxTokens,
      top_p: 1,
      top_k: 40,
      presence_penalty: 0,
      frequency_penalty: 0,
      temperature: CONFIG.temperature,
      messages: apiMessages,
    }),
  });

  if (!res.ok) {
    const err = await res.json().catch(() => ({}));
    throw new Error(err.error?.message || `API error ${res.status}`);
  }

  const data = await res.json();
  const text = data.choices?.[0]?.message?.content;
  if (!text) throw new Error("Empty response from API");
  return text.trim();
}

// ── API: IMAGE GENERATION ─────────────────────────
async function generateImage(prompt) {
  const res = await fetch(`${CONFIG.baseUrl}/workflows/${CONFIG.imgModel}/text_to_image`, {
    method: "POST",
    headers: {
      "Accept": "image/jpeg",
      "Content-Type": "application/json",
      "Authorization": `Bearer ${CONFIG.apiKey}`,
    },
    body: JSON.stringify({
      prompt,
      width: 1024,
      height: 768,
    }),
  });

  if (!res.ok) {
    const err = await res.json().catch(() => ({}));
    throw new Error(err.error?.message || `Image API error ${res.status}`);
  }

  // Response is binary image — convert to object URL
  const blob = await res.blob();
  const url  = URL.createObjectURL(blob);

  return {
    role: "assistant",
    type: "image",
    content: url,
    prompt: prompt,
    timestamp: Date.now(),
  };
}

// ── API: IMAGE EDIT ───────────────────────────────
async function editImage(prompt, imageBase64, imageType) {
  const formData = new FormData();

  // Convert base64 → Blob
  const byteString = atob(imageBase64);
  const arr = new Uint8Array(byteString.length);
  for (let i = 0; i < byteString.length; i++) {
    arr[i] = byteString.charCodeAt(i);
  }
  const blob = new Blob([arr], { type: imageType || "image/png" });

  formData.append("prompt", prompt);
  formData.append("image",  blob, "image.png");

  const res = await fetch(`${CONFIG.baseUrl}/workflows/${CONFIG.editModel}`, {
    method: "POST",
    headers: {
      "Accept": "image/jpeg",
      "Authorization": `Bearer ${CONFIG.apiKey}`,
    },
    body: formData,
  });

  if (!res.ok) {
    const err = await res.json().catch(() => ({}));
    throw new Error(err.error?.message || `Edit API error ${res.status}`);
  }

  const outBlob = await res.blob();
  const url     = URL.createObjectURL(outBlob);

  return {
    role: "assistant",
    type: "image",
    content: url,
    prompt: "Edited: " + prompt,
    timestamp: Date.now(),
  };
}

// ── HELPERS ───────────────────────────────────────
function buildApiMessages(messages) {
  return messages
    .filter(m => m.role === "user" || m.role === "assistant")
    .filter(m => m.type === "text")
    .map(m => ({
      role: m.role === "user" ? "user" : "assistant",
      content: m.content,
    }));
}

function formatText(raw) {
  if (!raw) return "";
  return escapeHtml(raw)
    .replace(/\*\*(.*?)\*\*/g, "<strong>$1</strong>")
    .replace(/\*(.*?)\*/g, "<em>$1</em>")
    .replace(/`([^`]+)`/g, "<code>$1</code>")
    .replace(/\n/g, "<br>");
}

function escapeHtml(str) {
  return String(str)
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;")
    .replace(/"/g, "&quot;");
}

function errorNote(msg) {
  const p = document.createElement("p");
  p.style.color = "#e24b4a";
  p.style.fontSize = "13px";
  p.textContent = "❌ " + msg;
  return p;
}

function scrollToBottom() {
  requestAnimationFrame(() => {
    chatArea.scrollTop = chatArea.scrollHeight;
  });
}

function setLoading(val) {
  state.isLoading = val;
  sendBtn.disabled = val;
  promptInput.disabled = val;
}

function autoResizeTextarea() {
  promptInput.style.height = "auto";
  promptInput.style.height = Math.min(promptInput.scrollHeight, 180) + "px";
}

// ── IMAGE UPLOAD ──────────────────────────────────
function handleImageUpload(e) {
  const file = e.target.files?.[0];
  if (!file) return;

  const allowed = ["image/jpeg", "image/png", "image/webp", "image/gif"];
  if (!allowed.includes(file.type)) {
    alert("Please upload a valid image (JPEG, PNG, WEBP, GIF).");
    return;
  }

  const reader = new FileReader();
  reader.onload = (ev) => {
    const result    = ev.target.result;
    const [, b64]   = result.split(",");
    state.uploadedImageBase64 = b64;
    state.uploadedImageType   = file.type;
    previewImg.src  = result;
    previewWrap.style.display = "block";
    uploadLabel.querySelector("span").textContent = "Change Image";
  };
  reader.readAsDataURL(file);
}

function removeUpload() {
  state.uploadedImageBase64 = null;
  state.uploadedImageType   = null;
  imageFile.value           = "";
  previewImg.src            = "";
  previewWrap.style.display = "none";
  uploadLabel.querySelector("span").textContent = "Upload Image";
}

// ── MODE CHANGE ───────────────────────────────────
function handleModeChange() {
  const mode = modeSelect.value;
  uploadRow.style.display = (mode === "edit") ? "flex" : "none";

  const chat = getActiveChat();
  if (chat) {
    chat.mode = mode;
    saveToStorage();
  }
}

// ── MOBILE SIDEBAR ────────────────────────────────
function toggleSidebar() {
  sidebar.classList.toggle("open");
  overlay.classList.toggle("show");
}

function closeSidebar() {
  sidebar.classList.remove("open");
  overlay.classList.remove("show");
}

// ── EVENT BINDINGS ────────────────────────────────
function bindEvents() {
  document.getElementById("btnNewChat").addEventListener("click", createNewChat);

  sendBtn.addEventListener("click", handleSend);

  promptInput.addEventListener("keydown", (e) => {
    if (e.key === "Enter" && !e.shiftKey) {
      e.preventDefault();
      handleSend();
    }
  });

  promptInput.addEventListener("input", autoResizeTextarea);

  modeSelect.addEventListener("change", handleModeChange);

  imageFile.addEventListener("change", handleImageUpload);
}