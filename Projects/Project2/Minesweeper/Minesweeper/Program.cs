using System;
using System.IO;

//Minesweeper
//Need function that generates mines
//Need function to initialize arrays
//Need function to output arrays
//Need function that counts mines around the position that was chosen
//Pre - generate board in mines array
//Implement flags, score, name, difficulties - Didnt do it, not enough time to meet deadline
//IsAdjacent function to control spread, have it check if there is an X adjacent to and change it to green and true so it shows as clean on next print
//Bomb count for win condition

class Program {
    static void Main() {
        //Set random seed / Instatiate Oject
        Random rnd = new Random();
        Game game = new Game();

        //Declare variables
        short size = 10;//Testing purposes, change this to input later
        short num = 25;//Number of bombs, change to input later
        string pName = "";//Players name
        bool[,] board = new bool[size, size];
        char[,] mines = new char[size, size];
        bool[,] picks = new bool[size, size];

        //Get everthing ready / Initialize arrays
        game.InitArr(board, size);
        game.InitArr(picks, size);
        game.InitArr(mines, size);
        game.GenMnes(mines, rnd, num);
        game.MakeBrd(mines, size);

        Console.WriteLine("Welcome to my Minesweeper!");
        Console.WriteLine("In this game your goal is to clear all the places on the board and avoid all the mines.");
        Console.WriteLine("You will have as many turns as you like, the game will end once you clear all the spaces with no bombs or when you type exit as your next guess");
        Console.WriteLine("");
        Console.Write("Enter your name to get started: ");
        pName = Console.ReadLine();
        game.PrntArr(mines, board, picks, size);
        //game.DbgPrnt(mines, size);
        do {
            game.Input(board, mines, picks);
            //game.DbgPrnt(mines, size);
            game.PrntArr(mines, board, picks, size);
            if (game.ChckWin(picks, num)) {
                Console.Clear();
                Console.WriteLine("You won!!!");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
        } while (true);
        
        //game.DbgInp(board, mines, picks);
        Console.ReadLine();
    }
    /*
     * GamFile - Game File --Didnt have enough time to implement 
     * Purpose: Output the players name and if they won, and the board the played
     * Input: character array, string name, boolean win or lose
     * Output: Void - only writes to file
     * 
     */
    public void GamFile(char[,] arr, string name, bool win) {
        if (true) {
            string [] head = new string [] { name + "has won the game, this was the board played" };
            using(StreamWriter sw = new StreamWriter("game.txt")) {
                foreach(string i in head) {
                    sw.WriteLine(i);
                }
            }
        }
        else {
            string [] head = new string [] { name + "has lost the game, this was the board played" };
            using (StreamWriter sw = new StreamWriter("game.txt")) {
                foreach(string i in head) {
                    sw.WriteLine(i);
                }
            }
        }
    }
}

class Game {
    /*  
     *  InitArr - Initialize Array
     *  Purpose: Take a character or boolean array and initialize the values
     *  Input: Character Array / Boolean Array and the size of the array
     *  Output: Void - only modifies the array
     *  
     */

    public void InitArr(char[,] arr, int size) {//Define InitArr for chars
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = '0';//Set char array = '0'
            }
        }
    }

    public void InitArr(bool[,] arr, int size) {//Overload InitArr for booleans
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = false;//Set bool array to false
            }
        }
    }

    /*
     * GenMnes - Generate mines
     * Purpose: Generate mines in the character array
     * Input: character array, Random number seed, number of mines to generate
     * Output: Void - Only modifies array
     * 
     */

    public void GenMnes(char[,] arr, Random rnd, short num) {
        for (short i = 0; i < num; i++) {
            bool dup = false;//Check for duplicates
            do {
                int temp1, temp2;
                temp1 = rnd.Next(0, 9);
                temp2 = rnd.Next(0, 9);
                if (arr[temp1, temp2] == '*') {
                    dup = true;//If this bomb is a duplicate, loop again
                }
                else {
                    arr[temp1, temp2] = '*';
                    dup = false;//If the bomb isnt a duplicate, end the loop and move on.
                }
            } while (dup);
        }
    }

    /*
     * DbgPrnt - Debug Print
     * Purpose: Help debug through out development process
     * Input: character array, size of the array
     * Output: Void - Prints to console
     * 
     */

    public void DbgPrnt(char [,] arr, int size) {
        //Console.Clear();
        for(short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                if(arr[i,j] == '0') {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else if (arr[i, j] == '1') {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;//Changes color of the console per number
                    Console.Write(arr[i, j]);//Writes the number
                    Console.Write(" ");//Puts a space between numbers
                    Console.ResetColor();//Resets color for next output
                }
                else if (arr[i, j] == '2') {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '3') {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '4') {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '5') {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '6') {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '7') {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (arr[i, j] == '8') {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("");
        }
    }

    /*
     * PrntArr - Print Array 
     * Purpose: Prints the character array holding the bombs and number of adjacent bombs
     * Input: character array, boolean array, boolean array, size of all the arrays
     * Output: Void - Prints to console
     * 
     */

    public void PrntArr(char[,] arr, bool[,] adjcnt, bool[,] picks, int size) {
        string letters = "  A B C D E F G H I J";//Goes on top of board
        int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };//Goes to left of board
        Console.Clear();
        Console.WriteLine(letters);
        for (short i = 0; i < size; i++) {
            Console.Write(nums[i]);
            Console.Write(" ");
            for (short j = 0; j < size; j++) {
                if (!picks[i, j]) {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else if (picks[i, j] || adjcnt[i, j]) {
                    if (arr[i, j] == '0') {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else if (arr[i, j] == '1') {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '2') {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '3') {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '4') {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '5') {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '6') {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '7') {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (arr[i, j] == '8') {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("");
        }
    }

    /*
     * MakeBrd - Make Board
     * Purpose: Set the character array = to 1-8 if for any spots adjacent to a bomb
     * Input: character array, size of the array
     * Output: Void - only modifies the array
     * 
     */

    public void MakeBrd(char[,] arr, int size) {//Find bombs and check around them, watch for other bombs and out of (Math.Sqrt(charArr.Length) - 1)s of the array
        for (short i = 0; i < size; i++) {//Cols
            for (short j = 0; j < size; j++) {//Rows
                if (arr[i, j] == '*') {
                    if (i == 0) {//Left side checking corners
                        if (j == 0) {//Checks top left 
                            arr[i + 1, j] = SetNum(arr[i + 1, j]);
                            arr[i, j + 1] = SetNum(arr[i, j + 1]);
                            arr[i + 1, j + 1] = SetNum(arr[i + 1, j + 1]);
                        }
                        else if (j == size - 1) {//Checks bottom left
                            arr[i + 1, j] = SetNum(arr[i + 1, j]);
                            arr[i, j - 1] = SetNum(arr[i, j - 1]);
                            arr[i + 1, j - 1] = SetNum(arr[i + 1, j - 1]);
                        }
                        else {//Checks left side
                            arr[i + 1, j] = SetNum(arr[i + 1, j]);
                            arr[i, j - 1] = SetNum(arr[i, j - 1]);
                            arr[i, j + 1] = SetNum(arr[i, j + 1]);
                        }
                    }
                    else if (i == size - 1) {//Right side checking corners
                        if (j == 0) {//Checks top right
                            arr[i - 1, j] = SetNum(arr[i - 1, j]);
                            arr[i, j + 1] = SetNum(arr[i, j + 1]);
                            arr[i - 1, j + 1] = SetNum(arr[i - 1, j + 1]);
                        }
                        else if (j == size - 1) {//Checks bottom right
                            arr[i - 1, j] = SetNum(arr[i - 1, j]);
                            arr[i, j - 1] = SetNum(arr[i, j - 1]);
                            arr[i - 1, j - 1] = SetNum(arr[i - 1, j - 1]);
                        }
                        else {//Checks right side
                            arr[i - 1, j] = SetNum(arr[i - 1, j]);
                            arr[i, j - 1] = SetNum(arr[i, j - 1]);
                            arr[i, j + 1] = SetNum(arr[i, j + 1]);
                        }
                    }
                    else if (j == 0) {//Checks top row
                        arr[i + 1, j] = SetNum(arr[i + 1, j]);
                        arr[i - 1, j] = SetNum(arr[i - 1, j]);
                        arr[i, j + 1] = SetNum(arr[i, j + 1]);
                    }
                    else if (j == size - 1) {//Checks bottom row
                        arr[i + 1, j] = SetNum(arr[i + 1, j]);
                        arr[i - 1, j] = SetNum(arr[i - 1, j]);
                        arr[i, j - 1] = SetNum(arr[i, j - 1]);
                    }
                    else {//Checks anything inside inner boundary
                        for (short k = -1; k < 2; k++) {
                            for (short l = -1; l < 2; l++) {
                                arr[i + k, j + l] = SetNum(arr[i + k, j + l]);
                                //DbgPrnt(arr, size); //For dbg
                                //Console.WriteLine(""); //for dbg

                            }
                        }
                    }
                }
            }
        }
    }

    /*
     *DbgInp - Debug input 
     * Purpose: Check to make sure the input works for all possible numerical inputs and checks adjcnt() func
     * Input: bool array, character array, bool array
     * Output: Void - only modifies array
     * 
     */

    public void DbgInp(bool[,] arr, char[,] arr2, bool[,] arr3, int size) {//Used to check adjcnt function
        for(short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                arr3[i, j] = true;//True that the position was picked
                Adjcnt(arr, arr2, i, j);
                PrntArr(arr2, arr, arr3, size);
            }
        }
    }

    /*
     * Input
     * Purpose: Used to get and validate user input and check lose condition
     * Input: bool array, character array, bool array
     * Output: Void - Only modifies array
     * 
     */

    public void Input(bool[,] arr, char [,] arr2, bool [,] pick) {//Input validation
        int x = -1;
        int y = -1;
        do {
            Console.Write("Enter your guess here: ");
            string inp = Console.ReadLine();
            if (inp == "exit" || inp == "Exit") {
                System.Environment.Exit(0);
            }
            char[] chars = inp.ToCharArray();
            for (short i = 0; i < chars.Length; i++) {
                if (chars[i] >= '0' && chars[i] <= '9') {
                    if (x < 0) {
                        x = chars[i] - '0';
                    }
                }
                else if (chars[i] >= 'A' && chars[i] <= 'J') {
                    if (y < 0) {
                        y = chars[i] - 'A';
                    }
                }
                else if (chars[i] >= 'a' && chars[i] <= 'j') {
                    if (y < 0) {
                        y = chars[i] - 'a';
                    }
                }
                if (y > 0 && x > 0) {
                    break;
                }
            }
        } while (x < 0 || y < 0);

        if (arr2[x, y] == '*') {//Lose condition
            Console.WriteLine("You lost! Better luck next time.");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
        pick[x, y] = true;//True that the position was picked
        Adjcnt(arr, arr2, x, y);
    }

    /*
     * SetNum - Set number
     * Purpose: Increments number in the character array
     * Input: Index of a character array
     * Output: Void - Only modifies array
     * 
     */

    public char SetNum(char pos) {//Increments character
        char tmp = '*';
        if (pos == '0') {//Need to do it this way to make sure its a character with in the bounds of the game vs doing char++ on anything
            tmp = '1';
        }
        if (pos == '1') {
            tmp = '2';
        }
        if (pos == '2') {
            tmp = '3';
        }
        if (pos == '3') {
            tmp = '4';
        }
        if (pos == '4') {
            tmp = '5';
        }
        if (pos == '5') {
            tmp = '6';
        }
        if (pos == '6') {
            tmp = '7';
        }
        if (pos == '7') {
            tmp = '8';
        }
        if (pos == '8') {
            tmp = '9';
        }
        return tmp;
    }

    /*
     * Adjcnt - Adjacent 
     * Purpose: Check the areas adjacent to the one picked by the user, if there is no bomb then make it true so that it prints the array to show the user
     * Input: boolean array, character array, integer position, integer position
     * Output: Void - Only modifies array
     */

    public void Adjcnt(bool[,] boolArr, char[,] charArr, int x, int y) {//x = i, y = j for reference
        int tmpx, tmpy;//Used to save me the time of editing a ton more lines
        tmpx = x;
        tmpy = y;
        if (!boolArr[x, y]) {
            if (x == 0) {//Left side checking corners
                if (y == 0) {//Checks top left i + 1, j + 1
                    tmpx = x + 1;//Resets after every change so they dont get mixed up
                    tmpy = y;//Same as above ^^
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x + 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom left i + 1, j - 1
                    tmpx = x + 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x + 1;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                else {//Checks left side i + 1, j +- 1
                    tmpx = x + 1;
                    tmpy = y;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x + 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x + 1;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
            }
            else if (x == (Math.Sqrt(charArr.Length) - 1)) {//Right side checking corners
                if (y == 0) {//Checks top right i - 1, j + 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (x), (y));
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (x), (y));
                    }
                    tmpx = x - 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom right i - 1, j - 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x - 1;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                else {//Checks right side i - 1, j +- 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x - 1;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                    tmpx = x - 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
            }
            else if (y == 0) {//Checks top row i +- 1, j + 1
                tmpx = x + 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x - 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x - 1;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x + 1;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
            }
            else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom row i +- 1, j - 1
                tmpx = x + 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x - 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x - 1;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
                tmpx = x + 1;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                }
            }
            else {//Checks anything inside inner (Math.Sqrt(charArr.Length) - 1)ary i +- 1, j +- 1
                for (short k = -1; k < 2; k++) {
                    for (short l = -1; l < 2; l++) {
                        if (!(charArr[x + k, y + l] == '*')) {
                            boolArr[x + k, y + l] = true;//True means tile shows when print function iterates
                            Adjcnt(boolArr, charArr, (x + k), (y + l));
                        }
                    }
                }
            }
        }
    }

    /*
     * ChckWin - Check Win
     * Purpose: Check if the player has won the game
     * Input: boolean array, short number of bombs
     * Output: Boolean - True if the player won, false if the player has not won yet
     * 
     */

    public bool ChckWin(bool[,] picks, short bombs) {
        short temp = 0;
        int bound = (int)Math.Sqrt(picks.Length); //Used to calculate boundary of a 2d array because otherwise its size^2
        for(short i = 0; i < bound; i++) {
            for(short j = 0; j < bound; j++) {
                if (!picks[i, j]) {
                    temp++;
                }
            }
        }
        if (temp == bombs) {
            return true;
        }
        else {
            return false;
        }
    }

    // <- - - - - - - - - - - -  Keep code above this - - - - - - - - - - - - - -> //
}