import {getId} from './promises.js';
//Q1-Reset^spread
function Getminmax(...num){//[]
var max=Math.max(...num);//
var min= Math.min(...num);
 return `The max : ${max} The min : ${min} `
}
console.log(Getminmax(1,2,3,4,-3,50));
//Q2-ArrayMethod
 var fruits = ["apple", "strawberry", "banana", "orange", "mango"] ;
 //a. test that every element in the given array is a string 
 const allstring=fruits.every((fruit)=> typeof(fruit)==="string");
 console.log(allstring);//true
 //b. test that some of array elements starts with "a" 
  const startWithA=fruits.some((fruit)=>fruit.startsWith("a"));
 console.log(startWithA);
//c. generates new array filtered from the given array with only elements that starts with "b" or "s"
   const FilterFruit=fruits.filter((fruit)=> (fruit.startsWith("b")||fruit.startsWith("s")));
 console.log( FilterFruit);
 //d.generates new array each element of the new array contains a string  declaring that you like the give fruit element
  const likedFruits =fruits.map((fruit)=> `I like ${fruit}` );
 console.log( likedFruits);
 // e) Display elements using forEach()
 likedFruits.forEach((likedFruits)=>{console.log(likedFruits)});
