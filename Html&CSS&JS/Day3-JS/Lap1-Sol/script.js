//Lap1-Question1
// let massage=prompt("Enter your Massage");  
// for(let i=1;i<7;i++){
//     document.write(`<h${i}>${massage}</h${i}>`);
//     document.write(`<hr>`);
//  }
//Lap1-Question2
// let n=prompt("Enter the number of iterations");
// let sum=0;
// if(n==0){
//     console.log("User entered 0");
// }
// else{
// for(let i=0;i<n;i++){
// let number=prompt("Enter the number of elements");
// let number2=Number(number);
// if(isNaN(number2)){
//     alert("Please enter a valid number");
//     i--;
//     continue;
// }
// if(number2==0){
//     console.log("User entered 0");
//     break;
// }
// sum+=number2;
// if(sum>100){
//      break;
// }
// }
// console.log("The sum is "+sum);
// }
//lap1-question3
// let num1=prompt("Enter the first number");
// let number1=Number(num1);
// if(isNaN(number1)){
//     alert("Please enter a valid number");
//       num1=prompt("Enter the first number");
//      number1=Number(num1);
// }
// let num2=prompt("Enter the second number");
// let number2=Number(num2);
// if(isNaN(number2)){
//     alert("Please enter a valid number");
//       num2=prompt("Enter the second number");
//      number2=Number(num2);
// }
// let max =number1>number2?number1:(number2>number1?number2:"Both numbers are equal");
// console.log("The maximum number is "+max);
//lap1-question4
// let x=prompt("Enter the first number");
// let numberx=Number(x);
// if(isNaN(numberx)){
//     alert("Please enter a valid number");
//     x=prompt("Enter the first number");
//     numberx=Number(x);
// }
// let y=prompt("Enter the second number");
// let numbery=Number(y);
// if(isNaN(numbery)){
//     alert("Please enter a valid number");
//     y=prompt("Enter the second number");
//     numbery=Number(y);
// }
// let z=prompt("Enter the third number");
// let numberz=Number(z);
// if(isNaN(numberz)){
//     alert("Please enter a valid number");
//     z=prompt("Enter the third number");
//     numberz=Number(z);
// }
// let flagy=0;
// if(numberx%numbery==0)
// {flagy=1;}
// let flagz=0;
// if(numberx%numberz==0)
// {flagz=1;}
// if(flagy==1 && flagz==1){
//     console.log(numberx+" is divisible by both "+numbery+" and "+numberz);
// }
// else if(flagy==1){
//     console.log(numberx+" is divisible by "+numbery+" but not "+numberz);
// }
// else if(flagz==1){
//     console.log(numberx+" is divisible by "+numberz+" but not "+numbery);
// }   
// //lap1-question5
// let start=prompt("Enter the start number");
// let numberstart=Number(start);
// if(isNaN(numberstart)){
//     alert("Please enter a valid number");
//     start=prompt("Enter the start number");
//     numberstart=Number(start);
// }
// let end=prompt("Enter the end number");
// let numberend=Number(end);  
// if(isNaN(numberend)){
//     alert("Please enter a valid number");
//     end=prompt("Enter the end number");
//     numberend=Number(end);
// }
// let sum=0;
// //divsible%3
// for(let i=numberstart;i<=numberend;i++){
//     if(i%3==0){
//         sum+=i;
//         console.log("multiple of 3: "+i);
//      }
// }
// //divsible%5
// for(let i=numberstart;i<=numberend;i++){
// if(i%5==0){
//      sum+=i;
//         console.log("multiple of 5: "+i);
// }
// }
// console.log("The sum of numbers divisible by 3 or 5 = "+sum);
//Question6
// let n=prompt("Enter the number of iterations");
// let number=Number(n);
// if(isNaN(number)){
//     alert("Please enter a valid number");
//     n=prompt("Enter the number of iterations");
//     number=Number(n);
// }
// for(let i=1;i<=number;i++){
//     for(let j=1;j<=i;j++){
//         document.write("*");
//     }
//     document.write(`<br>`);
// }
//question7
let sum=0;
let x=prompt("Enter the first number");
let numberx=Number(x);  
if(isNaN(numberx)){
    alert("Please enter a valid number");
    x=prompt("Enter the first number");
    numberx=Number(x);
}
let y=prompt("Enter the second number");
let numbery=Number(y);  
if(isNaN(numbery)){
    alert("Please enter a valid number");
    y=prompt("Enter the second number");
    numbery=Number(y);
}
let z=prompt("Enter the third number");
if(z!=="odd"&&z!=="even"&&z!=="no"&&z!=="ODD"&&z!=="EVEN"&&z!=="NO"){
    alert("Please enter a valid input (odd, even, no)");
    z=prompt("Enter the third number");
}
if(z=="odd"||z=="ODD"){
     for(let i=numberx;i<=numbery;i++){
        if(i%2!=0){
            console.log("the odd number is "+i);
            sum+=i;
        }
     }
}
else if(z=="even"||z=="EVEN"){
        for(let i=numberx;i<=numbery;i++){
        if(i%2==0){
            console.log("the even number is "+i);
            sum+=i;
        }
        }
}
else{
    for(let i=numberx;i<=numbery;i++){
        console.log("the number is "+i);
        sum+=i;
    }
}
console.log("The sum is "+sum);