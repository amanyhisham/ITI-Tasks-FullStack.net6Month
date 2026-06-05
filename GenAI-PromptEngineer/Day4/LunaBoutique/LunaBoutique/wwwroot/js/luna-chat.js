let chatHistory = [];
let notificationShown = true;
document.addEventListener('DOMContentLoaded', function () {
    // إظهار notification بعد 3 ثواني
    setTimeout(() => {
        const notification = document.getElementById('chatNotification');
        if (notification) {
            notification.style.display = 'block';
            setTimeout(() => { notification.style.display = 'none'; }, 5000);
        }
    }, 3000);
});

// فتح/إغلاق الشات
function toggleChat() {
    const chatWindow = document.getElementById('chatWindow');
    const chatIcon = document.getElementById('chatIcon');
    const notification = document.getElementById('chatNotification');

    chatWindow.classList.toggle('open');
    notification.style.display = 'none';

    if (chatWindow.classList.contains('open')) {
        chatIcon.className = 'fas fa-times';
        document.getElementById('chatInput').focus();
    } else {
        chatIcon.className = 'fas fa-comment-dots';
    }
}

function dismissNotification() {
    document.getElementById('chatNotification').style.display = 'none';
}

// إرسال رسالة
async function sendMessage() {
    const input = document.getElementById('chatInput');
    const message = input.value.trim();
    if (!message) return;

    input.value = '';
    document.getElementById('quickReplies').style.display = 'none';

    // رسالة المستخدم
    addMessage(message, 'user');

    // Typing indicator
    showTyping();

    try {
        const response = await fetch('/Chat/Send', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                message: message,
                history: chatHistory
            })
        });

        const data = await response.json();
        removeTyping();

        if (data.success) {
            addMessage(data.message, 'ai');
            chatHistory.push({ role: 'user', content: message });
            chatHistory.push({ role: 'assistant', content: data.message });
        } else {
            addMessage('عذراً، حدث خطأ. حاولي مرة أخرى! 💕', 'ai');
        }
    } catch (error) {
        removeTyping();
        addMessage('عذراً، تأكدي من الاتصال بالإنترنت 💕', 'ai');
    }
}

// Quick Reply
function sendQuick(message) {
    document.getElementById('chatInput').value = message;
    document.getElementById('quickReplies').style.display = 'none';
    sendMessage();
}
function formatMessage(text) {
    return text
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/[•\-\*]\s*(.+)/g, '<div class="chat-point">• $1</div>')
        .replace(/\n\n/g, '<div class="chat-spacer"></div>')
        .replace(/\n/g, '<br>');
}

// إضافة رسالة
function addMessage(text, sender) {
    const messages = document.getElementById('chatMessages');
    const time = new Date().toLocaleTimeString('ar-EG', {
        hour: '2-digit', minute: '2-digit'
    });

    const div = document.createElement('div');
    div.className = `message ${sender === 'ai' ? 'ai-message' : 'user-message'}`;
    div.innerHTML = `
    <div class="message-bubble">${formatMessage(text)}</div>
    <div class="message-time">${time}</div>
`;

    messages.appendChild(div);
    messages.scrollTop = messages.scrollHeight;
}

// Typing animation
function showTyping() {
    const messages = document.getElementById('chatMessages');
    const div = document.createElement('div');
    div.className = 'message ai-message typing-indicator';
    div.id = 'typingIndicator';
    div.innerHTML = `
        <div class="message-bubble">
            <div class="typing-dots">
                <span></span><span></span><span></span>
            </div>
        </div>
        <div class="message-time">نوار تكتب...</div>
    `;
    messages.appendChild(div);
    messages.scrollTop = messages.scrollHeight;
}

function removeTyping() {
    const typing = document.getElementById('typingIndicator');
    if (typing) typing.remove();
}

// إظهار الـ notification بعد 3 ثواني
setTimeout(() => {
    const notification = document.getElementById('chatNotification');
    if (notification) {
        notification.style.display = 'block';
        setTimeout(() => {
            notification.style.display = 'none';
        }, 5000);
    }
}, 3000);