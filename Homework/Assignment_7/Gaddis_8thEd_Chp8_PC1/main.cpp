/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: Rock Paper Scissors
 */

//System libraries
#include <iostream>
#include <stdlib.h>
#include <ctime>

using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes

//Execution begins here - DEATH PENALTY
int main() {
    //Declare variables
    int size = 18;
    int *accnts = new int [size];
    
    //Initialize variables
    *accnts = 5658845,4520125,7895122,877541,8451277,13850,8080152,4562555,
    5552012,5050552,7825877,1250255,1005231,6545231,3852085,7576651,7881200,
    4581002;
    
    //Process information
    cout<<"Enter the account number you wish to charge: ";
    int temp;
    cin>>temp;
    
    for(short i = 0; i < size; i++){
        if(temp == accnts[i]){
            cout<<"Account successfully charged"<<endl;
        }
        else{
            cout<<"That account doesn't exist, try again."<<endl;break;
        }
    }
    
    //Exit to function main / End program
    return 0;
}