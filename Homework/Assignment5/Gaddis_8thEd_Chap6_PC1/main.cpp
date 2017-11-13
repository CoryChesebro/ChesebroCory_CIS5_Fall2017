
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on November 13 2017 2:19 PM
 * Purpose: Markup
 */

//System libraries
#include <iostream>
using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes
float calcR(float, float);

//Execution begins here - DEATH PENALTY
int main() {
    //Variable Declaration
    float markUp, price;
    
    //Process mapping
    cout<<"This program takes in the price of an item and its markup and gives"
            " the retail price of it."<<endl;
    
    //Get user input
    cout<<"Enter the price of the item: $";
    cin>>price;
    cout<<endl;
    
    cout<<"Enter the percent markup as a decimal: ";
    cin>>markUp;
    cout<<endl;
    
    //Output price after markup
    cout<<"The retail price of the item would be: $"<<calcR(price, markUp)<<endl;
    
    //Exit to function main / End program
    return 0;
}

float calcR(float price, float markUp){
    return (price * (1 + markUp));
}