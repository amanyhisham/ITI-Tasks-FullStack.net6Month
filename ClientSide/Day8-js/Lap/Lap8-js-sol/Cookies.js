//setCookies
function setcookies(name,value,expiresdata){
    let cookies=name + "=" + value
    if(expiresdata){
cookies += ";expires=" + expiresdata.toUTCString();    }

document.cookie=cookies;
}
//getCookies
function getcookies(cookieName){
let arr=document.cookie.split(";");
console.log(arr);
 for(let i=0;i<arr.length;i++){
let[key,value]=arr[i].split('=');
if(key.trim() ==cookieName)return value;

 }
 return null;
}
//deletCookies
function deletcookies(cookieName){
 document.cookie = cookieName + "=;expires=Thu, 01 Jan 1970 00:00:00 UTC";
}
//listCookies
function All_list(){
    if(document.cookie){
        return document.cookie.split('; ');
}
return [];
}
//hasCookies
function HasCookies(cookieName){
if(getcookies(cookieName)!==null)return true
else return false
}
 