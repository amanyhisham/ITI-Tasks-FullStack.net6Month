//parant class
class Shape{
constructor(){};
area(){};
perimeter() {};
}

//Rectangle
class Rectangle extends Shape{
constructor(width,length){
    super();
    this.length=length;
    this.width=width;
}
area(){
    return this.length*this.width;
}
perimeter(){
    return 2 * (this.length + this.width);
}
toString(){
    return`Rectangle => Area: ${this.area()}, Perimeter: ${this.perimeter()}`
}
}
//Square
class Square extends Shape{
constructor(length){
    super();
    this.length=length;
}
area(){
    return this.length*this.length;
}
perimeter(){
    return 4 * (this.length );
}
toString(){
    return`Square => Area: ${this.area()}, Perimeter: ${this.perimeter()}`
}
}
//cicrle
class Circle extends Shape {
  constructor(radius) {
    super();
    this.radius = radius;
  }

  area() {
    return Math.PI * this.radius * this.radius;
  }

  perimeter() {
    return 2 * Math.PI * this.radius;
  }

  toString() {
    return `Circle → Area: ${this.area()}, Perimeter: ${this.perimeter()}`;
  }
}
export{Rectangle,Square,Circle};