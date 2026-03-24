#include <iostream>
using namespace std;
int main()
{
    int n,s;
    cin>>n>>s;
    string word;
    cin>>word;
    char temp;
    while(s--){
    for(int i=0;i<n-1;i++){
         if(word[i]=='B'&&word[i+1]=='G')
        {     temp=word[i];
            word[i]=word[i+1];
             word[i+1]=temp;
             i++;

        }
    }
}
    cout<<word;
 }
