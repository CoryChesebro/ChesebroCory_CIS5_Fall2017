
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: Winning Division
 */

//System libraries
#include <iostream>

using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes
void getSales(string);
void findHighest(string, float);

//Execution begins here - DEATH PENALTY
int main() {
    //Process mapping
    cout<<"This program takes in the four divisions and their earnings and "
            "outputs the division with the highest earnings."<<endl;
    
    //Get inputs
    for(short i = 0; i < 4; i++){
        string temp;
        
        cout<<"Please enter a division name: ";
        cin>>temp;
        cout<<endl;
        
        getSales(temp);
    }
    //Exit to function main / End program
    return 0;
}

void getSales(string name){
    float earning;
    
    cout<<"Please enter the earnings of the "<<name<<" division: ";
    cin>>earning;
    cout<<endl;
    
    if(earning < 0){
        cout<<"Please enter a positive number"<<endl;
        getSales(name);
    }
    else{
        cout<<name<<" earned $"<<earning<<endl<<endl;;
        findHighest(name, earning);
    }
}

void findHighest(string name, float earning){
    static short count = 1;
    static float highTot = 0;
    static string highNam = " ";
    if(count < 4){
        if(earning > highTot){
            highTot = earning;
            highNam = name;
        }
    }
    else if(count == 4){
        if(earning > highTot){
            highTot = earning;
            highNam = name;
        }
        cout<<"The division with the highest earnings is "<<highNam<<" with $"<<
                highTot<<endl;
    }
    count++;
}