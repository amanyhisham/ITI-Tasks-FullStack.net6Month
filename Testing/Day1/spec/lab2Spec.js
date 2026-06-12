const User = require('../lab2');

// ===================== LAB 2 =====================

describe("User - addToCart", function () {

  it("should add a product to the cart", function () {
    const user = new User("Amany", "1234");
    user.addToCart({ name: "Laptop", price: 1000 });
    expect(user.cart.length).toBe(1);
    expect(user.cart[0].name).toBe("Laptop");
  });

  it("should add multiple products to the cart", function () {
    const user = new User("Amany", "1234");
    user.addToCart({ name: "Phone", price: 500 });
    user.addToCart({ name: "Tablet", price: 300 });
    expect(user.cart.length).toBe(2);
  });

});

// -------------------------------------------------

describe("User - calculateTotalCartPrice", function () {

  it("should return 0 when cart is empty", function () {
    const user = new User("Amany", "1234");
    expect(user.calculateTotalCartPrice()).toBe(0);
  });

  it("should return the correct total price of all cart items", function () {
    const user = new User("Amany", "1234");
    user.addToCart({ name: "Phone", price: 500 });
    user.addToCart({ name: "Case", price: 50 });
    expect(user.calculateTotalCartPrice()).toBe(550);
  });

});

// -------------------------------------------------

describe("User - checkout", function () {

  it("should call all paymentModel methods", function () {
    const user = new User("Amany", "1234");
    const paymentModel = {
      goToVerifyPage: jasmine.createSpy("goToVerifyPage"),
      returnBack: jasmine.createSpy("returnBack"),
      isVerify: jasmine.createSpy("isVerify").and.returnValue(true),
    };
    user.checkout(paymentModel);
    expect(paymentModel.goToVerifyPage).toHaveBeenCalled();
    expect(paymentModel.returnBack).toHaveBeenCalled();
    expect(paymentModel.isVerify).toHaveBeenCalled();
  });

  it("should return true when payment is verified", function () {
    const user = new User("Amany", "1234");
    const paymentModel = {
      goToVerifyPage: jasmine.createSpy("goToVerifyPage"),
      returnBack: jasmine.createSpy("returnBack"),
      isVerify: jasmine.createSpy("isVerify").and.returnValue(true),
    };
    expect(user.checkout(paymentModel)).toBe(true);
  });

  it("should return false when payment is NOT verified", function () {
    const user = new User("Amany", "1234");
    const paymentModel = {
      goToVerifyPage: jasmine.createSpy("goToVerifyPage"),
      returnBack: jasmine.createSpy("returnBack"),
      isVerify: jasmine.createSpy("isVerify").and.returnValue(false),
    };
    expect(user.checkout(paymentModel)).toBe(false);
  });

});
