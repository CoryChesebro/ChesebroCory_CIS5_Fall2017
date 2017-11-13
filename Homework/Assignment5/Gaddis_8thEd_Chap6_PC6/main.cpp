
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
float kinE(short, short);

//Execution begins here - DEATH PENALTY
int main() {
    //Variable Declaration
    short mass, vel;
    
    //Process mapping
    cout<<"This program takes in the velocity and mass of an object and gives"
            " back its kinetic energy"<<endl;
    
    //Get user input
    cout<<"Enter the mass of the object: ";
    cin>>mass;
    cout<<endl;
    
    cout<<"Enter the velocity of the object: ";
    cin>>vel;
    cout<<endl;
    
    //Output
    cout<<"The kinetic energy of the object is "<<kinE(mass, vel)<<" J"<<endl;
    
    //Exit to function main / End program
    return 0;
}

float kinE(short mass, short vel){
    return 0.5*(mass)*(vel * vel);
}