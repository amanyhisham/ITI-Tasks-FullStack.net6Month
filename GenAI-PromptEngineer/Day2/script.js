// Day2
// implement QuickSort algorithm in JavaScript
function validateNumberArray(arr, functionName) {
    if (arr == null) {
        throw new TypeError(`${functionName} expects a non-null array.`);
    }
    if (!Array.isArray(arr)) {
        throw new TypeError(`${functionName} expects an array.`);
    }
    for (const item of arr) {
        if (typeof item !== 'number' || !Number.isFinite(item)) {
            throw new TypeError(`${functionName} expects an array of finite numbers.`);
        }
    }
}

function quickSort(arr) {
    validateNumberArray(arr, 'quickSort');

    if (arr.length <= 1) {
        return [...arr];
    }

    const pivot = arr[Math.floor(arr.length / 2)];
    const left = [];
    const right = [];
    const equal = [];

    for (let element of arr) {
        if (element < pivot) {
            left.push(element);
        } else if (element > pivot) {
            right.push(element);
        } else {
            equal.push(element);
        }
    }

    return [...quickSort(left), ...equal, ...quickSort(right)];
}

function partition(array, low, high) {
    const pivot = array[Math.floor((low + high) / 2)];
    let left = low;
    let right = high;

    while (left <= right) {
        while (array[left] < pivot) {
            left += 1;
        }
        while (array[right] > pivot) {
            right -= 1;
        }
        if (left <= right) {
            [array[left], array[right]] = [array[right], array[left]];
            left += 1;
            right -= 1;
        }
    }

    return left;
}

function quickSortIterative(arr) {
    validateNumberArray(arr, 'quickSortIterative');
    const array = [...arr];
    if (array.length <= 1) {
        return array;
    }

    const stack = [[0, array.length - 1]];

    while (stack.length) {
        const [low, high] = stack.pop();
        if (low >= high) {
            continue;
        }

        const pivotIndex = partition(array, low, high);

        if (pivotIndex - 1 > low) {
            stack.push([low, pivotIndex - 1]);
        }
        if (pivotIndex < high) {
            stack.push([pivotIndex, high]);
        }
    }

    return array;
}

function mergeSort(arr) {
    validateNumberArray(arr, 'mergeSort');

    if (arr.length <= 1) {
        return [...arr];
    }

    const mid = Math.floor(arr.length / 2);
    const left = mergeSort(arr.slice(0, mid));
    const right = mergeSort(arr.slice(mid));

    return merge(left, right);
}

function merge(left, right) {
    const result = [];
    let i = 0, j = 0;

    while (i < left.length && j < right.length) {
        if (left[i] < right[j]) {
            result.push(left[i++]);
        } else {
            result.push(right[j++]);
        }
    }

    return result.concat(left.slice(i)).concat(right.slice(j));
}

function bubbleSort(arr) {
    validateNumberArray(arr, 'bubbleSort');
    const array = [...arr];

    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array.length - 1 - i; j++) {
            if (array[j] > array[j + 1]) {
                [array[j], array[j + 1]] = [array[j + 1], array[j]];
            }
        }
    }

    return array;
}

function formatError(message) {
    const errorField = document.getElementById('error-message');
    errorField.textContent = message;
}

function sortInput() {
    const inputField = document.getElementById('number-input');
    const outputField = document.getElementById('sorted-output');
    const algorithmSelect = document.getElementById('algorithm-select');
    const raw = inputField.value.trim();

    outputField.textContent = '';
    formatError('');

    if (!raw) {
        formatError('Please enter one or more numbers separated by commas.');
        return;
    }

    const values = raw.split(',').map((item) => item.trim()).filter(Boolean);
    const numbers = [];

    for (const value of values) {
        const number = Number(value);
        if (!Number.isFinite(number)) {
            formatError(`Invalid value: "${value}". Use only numbers separated by commas.`);
            return;
        }
        numbers.push(number);
    }

    const algorithm = algorithmSelect.value;
    let sorted;
    try {
        if (algorithm === 'quickSort') {
            sorted = quickSort(numbers);
        } else if (algorithm === 'mergeSort') {
            sorted = mergeSort(numbers);
        } else if (algorithm === 'bubbleSort') {
            sorted = bubbleSort(numbers);
        } else {
            formatError('Unknown algorithm selected.');
            return;
        }
    } catch (error) {
        formatError(error.message);
        return;
    }

    outputField.textContent = sorted.join(', ');
}

if (typeof window !== 'undefined' && typeof document !== 'undefined') {
    window.addEventListener('DOMContentLoaded', () => {
        document.getElementById('sort-button').addEventListener('click', sortInput);
        document.getElementById('number-input').addEventListener('keypress', (event) => {
            if (event.key === 'Enter') {
                event.preventDefault();
                sortInput();
            }
        });
    });
}

if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = { quickSort, quickSortIterative, mergeSort, bubbleSort };

    // Benchmarking function
    function benchmarkSorts() {
        const sizes = [1000, 10000, 100000];

        console.log('Benchmarking QuickSort vs Array.sort()\n');

        for (const size of sizes) {
            console.log(`Array size: ${size}`);

            // Generate random array
            const arr = Array.from({ length: size }, () => Math.random() * 1000000);

            // Benchmark QuickSort
            const arrCopy1 = [...arr];
            const start1 = performance.now();
            quickSort(arrCopy1);
            const time1 = performance.now() - start1;

            // Benchmark Array.sort()
            const arrCopy2 = [...arr];
            const start2 = performance.now();
            arrCopy2.sort((a, b) => a - b);
            const time2 = performance.now() - start2;

            console.log(`  QuickSort: ${time1.toFixed(2)} ms`);
            console.log(`  Array.sort(): ${time2.toFixed(2)} ms`);
            console.log(`  Ratio (QuickSort / Array.sort()): ${(time1 / time2).toFixed(2)}\n`);
        }
    }

    // Run benchmark if this script is executed directly
    if (require.main === module) {
        benchmarkSorts();
    }
}
