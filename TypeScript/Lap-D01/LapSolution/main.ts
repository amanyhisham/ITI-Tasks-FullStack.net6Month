//////////////////////////////////Question1:->Module////////////////////////////////
import { sub } from './mathfile.js';
console.log(sub(50, 10));
//////////////////////////////////Question1:->Types////////////////////////////////
let userName:string ="amany";
let Age:number=22;
let isstudent:boolean=false;
let grades: number[] = [90, 85, 100];
let randomData: any = "Hello";
randomData = 25;  
randomData = true;
let emptyValue: null = null;
let notFound: undefined = undefined;
console.log(userName , " ",Age ," ",isstudent," ",grades," ",randomData," ",emptyValue," ",notFound);
//////////////////////////////////Question1:->Union////////////////////////////////
let value:number|string;
value="mostafa";
value=23;
console.log(value);
//////////////////////////////////Question1:->Funcation////////////////////////////////
function sum1(num1:number,num2:number):number{
    return num1+num2;
}
console.log("Summation funcation return : ",sum1(5, 10));

function sum2(num1:number,num2:number):void{
    console.log("Summation funcation void : ",num1+num2);
}
sum2(20, 30);
//////////////////////////////////Question1:->Enum////////////////////////////////
enum Days {
  Sat,
  Sun,
  Mon,
  thurs
}
let today:Days=Days.thurs;
console.log("Today : ",today);
//////////////////////////////////Question1:->Generic////////////////////////////////
function getvalue<t>(value:t):t{
    return value;
}
console.log("Generic name",getvalue<String>("amany"));
console.log("Generic Age",getvalue<number>(22));
//////////////////////////////////////////Question1:->Decorator////////////////////////////////
function Logger(constructor: Function) {
  console.log("Class created!");
}
@Logger
class Person {
  name = "Amany";
}
////////////////////////////////////Question2:->Class2D////////////////////////////////
class Point2D{
     x :number;
     y :number;
    constructor(  X :number,Y :number){
        this.x=X;
        this.y=Y;
    }
    getDistance(p:Point2D):number{
        let dx=this.x-p.x;
        let dy=this.y-p.y;
        return Math.sqrt((dx*dx)+(dy*dy));
    }

}
let p1=new Point2D(5,3);
let p2=new Point2D(10,6);
console.log("Class Point2D :",p1.getDistance(p2));
///////////////////////////////////////Question3:->Class3D///////////////////////////////////
class Point3D extends  Point2D{
    z:number;
    constructor( X :number,Y :number,Z:number){
       super(X,Y);//this.x=X & this.y=Y
       this.z=Z;
     }
      getDistance(p:Point3D):number{
        let dx=this.x-p.x;
        let dy=this.y-p.y;
        let dz=this.z-p.z;
        return Math.sqrt((dx*dx)+(dy*dy)+(dz*dz));
    }
}
let p3=new Point3D(3,4,5);
let p4=new Point3D(15,10,12);
console.log("Class Point3D :",p3.getDistance(p4));

