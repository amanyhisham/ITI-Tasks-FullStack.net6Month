const { capitalizeTextFirstChar, createArray, random } = require('../lab1');

// ===================== LAB 1 =====================

describe("capitalizeTextFirstChar", function () {

  it("should return a string when given a string", function () {
    const result = capitalizeTextFirstChar("hello world");
    expect(typeof result).toBe("string");
  });

  it("should capitalize the first char of every word", function () {
    const result = capitalizeTextFirstChar("i'm ahmed ali");
    expect(result).toBe("I'm Ahmed Ali");
  });

  it("should throw TypeError when given a number", function () {
    expect(() => capitalizeTextFirstChar(12)).toThrowError(TypeError);
  });

});

// -------------------------------------------------

describe("createArray", function () {

  it("should return an array", function () {
    expect(Array.isArray(createArray(3))).toBe(true);
  });

  it("should return array of length 2 that includes 1 when passed 2", function () {
    const result = createArray(2);
    expect(result.length).toBe(2);
    expect(result).toContain(1);
  });

  it("should return array of length 3 that does NOT include 3 when passed 3", function () {
    const result = createArray(3);
    expect(result.length).toBe(3);
    expect(result).not.toContain(3);
  });

});

// -------------------------------------------------

describe("random", function () {

  it("should return a number", function () {
    expect(typeof random(1, 10)).toBe("number");
  });

  it("should return a number between 5 and 7 inclusive when passed (5, 7)", function () {
    const result = random(5, 7);
    expect(result).toBeGreaterThanOrEqual(5);
    expect(result).toBeLessThanOrEqual(7);
  });

  it("should return NaN when given only one parameter", function () {
    expect(random(5)).toBeNaN();
  });

});
