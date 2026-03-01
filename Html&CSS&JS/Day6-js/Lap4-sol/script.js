//1.1. Window Object 
function ShowMassge(){
    let mass="Hello with massage tayping Amany Hesham salah......";
    let Child = window.open("", "_blank", "width=300,height=200");
    Child.document.write(`
          <html>
        <body>
            <p id="massage"></p>
        </body>
        </html>
        `);
        let i=0;
        function printlettter(){
            if(i<mass.length){
                Child.document.getElementById('massage').innerHTML +=mass[i];
                i++;
                setTimeout(printlettter, 200);
            }
            else{
                Child.window.close();
            }
        }
printlettter();
}
