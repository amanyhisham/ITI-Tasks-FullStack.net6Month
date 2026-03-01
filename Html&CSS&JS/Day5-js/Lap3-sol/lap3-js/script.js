// //1.1. Array Object 
// let n=prompt("Enter a number");
// let num=Number(n);
// if(isNaN(num)){
//     alert("Please enter a valid number");
//       n=prompt("Enter a number");
//      num=Number(n);
// }
// let arr=new Array(num);
// for(let i=0;i<arr.length;i++){
//     let value=prompt("Enter a value for index "+i);
//     let numValue=Number(value);
//     if(isNaN(numValue)){
//         alert("Please enter a valid number");
//             value=prompt("Enter a value for index "+i);
//             numValue=Number(value)
//         i--; 
//      }
//     arr[i]=numValue;
//  }
//  //assending order
//  arr.sort(function(a,b){return a-b});
//  console.log("Assending order: "+arr);

//  //Desending order
//  arr.sort(function(a,b){return b-a});
//  console.log("Desending order: "+arr);
/////////////////////////////////////////////////////////////////////////////////////
// //1.2.1 Object Object 
// let street=prompt("Enter your street name");
// let buildingnumber=prompt("Enter your building number");
// let city=prompt("Enter your city name"); 
// let obj={
//     street:street,
//     buildingnumber:buildingnumber,
//     city:city,

// }
// function  showAdd(obj){
//     return obj.buildingnumber+" "+obj.street+","+obj.city +" city registered in 15/10/2024";
// }
// console.log(showAdd(obj));
//////////////////////////////////////////////////////////////////////////////////////
// //1.2.2 Object Object 
// let nm1=prompt("Enter your name");
// let age1=parseInt(prompt("Enter your age"));
// let obj={
//     nm:nm1,
//     age:age1,
// }
// let str=prompt("Enter a string");
// function showInfo(obj,str){
//     if(str=="nm"){
//         console.log(obj.nm);
//     }
//     else if(str=="age"){
//         console.log(obj.age+" years old");
//     }
//     else{
//          console.log("Invalid input");
//     }
// }
// showInfo(obj, str);
//////////////////////////////////////////////////////////////////////////////////////
//2.1.1 window Object
let child;
let posx=0;
let posy=0;
let direction=1;
function startFlying(){
child = window.open("","_blank","width=100,height=100,top=0,left=0");
setInterval(function(){
    posy =posy+10*direction;
    if(posy<=0||posy>=window.screen.height-100)
        {direction =-direction;}
     child.moveTo(posx, posy);
    },10);
}
function stopFlying(){
    window.close();
}
