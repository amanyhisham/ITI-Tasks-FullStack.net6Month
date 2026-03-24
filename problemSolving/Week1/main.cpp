#include <iostream>
#include <iomanip>
#include <algorithm>
#include <cmath>
using namespace std;
int main()
{
       //link Problem--->https://codeforces.com/group/Bu2yXAqHyK/contest/463318
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       //1-A. Make a triangle!
      int a,b,c;
       cin>>a>>b>>c;
       int mx=max(a,max(b,c));
       if(mx==a){
        if(b+c>mx)cout<<0;
        else cout<<(a-(b+c))+1;
       }
       else if(mx==b){
        if(a+c>mx)cout<<0;
        else cout<<(b-(a+c))+1;
       }
       else{
        if(a+b>mx)cout<<0;
        else cout<<(c-(a+b))+1;
       }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       //B. Supermarket
      int n,m; cin>>n>>m;
      double min_price=1e9;
       for(int i=0;i<n;i++){
       double a, b;
        cin >> a >> b;
       double cost=a/b;
        min_price=min(cost,min_price);
        // cout<<cost <<" "<<min_price<<endl;
      }
      cout<<fixed<< setprecision(8)<<min_price*m;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //C. Fafa and his Company

    int e;cin>>e;
    int cou=0;
    for(int i=1;i<=e/2;i++){
            int res=(e-i);
        if((res%i)==0)cou++;
       // cout<<e-i<<" "<<i<<" "<<res%i<<endl;
    }
    cout<<cou;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//D. Reconnaissance
int a,b;cin>>a>>b;
int arr[a];int cou=0;
for(int i=0;i<a;i++){
    cin>>arr[i];
 }
for(int i=0;i<a;i++){
   for(int j = 0; j < a; j++) {
            if(i != j) {
                if(abs(arr[i] - arr[j]) <= b) {
                    cou++;
                }
            }
}
}
cout<<cou;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//E. Count The Pairs(Easy)
int n;cin>>n;
int arr[n];
int mx =0;
int mn =1e9;
for(int i=0;i<n;i++){
    cin>>arr[i];
    mx=max(arr[i],mx);
    mn=min(arr[i],mn);

}
//cout<<mx<<" "<<mn;
int tot=mx+mn;
//cout<<tot<<" "<<mn<<" "<<mx<<endl;
int cou=0;
for(int i=0;i<n;i++){
  for(int j=i+1;j<n;j++){
    if(arr[i]+arr[j]==tot)
    {cou++;
//cout<<arr[i]<<" "<<arr[j]<<" "<<arr[i]+arr[j]<<" "<<tot<<endl;
    }

  }

}
cout<<cou;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//F - Count The Pairs(Medium)
int n;cin>>n;
int arr[n];
int mx =0;
int mn =1e9;
for(int i=0;i<n;i++){
    cin>>arr[i];
    mx=max(arr[i],mx);
    mn=min(arr[i],mn);

}
sort(arr,arr+n);
int tot=mn+mx;
int l= 0;
int r= n - 1;
int cou = 0;
while(l<r){
    if(arr[l]+arr[r]==tot){
    //cout<<arr[l]<<" "<<arr[r]<<"Equal"<<endl;
        l++;
        r--;
        cou++;
     }
    else if(arr[l]+arr[r]<tot){
    //cout<<arr[l]<<" "<<arr[r]<<"sum less"<<endl;
                   l++;

    }
    else if(arr[l]+arr[r]>tot){
   // cout<<arr[l]<<" "<<arr[r]<<"sum bigger"<<endl;
        r--;

    }
}

cout<<cou;

}
