
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: Kinetic Energy
 */

//System libraries
#include <iostream>
using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes
float fToC(short);

//Execution begins here - DEATH PENALTY
int main() {
    //Variable declaration
    //None?
    
    //Process mapping
    cout<<"This program outputs the conversion of Fahrenheit to Celsius for the "
            "first 20 degrees"<<endl;
    
    //Output conversion
    for(short i = 0; i <= 20; i++){
        cout<<i<<" degrees Fahrenheit is "<<fToC(i)<<" degrees Celsius"<<endl;
        
    }
    //Exit to function main / End program
    return 0;
}
float fToC(short temp){
    return (5/9.0f)*(temp - 32);
}