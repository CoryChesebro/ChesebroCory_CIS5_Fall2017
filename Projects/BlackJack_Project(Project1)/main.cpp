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
string genCrds(short);
string outCrds(string);
short chekVal(string);


//Execution begins here
int main() {
    //Declare / Initialize variables / Initialize random seed
    srand(static_cast<unsigned int>(time(0)));
    string name, input = "hit";
    string pCards = genCrds(2), dCards = genCrds(2);//Declare each players hand
    short pTotal = chekVal(pCards), cTotal = chekVal(dCards);
    
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
    //cin>>name;
    cout<<endl;
    
    cout<<"Hello "<<name<<", you will be playing BlackJack against the computer"
            ", good luck!"<<endl;
    do{
        if(chekVal(pCards) == 21){
            cout<<"BlackJack! Your card value is 21 so you win! Come back soon!";
            exit(EXIT_SUCCESS);
        }
        else{
            cout<<"Your hand is "<<outCrds(pCards)<<" which totals to "<<
                    chekVal(pCards)<<" would you like to hit(get another card), "
                    "or stand?: ";
            cin>>input;
            cout<<endl;
            pCards += genCrds(1);
        }
        
        
    }while(input == "Hit" || input == "hit");
    
    //Exit function and close files
    //Close files, Don't forget
    return 0;
}

string genCrds(short numCrds){
    string temp = "";
    for(short i = 0; i < numCrds; i++){
        unsigned char temp2 = 0;
        temp2 += (rand()%13 + 1);
        switch(temp2){
            case 1: temp += '2';break;
            case 2: temp += '3';break;
            case 3: temp += '4';break;
            case 4: temp += '5';break;
            case 5: temp += '6';break;
            case 6: temp += '7';break;
            case 7: temp += '8';break;
            case 8: temp += '9';break;
            case 9: temp += 'T';break;
            case 10: temp += 'J';break;
            case 11: temp += 'Q';break;
            case 12: temp += 'K';break;
            case 13: temp += 'A';break;
        }
    }
    return temp;
}

short chekVal(string hand){
    short total = 0;
    short hasAce = 0;
    for(short i = 0; i < hand.length(); i++){
        char temp = hand[i];
        switch(temp){
            case '2': total += 2;break;
            case '3': total += 3;break;
            case '4': total += 4;break;
            case '5': total += 5;break;
            case '6': total += 6;break;
            case '7': total += 7;break;
            case '8': total += 8;break;
            case '9': total += 9;break;
            case 'T': total += 10;break;
            case 'J': total += 10;break;
            case 'Q': total += 10;break;
            case 'K': total += 10;break;
            case 'A': hasAce += 1;break;
        }
    }
    for(short i = 0; i < hasAce; i++){
        ((total + 11)> 21?(total += 1):(total += 11));
    }
    return total;
}

string outCrds(string hand){
    string outPut = "";
    for(short i = 0; i < hand.length(); i++){
        char temp = hand[i];
        switch(temp){
            case '2': (i == hand.length() - 1)?(outPut += "2"):(outPut += "2, ")
                    ;break;
            case '3': (i == hand.length() - 1)?(outPut += "3"):(outPut += "3, ")
                    ;break;
            case '4': (i == hand.length() - 1)?(outPut += "4"):(outPut += "4, ")
                    ;break;
            case '5': (i == hand.length() - 1)?(outPut += "5"):(outPut += "5, ")
                    ;break;
            case '6': (i == hand.length() - 1)?(outPut += "6"):(outPut += "6, ")
                    ;break;
            case '7': (i == hand.length() - 1)?(outPut += "7"):(outPut += "7, ")
                    ;break;
            case '8': (i == hand.length() - 1)?(outPut += "8"):(outPut += "8, ")
                    ;break;
            case '9': (i == hand.length() - 1)?(outPut += "9"):(outPut += "9, ")
                    ;break;
            case 'T': (i == hand.length() - 1)?(outPut += "10"):(outPut += "10, ")
                    ;break;
            case 'J': (i == hand.length() - 1)?(outPut += "J"):(outPut += "J, ")
                    ;break;
            case 'Q': (i == hand.length() - 1)?(outPut += "Q"):(outPut += "Q, ")
                    ;break;
            case 'K': (i == hand.length() - 1)?(outPut += "K"):(outPut += "K, ")
                    ;break;
            case 'A': (i == hand.length() - 1)?(outPut += "A"):(outPut += "A, ")
                    ;break;
        }
    }
    return outPut;
}