using System;


//Minesweeper
//Need function that generates mines
//Need function to initialize arrays
//Need function to output arrays
//Need function that counts mines around the position that was chosen
//Pre - generate board in mines array
//Implement flags, score, name, difficulties
// IsAdjacent function to control spread, have it check if there is an X adjacent to and change it to green and true so it shows as clean on next print

class Program {
    static void Main() {
        //Set random seed / Instatiate Oject
        Random rnd = new Random();
        Game game = new Game();

        //Declare variables
        short size = 10;//Testing purposes, change this to input later
        short num = 25 ;//Number of bombs, change to input later
        char[,] mines = new char[size, size];
        bool[,] board = new bool[size, size];

        game.InitArr(board, size);
        game.InitArr(mines, size);

        game.GenMines(mines, rnd, num);

        game.MakeBrd(mines, size);
        game.DbgPrnt(mines, size);
        
        
        int temp = 10;
        do {
            game.Input(board);
            game.PrntArr(mines, board, size);
            temp--;
        } while (temp > 0);
    
        Console.ReadLine();
    }
}

class Game { 
    public void InitArr(char[,] arr, int size) {
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = '0';
            }
        }
    }

    public void InitArr(bool[,] arr, int size) {
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = false;
            }
        }
    }

    public void GenMines(char[,] arr, Random rnd, short num) {
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

    public void DbgPrnt(char [,] arr, int size) {
        //Console.Clear();
        for(short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                if(arr[i,j] == '0') {
                    Console.Write('X');
                    Console.Write(" ");
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

    public void PrntArr(char[,] arr, bool[,] arr2, int size) {
        Console.Clear();
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                if (arr2[i, j] == false) {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else if (arr[i, j] == '*') {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else {
                    Console.Write("  ");
                }
            }
            Console.WriteLine("");
        }
    }

    public void MakeBrd(char[,] arr, int size) {//Find bombs and check around them, watch for other bombs and out of bounds of the array
        for (short i = 0; i < size; i++) {//Cols
            for (short j = 0; j < size; j++) {//Rows
                if (arr[i, j] == '*') {
                    if (i == 0) {//Left side checkig corners
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
                        for(short k = -1; k < 2; k++) {
                            for(short l = -1; l < 2; l++) {
                                if(!(i == 0) && !(j == 0)) {
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
    }

    public void Input(bool[,] arr) {//Super validation
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
                    else {
                        y = chars[i] - '0'; break;
                    }
                }
            }
        } while (x < 0 || y < 0);
        arr[x, y] = true;//True that the position was picked

    }

    public char SetNum(char pos) {//Increments character
        char tmp = '*';

        if (pos == '0') {
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
    
    public void Adjcnt() {

    }

    // <- - - - - - - - - - - -  Keep code above this - - - - - - - - - - - - - -> //
}