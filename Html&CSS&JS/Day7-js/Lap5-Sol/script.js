let inputA=document.getElementById('Answer');
function EnterNumber(value){
    inputA.value+=value;
   // console.log(inputA.value);
}

 function EnterOperator(value){
     if(inputA.value==="")
     {
        return;
     }//234
     let lastchar=inputA.value[inputA.value.length-1];
 if(lastchar!=='+'&&lastchar!=='-'&&lastchar!=='*'&&lastchar!=='/'){
        inputA.value+=value;//345+
}

 

}
//23+4-4
function EnterEqual() {
   let exp = inputA.value;
    try {
        let result = eval(exp);
        inputA.value = result;
         console.log(result);
    } catch (error) {
        alert("Invalid Expression!");
    }
    
 

}
function EnterClear(){
    inputA.value ="";
}