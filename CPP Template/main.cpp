
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on October 3 2017 7:15 PM
 * Purpose: Rock Paper Scissors
 */

//System libraries
#include <iostream>
#include <string>
#include <stdlib.h>
#include <windows.h>
using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes

//Execution begins here - DEATH PENALTY
int main() {
    //Going to make input invisible so the other player cant cheat ~ just for fun
    HANDLE hStdin = GetStdHandle(STD_INPUT_HANDLE); 
    DWORD mode = 0;
    GetConsoleMode(hStdin, &mode);
    SetConsoleMode(hStdin, mode & (~ENABLE_ECHO_INPUT));
    
    
    //Variable Declaration
    string p1, p2;
    short nump1, nump2;//I cant figure out how represent a string as a num for swtich()
    
    //Process mapping from inputs to outputs
    cout<<"This program allows two players to play rock paper scissors"<<endl;
    cout<<"To play, enter p for paper, r for rock, and s for scissors"<<endl;
    
    //Get user input / Data
    cout<<"Player one enter the number for your object: "<<endl;;
    cout<<"  1. Paper \n  2. Scissors \n  3. Rock \n  ~ ";
    getline(cin, p1);
    cout<<endl;
    
    cout<<"Player two enter the number for your object: "<<endl;
    cout<<"  1. Paper \n  2. Scissors \n  3. Rock \n  ~ ";
    getline(cin, p2);
    cout<<endl;
    
    if(!(p1 != "1")){
        nump1 = 1;
    }
    /*if(p1 == '2'){
        nump1 = 2;
    }
    if(p1 == '3'){
        nump1 = 3;
    }
    if(p2 == '1'){
        nump2 = 1;
    }
    if(p2 == '2'){
        nump2 = 2;
    }
    if(p2 == '3'){
        nump2 = 3;
    }
    */
    
    switch(nump1){//Apparently switches cant be used with strings :(
    }
    //Re-Display inputs / Display outputs 
    
    //Exit to function main / End program
    return 0;
}

