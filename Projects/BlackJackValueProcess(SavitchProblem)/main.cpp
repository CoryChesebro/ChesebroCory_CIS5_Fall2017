
/* 
 * File:   main.cpp
 * Author: Cory Chesebro
 * Created on 10/31/17 2:27 PM
 * Purpose: Project 1
 */

/*Checklist for project
 * One of each variable type (no doubles?)
 * do-while loop and for loop
 * switch
 * ternary operator
 * if - else if - else statements
 * functions?
 * file i/o
 *  
 */

//System libraries
#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <cmath>
#include <string>

using namespace std;

//User Libraries

//Global constants - Physics/Math/Conversions ONLY

//Function prototypes

//Execution begins here - DEATH PENALTY
int main() {
   //Variable Declaration
    short nCards, total = 0, cards;
    unsigned char a,b,c,d,e,hasAce = 0;//Variables for the cards in the hand and a sentinel for aces
    
    //Tells the user what the program does and how BlackJack works
    cout<<"This program will tell you the value of your hand in the game BlackJack"
            <<endl<<endl;
    cout<<"In the game BlackJack, you can have 2-5 cards, the numbered cards"
            " are worth their corresponding value, and all face cards except "
            "ace are worth 10. The Ace is worth 1 or 11 depending on which value"
            " is more beneficial to the player."<<endl<<endl;
    
    //Get the number of cards
    cout<<"Please enter the number of cards in your hand: ";
    cin>>nCards;
    cout<<endl;
    cards = nCards;//Used as a pseudo counter in the for loop
    
    //Would have used a for loop but don't know how to enumerate n variables
    cout<<"Please enter the cards in your hand (J for Joker, Q for Queen"
            ", K for King, A for Ace, and T for 10 or which ever number is on the face"
            " of your card)"<<endl;
    
    for(nCards; nCards >= 1; --nCards){
        short tmp = (cards + 1) - nCards;//Used to keep track of which cards is inputted
        if (tmp == 1){//Several ifs are used to assign variables their value
            cout<<"Card "<<tmp<<": ";
            cin>>a;
            cout<<endl;  
            switch(a){
                case '2': total += 2;break;
                case '3': total += 3;break;
                case '4': total += 4;break;
                case '5': total += 5;break;
                case '6': total += 6;break;
                case '7': total += 7;break;
                case '8': total += 8;break;
                case '9': total += 9;break;
                case 't': total += 10;break;
                case 'T': total += 10;break;
                case 'j': total += 10;break;
                case 'J': total += 10;break;
                case 'q': total += 10;break;
                case 'Q': total += 10;break;
                case 'k': total += 10;break;
                case 'K': total += 10;break;
                case 'a': hasAce += 1;break;
                case 'A': hasAce += 1;break;
                default: cout<<"You entered an invalid card value"<<endl;
                exit(EXIT_FAILURE);
            }
        }
        if (tmp == 2){
            cout<<"Card "<<tmp<<": ";
            cin>>b;
            cout<<endl;
            switch(b){
                case '2': total += 2;break;
                case '3': total += 3;break;
                case '4': total += 4;break;
                case '5': total += 5;break;
                case '6': total += 6;break;
                case '7': total += 7;break;
                case '8': total += 8;break;
                case '9': total += 9;break;
                case 't': total += 10;break;
                case 'T': total += 10;break;
                case 'j': total += 10;break;
                case 'J': total += 10;break;
                case 'q': total += 10;break;
                case 'Q': total += 10;break;
                case 'k': total += 10;break;
                case 'K': total += 10;break;
                case 'a': hasAce += 1;break;
                case 'A': hasAce += 1;break;
                default: cout<<"You entered an invalid card value"<<endl;
                exit(EXIT_FAILURE);
            }
        }
        if (tmp == 3){
            cout<<"Card "<<tmp<<": ";
            cin>>c;
            cout<<endl;
            switch(c){
                case '2': total += 2;break;
                case '3': total += 3;break;
                case '4': total += 4;break;
                case '5': total += 5;break;
                case '6': total += 6;break;
                case '7': total += 7;break;
                case '8': total += 8;break;
                case '9': total += 9;break;
                case 't': total += 10;break;
                case 'T': total += 10;break;
                case 'j': total += 10;break;
                case 'J': total += 10;break;
                case 'q': total += 10;break;
                case 'Q': total += 10;break;
                case 'k': total += 10;break;
                case 'K': total += 10;break;
                case 'a': hasAce += 1;break;
                case 'A': hasAce += 1;break;
                default: cout<<"You entered an invalid card value"<<endl;
                exit(EXIT_FAILURE);
            }
        }
        if (tmp == 4){
            cout<<"Card "<<tmp<<": ";
            cin>>d;
            cout<<endl;
            switch(d){
                case '2': total += 2;break;
                case '3': total += 3;break;
                case '4': total += 4;break;
                case '5': total += 5;break;
                case '6': total += 6;break;
                case '7': total += 7;break;
                case '8': total += 8;break;
                case '9': total += 9;break;
                case 't': total += 10;break;
                case 'T': total += 10;break;
                case 'j': total += 10;break;
                case 'J': total += 10;break;
                case 'q': total += 10;break;
                case 'Q': total += 10;break;
                case 'k': total += 10;break;
                case 'K': total += 10;break;
                case 'a': hasAce += 1;break;
                case 'A': hasAce += 1;break;
                default: cout<<"You entered an invalid card value"<<endl;
                exit(EXIT_FAILURE);
            }
        }
        if (tmp == 5){
            cout<<"Card "<<tmp<<": ";
            cin>>e;
            cout<<endl;
            switch(b){
                case '2': total += 2;break;
                case '3': total += 3;break;
                case '4': total += 4;break;
                case '5': total += 5;break;
                case '6': total += 6;break;
                case '7': total += 7;break;
                case '8': total += 8;break;
                case '9': total += 9;break;
                case 't': total += 10;break;
                case 'T': total += 10;break;
                case 'j': total += 10;break;
                case 'J': total += 10;break;
                case 'q': total += 10;break;
                case 'Q': total += 10;break;
                case 'k': total += 10;break;
                case 'K': total += 10;break;
                case 'a': hasAce += 1;break;
                case 'A': hasAce += 1;break;
                default: cout<<"You entered an invalid card value"<<endl;
                exit(EXIT_FAILURE);
            }
        }
    }
    
    //Finalize scores by implementing aces
    if(hasAce > 0){
        if (total > 21){
            cout<<"You busted! Your total was "<<total<<endl;
            exit(EXIT_FAILURE);
        }
        else{
            for(hasAce; hasAce >= 1; hasAce--){
                ((total + 11)> 21?(total += 1):(total += 11));
            }
            (total > 21)?(cout<<"You busted! Your total was "<<total):(cout<<
                    "Your total is "<<total<<endl);
        }
    }

    else{
        (total > 21)?(cout<<"You busted! Your total was "<<total):(cout<<
                    "Your total is "<<total<<endl);
    }
    
    //Exit to function main / End program
    return 0;
}