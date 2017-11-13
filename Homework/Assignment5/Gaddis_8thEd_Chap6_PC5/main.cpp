
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: Falling distance
 */

//System libraries
#include <iostream>
using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY
const float GRAV = 9.8f; // M / S^2

//Function prototypes
float falling(float);

//Execution begins here - DEATH PENALTY
int main() {
    //Variable Declaration
    float time;
    
    //Process mapping 
    cout<<"This program calculates the distance traveled in free fall"<<endl;
    
    //Get input
    cout<<"Enter how many seconds the object was falling: ";
    cin>>time;
    cout<<endl;
    
    //Process data / Output
    cout<<"The distance the object fell was "<<falling(time)<<" meters"<<endl;
    
    //Exit to function main / End program
    return 0;
}

float falling(float time){
    cout<<time;
    return 0.5*(GRAV)*(time * time);
}