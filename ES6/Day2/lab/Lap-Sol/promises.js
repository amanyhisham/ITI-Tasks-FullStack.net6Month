async function getId() {
    try{
         let res=await fetch("https://jsonplaceholder.typicode.com/users");//-->promise
         //console.log(res);
         let data=await res.json();//-->object[name:- ,id:- ,username:- ,email:- , address:- ]
         let continer=document.getElementById("users");
         data.forEach(element => {
         let btn=document.createElement("button");
         btn.innerHTML=element.name;
         btn.onclick=()=>getPost(element.id)
         continer.appendChild(btn);
         });
         
    
    }
    catch(e){
        console.log("error ");
    }
}
getId()

async function getPost(ElementId) {
    try {
        let res = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${ElementId}`);
        let data = await res.json();
        let container = document.getElementById("posts");  
        container.innerHTML = "";  

        data.forEach(post => {
            let p = document.createElement("p");
            p.innerHTML = post.title;  
            container.appendChild(p);
        });
    } catch (e) {
        console.log("error", e);
    }
}
export{getId,getPost};