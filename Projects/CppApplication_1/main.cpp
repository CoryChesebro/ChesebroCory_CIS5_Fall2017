/* 
 * File:   main.cpp
 * Author: Cory
 * Created on November 4, 2017, 8:18 PM
 */

/* Make an array to hold cards and have a  
 * function that iterates over them to check value
 * 
 * Have a do-while loop for the control of functions
 * 
 * Have a function that generates the computers cards 
 * and puts them in a string?
 * 
 * 
 */

//No variable names over 7 characters!!

#include <iostream>
#include <iomanip>
#include <cmath>
#include <cstdlib>
#include <fstream>
#include <string>
#include <ctime>

using namespace std;

//Global constants

//Function prototypes
string gCards(short);
void chekVal(short);

//Execution begins here
int main() {
    //Declare / Initialize variables
    string name;
    
    //Process mapping
    cout<<"Welcome to BlackJack!"<<endl<<endl;
    cout<<"BlackJack is a simple game, your goal is to reach a value of 21"
            " with out going over, and to also have a higher score than the"
            " others you play with."<<endl<<"You start with two cards and can "
            "'hit' to get another card or 'stand' to not get anymore cards."
            <<endl<<"Card values are as follows : 2-10 stand for face value, "
            "Ace can count as 1 or 11 and face cards count as 10."<<endl<<endl;
    cout<<"Lets get started!"<<endl<<endl;
    
    cout<<"What is your name?: ";
    cin>>name;
    cout<<endl;
    
    cout<<"Hello "<<name<<", you will be playing BlackJack against the computer"
            ", good luck!"<<endl;
    
    //Exit function and close files
    //Close files, Dont forget
    return 0;
}

