using System;
using System.Linq;

//Minesweeper
//Need function that generates mines
//Need function to initialize arrays
//Need function to output arrays
//Need function that counts mines around the position that was chosen
//Pre - generate board in mines array
//Implement flags, score, name, difficulties
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

        bool[,] board = new bool[size, size];
        char[,] mines = new char[size, size];
        bool[,] picks = new bool[size, size];

        game.InitArr(board, size);
        game.InitArr(picks, size);
        game.InitArr(mines, size);

        game.GenMines(mines, rnd, num);

        game.MakeBrd(mines, size);
        game.DbgPrnt(mines, size);

        
        int temp = 10;
        do {
            game.Input(board, mines, picks);
            game.PrntArr(mines, board, picks, size);
            game.DbgPrnt(mines, size);
            temp--;
        } while (temp > 0);
        
        //game.DbgInp(board, mines, picks);
        Console.ReadLine();
    }
}

class Game {
    Program prg = new Program();
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
                else if (arr[i, j] == '0') {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
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

    public void PrntArr(char[,] arr, bool[,] arr2, bool[,] arr3, int size) {
        Console.Clear();
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                if (!arr3[i, j]) {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else if (arr[i, j] == '*') {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(arr[i, j]);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                else {
                    if (arr2[i, j]) {
                        if (arr[i, j] == '0') {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("-");
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                        else if (arr2[i, j] && arr[i, j] == '1') {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '2') {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '3') {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '4') {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '5') {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '6') {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '7') {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (arr2[i, j] && arr[i, j] == '8') {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(arr[i, j]);
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else {
                            Console.Write('X');
                            Console.Write(" ");
                        }
                    }
                }

            }
            Console.WriteLine("");
        }
    }

    public void MakeBrd(char[,] arr, int size) {//Find bombs and check around them, watch for other bombs and out of (Math.Sqrt(charArr.Length) - 1)s of the array
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
                    else {//Checks anything inside inner (Math.Sqrt(charArr.Length) - 1)ary
                        for(short k = -1; k < 2; k++) {
                            for(short l = -1; l < 2; l++) {
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

    public void DbgInp(bool[,] arr, char[,] arr2, bool[,] arr3) {//Used to check adjcnt function
        for(short i = 0; i < 10; i++) {
            for(short j = 0; j < 10; j++) {
                arr3[i, j] = true;//True that the position was picked
                Adjcnt(arr, arr2, i, j);
                PrntArr(arr2, arr, arr3, 10);
            }
        }
    }

    public void Input(bool[,] arr, char [,] arr2, bool [,] arr3) {//Super validation
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
        arr3[x, y] = true;//True that the position was picked
        Adjcnt(arr, arr2, x, y);
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

    public void Adjcnt(bool[,] boolArr, char[,] charArr, int x, int y) {//x = i, y = j for reference
        int tmpx, tmpy;//Used to save me the time of editing a ton more lines
        tmpx = x;
        tmpy = y;
        if (!boolArr[x, y]) {
            if (x == 0) {//Left side checking corners
                if (y == 0) {//Checks top left i + 1, j + 1
                    tmpx = x + 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x + 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
                else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom left i + 1, j - 1
                    tmpx = x + 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x + 1;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
                else {//Checks left side i + 1, j +- 1
                    tmpx = x + 1;
                    tmpy = y;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x + 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x + 1;
                    tmpy = y - 1;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
            }
            else if (x == (Math.Sqrt(charArr.Length) - 1)) {//Right side checking corners
                if (y == 0) {//Checks top right i - 1, j + 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[x, y] == '*')) {
                        boolArr[x, y] = true;//True means tile shows when print function iterates
                        if (charArr[x, y] == '0') {
                            Adjcnt(boolArr, charArr, (x), (y));
                        }
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (x), (y));
                        }
                    }
                    tmpx = x - 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
                else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom right i - 1, j - 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x - 1;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
                else {//Checks right side i - 1, j +- 1
                    tmpx = x - 1;
                    tmpy = y;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x - 1;
                    tmpy = y - 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                    tmpx = x - 1;
                    tmpy = y + 1;
                    if (!(charArr[tmpx, tmpy] == '*')) {
                        boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                        if (charArr[tmpx, tmpy] == '0') {
                            Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                        }
                    }
                }
            }
            else if (y == 0) {//Checks top row i +- 1, j + 1
                tmpx = x + 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x - 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x - 1;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x + 1;
                tmpy = y + 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
            }
            else if (y == (Math.Sqrt(charArr.Length) - 1)) {//Checks bottom row i +- 1, j - 1
                tmpx = x + 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x - 1;
                tmpy = y;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x - 1;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
                tmpx = x + 1;
                tmpy = y - 1;
                if (!(charArr[tmpx, tmpy] == '*')) {
                    boolArr[tmpx, tmpy] = true;//True means tile shows when print function iterates
                    if (charArr[tmpx, tmpy] == '0') {
                        Adjcnt(boolArr, charArr, (tmpx), (tmpy));
                    }
                }
            }
            else {//Checks anything inside inner (Math.Sqrt(charArr.Length) - 1)ary i +- 1, j +- 1
                for (short k = -1; k < 2; k++) {
                    for (short l = -1; l < 2; l++) {
                        if (!(charArr[x + k, y + l] == '*')) {
                            boolArr[x + k, y + l] = true;//True means tile shows when print function iterates
                            if (charArr[x + k, y + l] == '0') {
                                Adjcnt(boolArr, charArr, (x + k), (y + l));
                            }
                        }
                    }
                }
            }
        }
    }
    // <- - - - - - - - - - - -  Keep code above this - - - - - - - - - - - - - -> //
}