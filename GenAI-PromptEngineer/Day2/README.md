# Sorting Algorithms Implementation in JavaScript

This project implements multiple sorting algorithms in JavaScript (QuickSort, MergeSort, BubbleSort), including both recursive and iterative versions, with comprehensive testing, a web-based UI for demonstration, visualization, and a REST API.

## How GitHub Copilot Helped

GitHub Copilot assisted in various stages of this project:

1. **Initial Implementation**: Copilot suggested the basic recursive QuickSort structure, including pivot selection (middle element), partitioning into left/right/equal arrays, and recursive calls.

2. **Iterative Version**: When asked for an iterative alternative, Copilot provided the in-place partitioning logic and stack-based approach to avoid recursion.

3. **Additional Algorithms**: Copilot implemented MergeSort and BubbleSort with proper validation and error handling.

4. **Bug Fixes**: Copilot identified the missing return statement in `quickSortIterative` and helped add input validation to prevent runtime errors.

5. **Testing**: Copilot generated comprehensive Jest test cases covering edge cases like empty arrays, single elements, sorted/reverse sorted arrays, duplicates, and large random arrays for all algorithms.

6. **Web UI**: Copilot created the HTML structure, CSS styling, and JavaScript event handlers for the browser-based demo, including input parsing, algorithm selection, and error display.

7. **Visualization**: Copilot set up the canvas-based animation for BubbleSort with step-by-step visualization and color highlights.

8. **API**: Copilot built the Express REST API with POST endpoint for sorting arrays.

9. **Benchmarking**: Copilot added the performance comparison function using `performance.now()` and structured the output for clear results.

10. **Documentation**: Copilot helped outline and write this README, ensuring all sections were covered with accurate technical details.

## Algorithm Explanation

### Recursive QuickSort

The recursive `quickSort` function works as follows:

1. **Base Case**: If the array has 0 or 1 elements, return a copy of it (no sorting needed).

2. **Pivot Selection**: Choose the middle element as the pivot.

3. **Partitioning**: Create three arrays:
   - `left`: elements less than pivot
   - `right`: elements greater than pivot
   - `equal`: elements equal to pivot

4. **Recursion**: Recursively sort `left` and `right`, then concatenate: `[...sortedLeft, ...equal, ...sortedRight]`

### Iterative QuickSort

The iterative version uses a stack to simulate recursion:

1. **Setup**: Copy the input array and initialize a stack with the full range `[0, length-1]`.

2. **Partitioning Loop**: While the stack is not empty:
   - Pop the current range `[low, high]`
   - If `low >= high`, skip (already sorted)
   - Partition the array in-place around a pivot
   - Push sub-ranges back onto the stack

3. **Return**: The modified array is now sorted.

### MergeSort

MergeSort is a divide-and-conquer algorithm:

1. **Divide**: Split the array into two halves until each subarray has 1 element.

2. **Conquer**: Recursively sort each half.

3. **Merge**: Combine the sorted halves by merging them in order.

The `merge` function takes two sorted arrays and produces a single sorted array by comparing elements from each.

### BubbleSort

BubbleSort is a simple comparison-based algorithm:

1. **Outer Loop**: Iterate through the array `n` times.

2. **Inner Loop**: For each pass, compare adjacent elements and swap if out of order.

3. **Optimization**: Each pass places the largest element at the end, so reduce the range each time.

This algorithm is O(n²) in worst case but simple to implement and visualize.

### Key Components

- **Pivot**: The element used to divide the array. Here, we use the middle element for simplicity.
- **Partitioning**: Separating elements into those less than, equal to, and greater than the pivot.
- **Recursion/Iteration**: Breaking down the problem into smaller subproblems.

## Complexity Analysis

| Algorithm             | Best Case  | Average Case | Worst Case   | Space Complexity         |
| --------------------- | ---------- | ------------ | ------------ | ------------------------ |
| QuickSort (Recursive) | O(n log n) | O(n log n)   | O(n²)        | O(log n) recursion stack |
| QuickSort (Iterative) | O(n log n) | O(n log n)   | O(n²)        | O(log n) stack space     |
| MergeSort             | O(n log n) | O(n log n)   | O(n log n)   | O(n)                     |
| BubbleSort            | O(n)       | O(n²)        | O(n²)        | O(1)                     |
| HeapSort              | O(n log n) | O(n log n)   | O(n log n)   | O(1)                     |
| Array.sort()          | O(n log n) | O(n log n)   | O(n log n)\* | O(1) to O(n)\*           |

\* JavaScript's `Array.sort()` uses different algorithms depending on the engine (e.g., Timsort in V8), typically stable O(n log n).

QuickSort's worst case occurs with already-sorted or reverse-sorted arrays when using a poor pivot (like always first/last element). Our implementation uses the middle element, which helps but doesn't guarantee balance.

## Performance Benchmark Results

Benchmark results comparing our recursive QuickSort with JavaScript's built-in `Array.sort()` on random arrays:

```
Array size: 1000
  QuickSort: 3.40 ms
  Array.sort(): 0.35 ms
  Ratio (QuickSort / Array.sort()): 9.77

Array size: 10000
  QuickSort: 13.23 ms
  Array.sort(): 3.69 ms
  Ratio (QuickSort / Array.sort()): 3.58

Array size: 100000
  QuickSort: 77.41 ms
  Array.sort(): 51.00 ms
  Ratio (QuickSort / Array.sort()): 1.52
```

Our QuickSort implementation is slower than the optimized built-in sort, especially for smaller arrays. This is expected as `Array.sort()` uses highly optimized, engine-specific algorithms. For larger arrays, the gap narrows as QuickSort's O(n log n) nature becomes more apparent.

## Key Learnings

1. **Algorithm Implementation**: Understanding pivot selection, partitioning, and the trade-offs between recursive and iterative approaches.

2. **Error Handling**: Importance of input validation to prevent runtime errors and provide clear error messages.

3. **Testing**: Comprehensive unit tests are crucial for catching bugs and ensuring correctness across edge cases.

4. **Performance**: Built-in functions are often highly optimized; custom implementations should be benchmarked against them.

5. **Web Development**: Integrating algorithms with UI requires careful separation of concerns (validation, sorting, display).

6. **Documentation**: Clear READMEs help others understand and contribute to the project.

7. **AI Assistance**: GitHub Copilot can accelerate development by suggesting code patterns, but human oversight is needed for correctness and optimization.

## Usage

### Node.js

```javascript
const { quickSort, quickSortIterative } = require("./script");

const arr = [3, 1, 4, 1, 5];
console.log(quickSort(arr)); // [1, 1, 3, 4, 5]
console.log(mergeSort(arr)); // [1, 1, 3, 4, 5]
console.log(bubbleSort(arr)); // [1, 1, 3, 4, 5]
```

### Browser

Open `index.html` in a web browser and enter comma-separated numbers to sort them. Choose an algorithm from the dropdown.

### Visualization

Open `visualize.html` in a web browser to see an animated BubbleSort visualization with color highlights.

### API

Start the server with `npm start`, then POST to `/sort`:

```bash
curl -X POST http://localhost:3000/sort -H "Content-Type: application/json" -d '{"array": [3, 1, 4, 1, 5]}'
```

Response: `{"sorted": [1, 1, 3, 4, 5]}`

### Testing

```bash
npm test
```

### Benchmarking

```bash
node script.js
```

## Files

- `script.js`: Sorting algorithm implementations (QuickSort, MergeSort, BubbleSort) and benchmarking
- `quicksort.test.js`: Jest unit tests for all algorithms
- `index.html`: Web UI for sorting with algorithm selection
- `style.css`: UI styling
- `visualize.html`: Canvas-based BubbleSort animation
- `api.js`: Express REST API for sorting
- `package.json`: Dependencies and scripts
- `README.md`: This documentation
