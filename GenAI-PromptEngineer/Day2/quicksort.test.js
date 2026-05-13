const { quickSort, quickSortIterative, mergeSort, bubbleSort } = require('./script');

const commonTests = (sortFn) => {
    it('should return an empty array when given an empty array', () => {
        expect(sortFn([])).toEqual([]);
    });

    it('should return the same array when given a single element', () => {
        expect(sortFn([5])).toEqual([5]);
    });

    it('should sort an already sorted array', () => {
        const input = [1, 2, 3, 4, 5];
        expect(sortFn(input)).toEqual([1, 2, 3, 4, 5]);
    });

    it('should sort a reverse sorted array', () => {
        const input = [5, 4, 3, 2, 1];
        expect(sortFn(input)).toEqual([1, 2, 3, 4, 5]);
    });

    it('should sort an array with duplicates', () => {
        const input = [3, 1, 2, 3, 1];
        expect(sortFn(input)).toEqual([1, 1, 2, 3, 3]);
    });

    it('should sort a large random array', () => {
        const input = Array.from({ length: 100 }, () => Math.floor(Math.random() * 1000));
        const expected = [...input].sort((a, b) => a - b);
        expect(sortFn(input)).toEqual(expected);
    });
};

describe('quickSort', () => {
    commonTests(quickSort);
});

describe('quickSortIterative', () => {
    commonTests(quickSortIterative);
});

describe('mergeSort', () => {
    commonTests(mergeSort);
});

describe('bubbleSort', () => {
    commonTests(bubbleSort);
});

describe('error handling', () => {
    it('should throw for null input in quickSort', () => {
        expect(() => quickSort(null)).toThrow(TypeError);
    });

    it('should throw for non-array input in quickSort', () => {
        expect(() => quickSort('1,2,3')).toThrow(TypeError);
    });

    it('should throw for non-numeric values in quickSort', () => {
        expect(() => quickSort([1, 'a', 3])).toThrow(TypeError);
    });

    it('should throw for null input in quickSortIterative', () => {
        expect(() => quickSortIterative(null)).toThrow(TypeError);
    });

    it('should throw for non-array input in quickSortIterative', () => {
        expect(() => quickSortIterative({})).toThrow(TypeError);
    });

    it('should throw for non-numeric values in quickSortIterative', () => {
        expect(() => quickSortIterative([1, undefined, 3])).toThrow(TypeError);
    });
});