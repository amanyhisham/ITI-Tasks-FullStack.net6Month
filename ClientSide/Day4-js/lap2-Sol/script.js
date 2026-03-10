//Question1-lap2-js
// let str=prompt("Enter a string:");
// let char=prompt("Enter a character You want search about:");
// let difference=prompt("Is search CaseSenstive?");
// let count=0;
// console.log(`The string is: ${str}`);
// if(difference==='yes'||difference==='Yes'||difference==='YES'){
//     for(let i=0;i<str.length;i++){
//         if(str[i]===char){
//             console.log(`The character ${char} is found at index ${i}`);
//             count++;
//         }
//     }
//     console.log(`The character ${char} appears ${count} times in the string.`);
// }
// else if(difference==='no'||difference==='No'||difference==='NO'){
//     let lowerstr=str.toLowerCase();
//     let lowerchar=char.toLowerCase();
//     for(let i=0;i<lowerstr.length;i++){
//         if(lowerstr[i]===lowerchar){
//             console.log(`The character ${char} is found at index ${i}`);
//             count++;
//         }

// }
//     console.log(`The character ${char} appears ${count} times in the string.`);

// }
// //Question2-lap2-js
// let palindorm=prompt("Enter a string:");
// let diff=prompt("Is ignore CaseSenstive?");
// let len=palindorm.length;
// let lenInt=parseInt(len/2);
// let lenFloat=parseFloat(len/2);
// let flag=0;
// ////if=>>no (RAnar no palidorm) 
// if(diff==='no'||diff==='No'||diff==='NO'){
// if(lenInt!==lenFloat){//rerer
// for(let i=0;i<lenInt;i++){
//     if(palindorm[i]===palindorm[len-1-i]){
//         flag++;
//     }
//     }
//     if(flag===lenInt)
//      {console.log(`The string ${palindorm} is a palindrome.`);}
//     else{console.log(`The string ${palindorm} is not a palindrome.`);}
// }
// else if(lenInt===lenFloat){
//     for(let i=0;i<lenInt;i++){
//         if(palindorm[i]===palindorm[len-1-i]){
//             flag++;
//         }
       
//     }
//       if(flag===lenInt&&flag===lenFloat){
//             console.log(`The string ${palindorm} is a palindrome.`);
//         }
//         else{console.log(`The string ${palindorm} is not a palindrome.`);}
// }
// }
//  //else 
// else if(diff==='yes'||diff==='Yes'||diff==='YES'){
//     let lowerpalindorm=palindorm.toLowerCase();
//     if(lenInt!==lenFloat){
//         for(let i=0;i<lenInt;i++){
//             if(lowerpalindorm[i]===lowerpalindorm[len-1-i]){
//                 flag++;
//             }
//         }
//         if(flag===lenInt&&lenInt!==lenFloat)
//          {console.log(`The string ${palindorm} is a palindrome.`);}
//         else{console.log(`The string ${palindorm} is not a palindrome.`);}
// }
// else if(lenInt===lenFloat){
//     for(let i=0;i<lenFloat;i++){
//         if(lowerpalindorm[i]===lowerpalindorm[len-1-i]){
//             flag++;
//         }
        
//     }
//      if(flag===lenFloat&&flag===lenFloat){
//             console.log(`The string ${palindorm} is a palindrome.`);
//         }
//         else{console.log(`The string ${palindorm} is not a palindrome.`);}


// }
// }
//Question3-lap2-js
// let str2=prompt("Enter a string:");
// let longest=0;
// let longestword="";
// let arr=str2.split(" ");
// for(let i=0;i<arr.length;i++){
//     if(arr[i].length>longest){
//         longest=arr[i].length;
//         longestword=arr[i];
//     }
// }
// console.log(`The longest word in the string is: ${longestword} and its length is: ${longest}`);
//Question4-lap2-js
// var name;
//  var nameReg = new RegExp("^[A-Za-z\\s]+$");

// do{
//     name=prompt("please enter yourname");
// }while(!nameReg.test(name));
// var phone;
// var phonereg= new RegExp("^\\d{8}$") 
// do{
//     phone=prompt("please Enter numphone");
// }while(!phonereg.test(phone));
// var num;
// var numreg = new RegExp("^(010|011|012|013|015)\\d{8}$");

// do{
//     num=prompt("please enter phonenum");
// }while(!numreg.test(num));
// var Email;
// var Emailreg=new  RegExp("^[\\w.-]+@[A-Za-z\\d.-]+\\.[A-Za-z]{2,}$")
// do {
//     Email = prompt("Enter your email:");
// } while (!Emailreg.test(Email));
// var color;
// do {
//     color = prompt("Choose a color (red, green, blue):").toLowerCase();
// } while (color !== "red" && color !== "green" && color !== "blue");

// document.write(`<h2 style="color:${color}">Welcome ${name}</h2>`);
// document.write(`<p style="color:${color}">Phone: ${phone}</p>`);
// document.write(`<p style="color:${color}">Mobile: ${num}</p>`);
// document.write(`<p style="color:${color}">Email: ${Email}</p>`);
// document.write(`<p style="color:${color}">Today is: ${today.toDateString()}</p>`);


// //Question5-lap2-js(Math Object)
// //area of circle
let reduis=prompt("Enter the radius of the circle:");
let reduiss=Number(reduis);
if(isNaN(reduiss)){
    alert("Invalid input. Please enter a valid number.");
    reduis=prompt("Enter the radius of the circle:");
    reduiss=Number(reduis);

}
if(reduiss<0){
    alert("Invalid input. Please enter a non-negative number.");
}
else if(reduiss>=0){
    let area=Math.PI*Math.pow(reduiss,2);
    alert(`the area of the circle is ${area}`)
}
//squrer root
let numSquere=prompt("Enter a number to find its square root:");
let numSquereInt=parseInt(numSquere);
if(isNaN(numSquereInt)){
    alert("Invalid input. Please enter a valid number.");
    numSquere=prompt("Enter a number to find its square root:");
    numSquereInt=parseInt(numSquere);
}
let squereRoot=Math.pow(numSquereInt,0.5);
alert(`The square root of ${numSquereInt} is ${squereRoot}`);
//cosine of an angle
let angle=prompt("Enter an angle in degrees to find its cosine:");
let angleInt=parseInt(angle);
if(isNaN(angleInt)){
    alert("Invalid input. Please enter a valid number.");
    angle=prompt("Enter an angle in degrees to find its cosine:");
    angleInt=parseInt(angle);
}
let value=Math.cos((angleInt*Math.PI)/180);
alert(`The cosine of ${angleInt} degrees is ${value}`);
