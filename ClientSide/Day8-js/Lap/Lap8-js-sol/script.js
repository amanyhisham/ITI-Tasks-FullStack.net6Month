/*
  Utility functions for cookies and validation.
  Part A: BOM & Cookies
  Part B: Built-in Objects & Error Object
*/

// Retrieve cookie value by name
function getCookie(cookieName) {
  if (arguments.length === 0) {
    throw new Error('cookieName is required');
  }
  if (typeof cookieName !== 'string') {
    throw new Error('cookieName must be a string');
  }

  const cookies = document.cookie ? document.cookie.split('; ') : [];

  for (const pair of cookies) {
    const [name, ...valueParts] = pair.split('=');
    if (name === cookieName) {
      return decodeURIComponent(valueParts.join('='));
    }
  }

  return null;
}

// Set cookie with optional expiry date
function setCookie(cookieName, cookieValue, expiryDate) {
  if (arguments.length < 2) {
    throw new Error('cookieName and cookieValue are required');
  }
  if (typeof cookieName !== 'string') {
    throw new Error('cookieName must be a string');
  }
  if (typeof cookieValue !== 'string') {
    throw new Error('cookieValue must be a string');
  }

  let cookieString = `${cookieName}=${encodeURIComponent(cookieValue)};path=/`;

  if (expiryDate !== undefined && expiryDate !== null) {
    if (!(expiryDate instanceof Date) || Number.isNaN(expiryDate.getTime())) {
      throw new Error('expiryDate must be a valid Date object');
    }
    cookieString += `;expires=${expiryDate.toUTCString()}`;
  }

  document.cookie = cookieString;
}

// Delete cookie by name
function deleteCookie(cookieName) {
  if (arguments.length === 0) {
    throw new Error('cookieName is required');
  }
  if (typeof cookieName !== 'string') {
    throw new Error('cookieName must be a string');
  }

  document.cookie = `${cookieName}=;path=/;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
}

// Return all stored cookies as a key/value object
function allCookieList() {
  const cookies = document.cookie ? document.cookie.split('; ') : [];
  const result = {};

  for (const pair of cookies) {
    const [name, ...valueParts] = pair.split('=');
    result[name] = decodeURIComponent(valueParts.join('='));
  }

  return result;
}

// Check if a cookie exists
function hasCookie(cookieName) {
  if (arguments.length === 0) {
    throw new Error('cookieName is required');
  }
  if (typeof cookieName !== 'string') {
    throw new Error('cookieName must be a string');
  }

  return getCookie(cookieName) !== null;
}

/*
  Part B: Built-in Objects & Error Object
*/

function acceptTwoParameters(firstParam, secondParam) {
  if (arguments.length !== 2) {
    throw new Error('This function accepts exactly 2 parameters');
  }
  return [firstParam, secondParam];
}

function addNumbers(...values) {
  if (values.length === 0) {
    throw new Error('At least one number parameter is required');
  }

  let total = 0;

  for (const value of values) {
    if (typeof value !== 'number' || Number.isNaN(value)) {
      throw new Error('All parameters must be valid numbers');
    }
    total += value;
  }

  return total;
}

// Example usage for developer inspection (commented out)
// console.log(acceptTwoParameters(1, 2));
// console.log(addNumbers(1, 2, 3, 4));
