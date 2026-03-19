 import {Rectangle,Square,Circle} from './shapes.js' 
//1) Swap the values of two variables using destructuring 
var [x,y]=[3,5]; 
console.log("Before swape :x =",x ," and y = ",y);
var[x,y]=[y,x];//
console.log("After swape :x =",x ," and y = ",y);
console.log("==========================================================");
//2)shapes
var myrect=new Rectangle(5,3);
console.log(myrect.toString());
console.log("=========================================================");
var mysquare=new Square(5);
console.log(mysquare.toString());
console.log("=========================================================");
var mycircle=new Circle(3);
console.log(mycircle.toString());


