
      function validateArray(arr) {
        if (!Array.isArray(arr))
          throw new Error("Input must be an array of numbers.");
        arr.forEach((value, index) => {
          if (typeof value !== "number" || !isFinite(value)) {
            throw new Error(`Invalid number at position ${index + 1}.`);
          }
        });
      }
      function quickSortRecursive(arr) {
        validateArray(arr);
        if (arr.length <= 1) return [...arr];
        const pivot = arr[Math.floor(arr.length / 2)];
        const left = [],
          equal = [],
          right = [];
        for (const item of arr) {
          if (item < pivot) left.push(item);
          else if (item > pivot) right.push(item);
          else equal.push(item);
        }
        return [
          ...quickSortRecursive(left),
          ...equal,
          ...quickSortRecursive(right),
        ];
      }
      function quickSortIterative(arr) {
        validateArray(arr);
        const array = [...arr];
        if (array.length <= 1) return array;
        const stack = [[0, array.length - 1]];
        while (stack.length) {
          const [low, high] = stack.pop();
          if (low >= high) continue;
          const pivot = array[Math.floor((low + high) / 2)];
          let left = low;
          let right = high;
          while (left <= right) {
            while (array[left] < pivot) left++;
            while (array[right] > pivot) right--;
            if (left <= right) {
              [array[left], array[right]] = [array[right], array[left]];
              left++;
              right--;
            }
          }
          if (low < right) stack.push([low, right]);
          if (left < high) stack.push([left, high]);
        }
        return array;
      }
      function mergeSort(arr) {
        validateArray(arr);
        if (arr.length <= 1) return [...arr];
        const mid = Math.floor(arr.length / 2);
        const left = mergeSort(arr.slice(0, mid));
        const right = mergeSort(arr.slice(mid));
        const output = [];
        let i = 0,
          j = 0;
        while (i < left.length && j < right.length) {
          if (left[i] < right[j]) output.push(left[i++]);
          else output.push(right[j++]);
        }
        return output.concat(left.slice(i), right.slice(j));
      }
      function heapSort(arr) {
        validateArray(arr);
        const array = [...arr];
        function heapify(n, i) {
          let largest = i;
          const left = 2 * i + 1;
          const right = 2 * i + 2;
          if (left < n && array[left] > array[largest]) largest = left;
          if (right < n && array[right] > array[largest]) largest = right;
          if (largest !== i) {
            [array[i], array[largest]] = [array[largest], array[i]];
            heapify(n, largest);
          }
        }
        for (let i = Math.floor(array.length / 2) - 1; i >= 0; i--)
          heapify(array.length, i);
        for (let i = array.length - 1; i > 0; i--) {
          [array[0], array[i]] = [array[i], array[0]];
          heapify(i, 0);
        }
        return array;
      }
      function bubbleSort(arr) {
        validateArray(arr);
        const array = [...arr];
        for (let i = 0; i < array.length; i++) {
          for (let j = 0; j < array.length - i - 1; j++) {
            if (array[j] > array[j + 1])
              [array[j], array[j + 1]] = [array[j + 1], array[j]];
          }
        }
        return array;
      }
      function insertionSort(arr) {
        validateArray(arr);
        const array = [...arr];
        for (let i = 1; i < array.length; i++) {
          const key = array[i];
          let j = i - 1;
          while (j >= 0 && array[j] > key) {
            array[j + 1] = array[j];
            j--;
          }
          array[j + 1] = key;
        }
        return array;
      }
      function selectionSort(arr) {
        validateArray(arr);
        const array = [...arr];
        for (let i = 0; i < array.length - 1; i++) {
          let min = i;
          for (let j = i + 1; j < array.length; j++) {
            if (array[j] < array[min]) min = j;
          }
          [array[i], array[min]] = [array[min], array[i]];
        }
        return array;
      }
      function arraySort(arr) {
        validateArray(arr);
        return [...arr].sort((a, b) => a - b);
      }

      const algorithms = {
        quickSortRecursive,
        quickSortIterative,
        mergeSort,
        heapSort,
        bubbleSort,
        insertionSort,
        selectionSort,
        arraySort,
      };
      const algorithmCategories = {
        quickSortRecursive: { label: "QuickSort", color: "#7c3aed" },
        quickSortIterative: { label: "QuickSort", color: "#7c3aed" },
        mergeSort: { label: "MergeSort", color: "#22d3ee" },
        heapSort: { label: "HeapSort", color: "#f59e0b" },
        bubbleSort: { label: "BubbleSort", color: "#f97316" },
        insertionSort: { label: "InsertionSort", color: "#f97316" },
        selectionSort: { label: "SelectionSort", color: "#f97316" },
        arraySort: { label: "Built-in", color: "#34d399" },
      };
      const complexities = {
        quickSortRecursive: {
          best: "O(n log n)",
          avg: "O(n log n)",
          worst: "O(n²)",
          space: "O(log n)",
        },
        quickSortIterative: {
          best: "O(n log n)",
          avg: "O(n log n)",
          worst: "O(n²)",
          space: "O(log n)",
        },
        mergeSort: {
          best: "O(n log n)",
          avg: "O(n log n)",
          worst: "O(n log n)",
          space: "O(n)",
        },
        heapSort: {
          best: "O(n log n)",
          avg: "O(n log n)",
          worst: "O(n log n)",
          space: "O(1)",
        },
        bubbleSort: {
          best: "O(n)",
          avg: "O(n²)",
          worst: "O(n²)",
          space: "O(1)",
        },
        insertionSort: {
          best: "O(n)",
          avg: "O(n²)",
          worst: "O(n²)",
          space: "O(1)",
        },
        selectionSort: {
          best: "O(n²)",
          avg: "O(n²)",
          worst: "O(n²)",
          space: "O(1)",
        },
        arraySort: {
          best: "O(n log n)",
          avg: "O(n log n)",
          worst: "O(n log n)",
          space: "O(1)–O(n)",
        },
      };

      const inputArray = document.getElementById("input-array");
      const algorithmSelect = document.getElementById("algorithm-select");
      const sizeSelect = document.getElementById("size-select");
      const sortBtn = document.getElementById("sort-btn");
      const compareBtn = document.getElementById("compare-btn");
      const testBtn = document.getElementById("test-btn");
      const randomBtn = document.getElementById("random-btn");
      const copyBtn = document.getElementById("copy-btn");
      const clearBtn = document.getElementById("clear-btn");
      const benchmarkBtn = document.getElementById("benchmark-btn");
      const apiSendBtn = document.getElementById("api-send-btn");
      const apiInput = document.getElementById("api-input");
      const apiResponse = document.getElementById("api-response");
      const sortResults = document.getElementById("sort-results");
      const errorMessage = document.getElementById("error-message");
      const arrayCanvas = document.getElementById("array-canvas");
      const animationCanvas = document.getElementById("animation-canvas");
      const playBtn = document.getElementById("play-btn");
      const pauseBtn = document.getElementById("pause-btn");
      const resetBtn = document.getElementById("reset-btn");
      const stepBtn = document.getElementById("step-btn");
      const speedSlider = document.getElementById("speed-slider");
      const benchmarkTable = document.getElementById("benchmark-table");
      const testResults = document.getElementById("test-results");
      const complexityCard = document.getElementById("complexity-info");
      const badgeElement = document.getElementById("algorithm-category-badge");
      const stepCounter = document.getElementById("step-counter");
      const actionText = document.getElementById("action-text");
      const toastContainer = document.getElementById("toast-container");
      const themeToggle = document.getElementById("theme-toggle");

      let currentArray = [];
      let sortedArray = [];
      let animationSteps = [];
      let animationIndex = 0;
      let animationSpeed = 55;
      let stepMode = false;
      let isPlaying = false;
      let chartFrame = null;
      let chartStart = null;

      function showToast(message, type = "success") {
        const toast = document.createElement("div");
        toast.className = `toast ${type}`;
        toast.innerHTML = `<span class="icon">${type === "success" ? "✅" : type === "error" ? "❌" : type === "warning" ? "⚡" : type === "info" ? "📋" : "🎉"}</span><div>${message}</div>`;
        toastContainer.prepend(toast);
        setTimeout(() => {
          toast.style.animation = "toastOut 0.35s ease forwards";
          setTimeout(() => toast.remove(), 350);
        }, 3200);
      }

      function applyRipple(event) {
        const button = event.currentTarget;
        const circle = document.createElement("span");
        const diameter = Math.max(button.clientWidth, button.clientHeight);
        const radius = diameter / 2;
        circle.style.width = circle.style.height = `${diameter}px`;
        circle.style.left = `${event.clientX - button.offsetLeft - radius}px`;
        circle.style.top = `${event.clientY - button.offsetTop - radius}px`;
        circle.style.position = "absolute";
        circle.style.background = "rgba(255,255,255,0.28)";
        circle.style.borderRadius = "50%";
        circle.style.pointerEvents = "none";
        circle.style.transform = "scale(0)";
        circle.style.animation = "ripple 0.6s ease";
        button.appendChild(circle);
        setTimeout(() => circle.remove(), 600);
      }

      document
        .querySelectorAll("button")
        .forEach((button) => button.addEventListener("click", applyRipple));

      function setTheme(selected) {
        document.body.classList.toggle("light-theme", selected === "light");
        themeToggle.textContent = selected === "dark" ? "🌙" : "☀️";
        localStorage.setItem("sortingLabTheme", selected);
      }

      function initializeTheme() {
        const stored = localStorage.getItem("sortingLabTheme");
        const theme = stored === "light" ? "light" : "dark";
        setTheme(theme);
      }

      themeToggle.addEventListener("click", () => {
        const active = document.body.classList.contains("light-theme")
          ? "dark"
          : "light";
        setTheme(active);
      });

      function animateComplexity() {
        complexityCard.classList.add("animating");
        setTimeout(() => complexityCard.classList.remove("animating"), 360);
      }

      function updateComplexity() {
        const algo = algorithmSelect.value;
        const comp = complexities[algo];
        const category = algorithmCategories[algo];
        document.getElementById("best-case").textContent = comp.best;
        document.getElementById("avg-case").textContent = comp.avg;
        document.getElementById("worst-case").textContent = comp.worst;
        document.getElementById("space-case").textContent = comp.space;
        complexityCard.style.borderColor = category.color;
        badgeElement.textContent = category.label;
        badgeElement.style.color = category.color;
        animateComplexity();
      }

      algorithmSelect.addEventListener("change", updateComplexity);
      updateComplexity();
      initializeTheme();

      function parseInput() {
        const text = inputArray.value.trim();
        if (!text) return [];
        const values = text
          .split(",")
          .map((v) => v.trim())
          .filter(Boolean);
        const numbers = values.map(Number);
        numbers.forEach((value, index) => {
          if (!isFinite(value))
            throw new Error(`Invalid value at position ${index + 1}`);
        });
        return numbers;
      }

      function renderSortResults(time) {
        sortResults.innerHTML = `
                <div><strong>Original:</strong> [${currentArray.join(", ")}]</div>
                <div><strong>Sorted:</strong> [${sortedArray.join(", ")}]</div>
                <div><strong>Algorithm:</strong> ${algorithmSelect.options[algorithmSelect.selectedIndex].text}</div>
                <div><strong>Time:</strong> ${time.toFixed(2)} ms</div>
                <div><strong>Size:</strong> ${currentArray.length}</div>
            `;
      }

      function initializeCanvas() {
        const scale = window.devicePixelRatio || 1;
        arrayCanvas.width = arrayCanvas.clientWidth * scale;
        arrayCanvas.height = 300 * scale;
        animationCanvas.width = animationCanvas.clientWidth * scale;
        animationCanvas.height = 350 * scale;
        const arrayCtx = arrayCanvas.getContext("2d");
        const animationCtx = animationCanvas.getContext("2d");
        arrayCtx.setTransform(scale, 0, 0, scale, 0, 0);
        animationCtx.setTransform(scale, 0, 0, scale, 0, 0);
      }

      function drawArrayVisualization(progress = 1) {
        const ctx = arrayCanvas.getContext("2d");
        const width = arrayCanvas.width / (window.devicePixelRatio || 1);
        const height = arrayCanvas.height / (window.devicePixelRatio || 1);
        ctx.clearRect(0, 0, width, height);
        if (!currentArray.length) {
          ctx.fillStyle = "rgba(148,163,184,0.88)";
          ctx.font = "18px Inter";
          ctx.fillText(
            "Enter numbers and run sort to see the chart.",
            28,
            height / 2,
          );
          return;
        }
        const original = currentArray;
        const sorted = sortedArray.length
          ? sortedArray
          : [...currentArray].sort((a, b) => a - b);
        const all = [...original, ...sorted];
        const maxAbs = Math.max(...all.map(Math.abs), 1);
        const paddingX = 56;
        const paddingY = 56;
        const availableHeight = height - paddingY * 2;
        const sectionWidth = (width - paddingX * 2) / 2;
        const barCount = Math.max(original.length, sorted.length);
        const gap = Math.max(6, sectionWidth / barCount / 4);
        const barWidth = Math.max(
          8,
          (sectionWidth - gap * barCount) / barCount,
        );
        const baseline = paddingY + availableHeight / 2;
        ctx.strokeStyle = "rgba(148,163,184,0.18)";
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(paddingX, baseline);
        ctx.lineTo(width - paddingX, baseline);
        ctx.stroke();
        ctx.font = "14px Inter";
        ctx.fillStyle = "rgba(148,163,184,0.88)";
        ctx.fillText("Original", paddingX + 4, height - 18);
        ctx.fillText("Sorted", paddingX + sectionWidth + 20, height - 18);
        for (let i = 0; i <= 4; i++) {
          const y = paddingY + (availableHeight / 4) * i;
          ctx.beginPath();
          ctx.moveTo(paddingX, y);
          ctx.lineTo(width - paddingX, y);
          ctx.stroke();
        }
        const gradient = ctx.createLinearGradient(0, 0, 0, height);
        gradient.addColorStop(0, "#6366f1");
        gradient.addColorStop(1, "#22d3ee");
        const drawBars = (list, offset) => {
          list.forEach((value, index) => {
            const x = paddingX + offset + index * (barWidth + gap);
            const targetHeight =
              (Math.abs(value) / maxAbs) * (availableHeight / 2);
            const actualHeight = Math.max(4, targetHeight * progress);
            const y = value >= 0 ? baseline - actualHeight : baseline;
            ctx.fillStyle = value < 0 ? "#ef4444" : gradient;
            ctx.fillRect(x, y, barWidth, actualHeight);
            if (list.length <= 20) {
              ctx.fillStyle = "#f8fafc";
              ctx.font = "12px Inter";
              ctx.fillText(
                value,
                x,
                value >= 0 ? y - 10 : baseline + actualHeight + 14,
              );
            }
          });
        };
        drawBars(original, 0);
        drawBars(sorted, sectionWidth + 20);
      }

      function animateArrayChart(timestamp) {
        if (!chartStart) chartStart = timestamp;
        const elapsed = Math.min(1, (timestamp - chartStart) / 500);
        drawArrayVisualization(elapsed);
        if (elapsed < 1) chartFrame = requestAnimationFrame(animateArrayChart);
        else chartFrame = null;
      }

      function updateArrayVisualization() {
        if (chartFrame) cancelAnimationFrame(chartFrame);
        chartStart = null;
        chartFrame = requestAnimationFrame(animateArrayChart);
      }

      function recordStep(step) {
        animationSteps.push(JSON.parse(JSON.stringify(step)));
      }

      function generateAnimationSteps(arr) {
        animationSteps = [];
        if (arr.length > 120) return;
        const array = [...arr];
        function partition(low, high) {
          const pivotValue = array[high];
          let i = low - 1;
          for (let j = low; j < high; j++) {
            recordStep({
              array: [...array],
              highlight: [j, high],
              pivot: high,
              type: "compare",
              action: `Comparing index ${j} and pivot`,
            });
            if (array[j] < pivotValue) {
              i++;
              [array[i], array[j]] = [array[j], array[i]];
              recordStep({
                array: [...array],
                highlight: [i, j],
                pivot: high,
                type: "swap",
                action: `Swapped index ${i} and ${j}`,
              });
            }
          }
          [array[i + 1], array[high]] = [array[high], array[i + 1]];
          recordStep({
            array: [...array],
            highlight: [i + 1, high],
            pivot: i + 1,
            type: "swap",
            action: `Placed pivot at ${i + 1}`,
          });
          return i + 1;
        }
        function quickSort(low, high) {
          if (low < high) {
            const pivotIndex = partition(low, high);
            quickSort(low, pivotIndex - 1);
            quickSort(pivotIndex + 1, high);
          }
        }
        quickSort(0, array.length - 1);
        animationIndex = 0;
        if (animationSteps.length) {
          stepCounter.textContent = `Step 1 / ${animationSteps.length}`;
          actionText.textContent = animationSteps[0].action;
        }
      }

      function drawAnimationStep(step) {
        const ctx = animationCanvas.getContext("2d");
        const width = animationCanvas.width / (window.devicePixelRatio || 1);
        const height = animationCanvas.height / (window.devicePixelRatio || 1);
        ctx.clearRect(0, 0, width, height);
        if (!step) return;
        const array = step.array;
        const maxAbs = Math.max(...array.map(Math.abs), 1);
        const barWidth = Math.max(18, width / array.length / 1.7);
        const gap = Math.max(
          6,
          (width - array.length * barWidth) / (array.length + 1),
        );
        const baseline = height * 0.56;
        array.forEach((value, index) => {
          const x = gap + index * (barWidth + gap);
          const barHeight = Math.max(
            4,
            (Math.abs(value) / maxAbs) * (height * 0.34),
          );
          const y = value >= 0 ? baseline - barHeight : baseline;
          let color = "#22d3ee";
          if (step.pivot === index) color = "#ef4444";
          else if (step.highlight?.includes(index))
            color = step.type === "compare" ? "#f59e0b" : "#6366f1";
          if (step.type === "sorted") color = "#10b981";
          ctx.fillStyle = value < 0 ? "#ef4444" : color;
          ctx.beginPath();
          ctx.roundRect(x, y, barWidth, barHeight, 12);
          ctx.fill();
        });
        actionText.textContent = step.action;
        stepCounter.textContent = `Step ${Math.min(animationIndex + 1, animationSteps.length)} / ${animationSteps.length}`;
      }

      function playAnimation() {
        if (!animationSteps.length) {
          showToast(
            "⚠️ No animation steps available. Run QuickSort first.",
            "warning",
          );
          return;
        }
        if (stepMode) {
          if (animationIndex < animationSteps.length) {
            drawAnimationStep(animationSteps[animationIndex]);
            animationIndex += 1;
          }
          return;
        }
        if (animationIndex >= animationSteps.length) animationIndex = 0;
        isPlaying = true;
        function tick() {
          if (!isPlaying || animationIndex >= animationSteps.length) {
            isPlaying = false;
            if (animationIndex >= animationSteps.length)
              showToast("✅ Sorting animation complete!", "success");
            return;
          }
          drawAnimationStep(animationSteps[animationIndex]);
          animationIndex += 1;
          setTimeout(tick, Math.max(18, 180 - animationSpeed));
        }
        tick();
      }

      playBtn.addEventListener("click", () => {
        try {
          currentArray = parseInput();
        } catch (error) {
          showToast(error.message, "error");
          return;
        }
        const algo = algorithmSelect.value;
        if (!["quickSortRecursive", "quickSortIterative"].includes(algo)) {
          showToast(
            "⚠️ Sorting animation only supports QuickSort variants.",
            "warning",
          );
          return;
        }
        generateAnimationSteps(currentArray);
        playAnimation();
      });
      pauseBtn.addEventListener("click", () => {
        isPlaying = false;
      });
      resetBtn.addEventListener("click", () => {
        isPlaying = false;
        animationIndex = 0;
        if (animationSteps.length) drawAnimationStep(animationSteps[0]);
        stepCounter.textContent = animationSteps.length
          ? `Step 1 / ${animationSteps.length}`
          : "Step 0 / 0";
        actionText.textContent = "Animation reset";
      });
      stepBtn.addEventListener("click", () => {
        stepMode = !stepMode;
        stepBtn.textContent = stepMode ? "Step Mode ON" : "Step Mode";
        showToast(stepMode ? "🧩 Step mode on" : "▶️ Step mode off", "info");
      });
      speedSlider.addEventListener("input", () => {
        animationSpeed = Number(speedSlider.value);
      });

      function processInput() {
        currentArray = parseInput();
        sortedArray = [];
        updateArrayVisualization();
        animationSteps = [];
        animationIndex = 0;
        stepCounter.textContent = "Step 0 / 0";
        actionText.textContent = "Awaiting animation.";
      }

      function runSort() {
        try {
          processInput();
          const selected = algorithmSelect.value;
          const start = performance.now();
          sortedArray = algorithms[selected](currentArray);
          const duration = performance.now() - start;
          renderSortResults(duration);
          updateArrayVisualization();
          showToast("✅ Sorted successfully!", "success");
          errorMessage.style.display = "none";
        } catch (error) {
          errorMessage.textContent = error.message;
          errorMessage.style.display = "block";
          showToast(error.message, "error");
        }
      }

      sortBtn.addEventListener("click", runSort);

      compareBtn.addEventListener("click", () => {
        try {
          processInput();
          const reference = [...currentArray].sort((a, b) => a - b);
          const results = Object.entries(algorithms).map(([key, fn]) => {
            const start = performance.now();
            const output = fn(currentArray);
            const elapsed = performance.now() - start;
            const correct =
              JSON.stringify(output) === JSON.stringify(reference);
            return {
              name: key.replace(/([A-Z])/g, " $1").trim(),
              time: elapsed.toFixed(2),
              correct,
            };
          });
          sortResults.innerHTML = `<div><strong>Algorithm comparison</strong></div>${results.map((r) => `<div style="margin-top:10px;color:${r.correct ? "#d1fae5" : "#fecaca"}"><strong>${r.name}</strong> — ${r.time} ms ${r.correct ? "✓" : "✗"}</div>`).join("")}`;
          showToast("⚡ Comparison complete.", "info");
        } catch (error) {
          showToast(error.message, "error");
        }
      });

      randomBtn.addEventListener("click", () => {
        const size = Number(sizeSelect.value);
        currentArray = Array.from(
          { length: size },
          () => Math.floor(Math.random() * 200) - 100,
        );
        inputArray.value = currentArray.join(", ");
        processInput();
        showToast("🎲 Random array generated.", "purple");
      });

      copyBtn.addEventListener("click", async () => {
        if (!sortedArray.length) {
          showToast("⚠️ No sorted result to copy.", "warning");
          return;
        }
        await navigator.clipboard.writeText(sortedArray.join(", "));
        showToast("📋 Sorted result copied.", "info");
      });

      clearBtn.addEventListener("click", () => {
        inputArray.value = "";
        currentArray = [];
        sortedArray = [];
        sortResults.textContent =
          'Enter numbers and click "Sort Numbers" to preview sorted output here.';
        updateArrayVisualization();
        animationSteps = [];
        animationIndex = 0;
        errorMessage.style.display = "none";
      });

      benchmarkBtn.addEventListener("click", () => {
        try {
          processInput();
          if (!currentArray.length)
            throw new Error("Enter numbers before benchmarking.");
          const rows = benchmarkTable.querySelectorAll("tbody tr");
          let fastest = Infinity;
          let fastestRow = null;
          rows.forEach((row) => row.classList.remove("fastest"));
          Object.keys(algorithms).forEach((key, index) => {
            const start = performance.now();
            algorithms[key](currentArray);
            const elapsed = performance.now() - start;
            const row = rows[index];
            row.cells[1].textContent = `${elapsed.toFixed(2)} ms`;
            if (elapsed < fastest) {
              fastest = elapsed;
              fastestRow = row;
            }
          });
          if (fastestRow) fastestRow.classList.add("fastest");
          showToast(
            `⚡ Benchmark complete! Fastest: ${fastestRow.cells[0].textContent}`,
            "warning",
          );
        } catch (error) {
          showToast(error.message, "error");
        }
      });

      function runTests() {
        const cases = [
          { name: "Empty", input: [] },
          { name: "Single", input: [5] },
          { name: "Sorted", input: [1, 2, 3, 4, 5] },
          { name: "Reverse", input: [5, 4, 3, 2, 1] },
          { name: "Duplicates", input: [3, 1, 4, 1, 5, 9, 2, 6] },
          { name: "Negative", input: [-3, -1, 0, 2, 5] },
        ];
        const algorithmEntries = Object.entries(algorithms);
        const results = [];
        let passed = 0;
        algorithmEntries.forEach(([name, fn]) => {
          cases.forEach((test) => {
            try {
              const actual = fn(test.input);
              const expected = [...test.input].sort((a, b) => a - b);
              const success =
                JSON.stringify(actual) === JSON.stringify(expected);
              results.push({
                algorithm: name.replace(/([A-Z])/g, " $1").trim(),
                test: test.name,
                success,
                expected,
                actual,
              });
              if (success) passed += 1;
            } catch (err) {
              results.push({
                algorithm: name.replace(/([A-Z])/g, " $1").trim(),
                test: test.name,
                success: false,
                expected: [...test.input].sort((a, b) => a - b),
                actual: null,
                error: err.message,
              });
            }
          });
        });
        testResults.innerHTML = `
                <div class="test-summary">${passed} / ${results.length} checks passed</div>
                <div class="test-list">
                    ${results
                      .map(
                        (result) => `
                        <div class="test-item ${result.success ? "pass" : "fail"}">
                            <div>
                                <div><strong>${result.algorithm} • ${result.test}</strong></div>
                                <div class="test-detail">${result.success ? "Expected and actual match." : `Expected: [${result.expected.join(", ")}] • Actual: [${result.actual?.join(", ")}]${result.error ? " • Error: " + result.error : ""}`}</div>
                            </div>
                            <div class="test-icon">${result.success ? "✓" : "✗"}</div>
                        </div>
                    `,
                      )
                      .join("")}
                </div>
            `;
        showToast(
          `🧪 Tests completed: ${passed}/${results.length}`,
          passed === results.length ? "success" : "error",
        );
      }

      testBtn.addEventListener("click", runTests);

      apiSendBtn.addEventListener("click", () => {
        apiResponse.textContent = "Sending request...";
        setTimeout(() => {
          try {
            const payload = JSON.parse(apiInput.value);
            const algorithm = payload.algorithm || "quickSortRecursive";
            const array = payload.array || [];
            validateArray(array);
            if (!algorithms[algorithm]) throw new Error("Unknown algorithm");
            const start = performance.now();
            const sorted = algorithms[algorithm](array);
            const duration = performance.now() - start;
            apiResponse.textContent = JSON.stringify(
              { algorithm, array: sorted, timeMs: `${duration.toFixed(2)} ms` },
              null,
              2,
            );
            showToast("📡 API simulation complete.", "info");
          } catch (error) {
            apiResponse.textContent = JSON.stringify(
              { error: error.message },
              null,
              2,
            );
            showToast(error.message, "error");
          }
        }, 700);
      });

      window.addEventListener("resize", () => {
        initializeCanvas();
        updateArrayVisualization();
      });

      initializeCanvas();
      drawArrayVisualization();
    