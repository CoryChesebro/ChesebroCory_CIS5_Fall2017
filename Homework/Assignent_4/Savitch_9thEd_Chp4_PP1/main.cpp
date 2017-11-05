
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: miles per liter -> miles per gallon
 */

//System libraries
#include <iostream>
#include <iomanip>

using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY
const float LPG = 0.264179f;//6 sig digits! close to 7+

//Function prototypes
float mpg(short var1, float var2);

//Execution begins here - DEATH PENALTY
int main() {
    //Variable Declaration
    short liters, miles;
    float mPerG, gallons;

    //Process mapping from inputs to outputs
    cout<<"The purpose of this program is to take the liters of gas your car "
            "has consumed and the miles driven and calculate what your miles per"
            " gallon would be"<<endl;
    
    //Get user input / Data
    cout<<"Please enter the liters consumed followed by the miles driven: ";
    cin>>liters>>miles;
    cout<<endl;
    
    //Find gallons and call function to find miles per gallon
    gallons = static_cast<float>(liters) * LPG;
    mPerG = mpg(miles, gallons);
    
    //Output
    cout<<fixed<<setprecision(2);//Limits output decimals
    
    cout<<"Your miles per gallon is "<<mPerG<<endl;
    
    //Exit to function main / End program
    return 0;
}

float mpg(short var1, float var2) {
    
    //Variable declaration
    float mPrGal;
    
    //Variable initialization
    mPrGal = var1 / var2;
    
    //Return
    return mPrGal;
}

