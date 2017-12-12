using System;


//Minesweeper
//Need function that generates mines
//Need function to initialize arrays
//Need function to output arrays
//Need function that counts mines around the position that was chosen
//Need to implement everything for CSC-5 requirements
//Pre - generate board in mines array

class Program {
    static void Main() {
        //Set random seed / Instatiate Oject
        Random rnd = new Random();
        Game game = new Game();

        //Declare variables
        int size = 10;//Testing purposes, change this to input later

        char[,] mines = new char[size, size];
        bool[,] board = new bool[size, size];

        game.InitArr(board, size);
        game.InitArr(mines, size);

        game.GenMines(mines, rnd);
        game.GenMines(mines, rnd);
        game.GenMines(mines, rnd);

        game.MakeBrd(mines, size);
        game.DbgPrnt(mines, size);
        
        /*
        int temp = 10;
        do {
            game.Input(ref board);
            game.PrntArr(mines, board, size);
            temp--;
        } while (temp > 0);
        */
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

    public void GenMines(char[,] arr, Random rnd) {
        bool dup = false;
        do {
            int temp1, temp2;

            temp1 = rnd.Next(0, 9);
            temp2 = rnd.Next(0, 9);

            if (arr[temp1, temp2] == '*') {
                dup = true;
            }
            else {
                arr[temp1, temp2] = '*';
                dup = false;
            }

        } while (dup);

    }

    public void DbgPrnt(char [,] arr, int size) {
        Console.Clear();
        for(short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                if(arr[i,j] == '0') {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else {
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
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
                    else if (j == 0) {
                        arr[i + 1, j] = SetNum(arr[i + 1, j]);
                        arr[i - 1, j] = SetNum(arr[i - 1, j]);
                        arr[i, j + 1] = SetNum(arr[i, j + 1]);
                    }
                    else if (j == size - 1) {
                        arr[i + 1, j] = SetNum(arr[i + 1, j]);
                        arr[i - 1, j] = SetNum(arr[i - 1, j]);
                        arr[i, j - 1] = SetNum(arr[i, j - 1]);
                    }
                    else {//Checks anything inside inner boundary
                        arr[i - 1, j] = SetNum(arr[i - 1, j]);
                        arr[i - 1, j + 1] = SetNum(arr[i - 1, j + 1]);
                        arr[i - 1, j - 1] = SetNum(arr[i - 1, j + 1]);
                        arr[i + 1, j] = SetNum(arr[i + 1, j]);
                        arr[i + 1, j + 1] = SetNum(arr[i + 1, j + 1]);
                        arr[i + 1, j - 1] = SetNum(arr[i + 1, j - 1]);
                        arr[i, j - 1] = SetNum(arr[i, j - 1]);
                        arr[i, j + 1] = SetNum(arr[i, j + 1]);
                    }
                }
            }
        }
    }

    public void Input(ref bool[,] arr) {//Super validation
        int x = -1;
        int y = -1;
        do {
            Console.Write("Enter your guess here: ");
            string inp = Console.ReadLine();
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

    public char SetNum(char pos) {
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

    // <- - - - - - - - - - - -  Keep code above this - - - - - - - - - - - - - -> //
}