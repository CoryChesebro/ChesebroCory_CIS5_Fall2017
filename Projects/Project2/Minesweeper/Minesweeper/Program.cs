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
        Program prg = new Program();

        //Declare variables
        int size = 10;//Testing purposes, change this to input later

        char[,] mines = new char[size, size];
        bool[,] board = new bool[size, size];

        prg.InitArr(board, size);

        prg.GenMines(mines, rnd);
        prg.GenMines(mines, rnd);
        prg.GenMines(mines, rnd);
        int temp = 10;
        do {
            prg.Input(ref board);
            prg.PrntArr(mines, board, size);
            temp--;
        } while (temp > 0);
        Console.ReadLine();
    }

    public void InitArr(bool[,] arr, int size) {
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = false;
            }
        }
    }

    public void GenMines(char[,] arr, Random rnd) {
        int temp1, temp2;
        temp1 = rnd.Next(0, 9);
        temp2 = rnd.Next(0, 9);
        arr[temp1, temp2] = '*';
        Console.Write(temp1.ToString());
        Console.WriteLine(temp2.ToString());

    }

    public void PrntArr(char[,] arr, bool [,] arr2, int size) {
        Console.Clear();
        for (short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                if (arr2[i, j] == false) {
                    Console.Write('X');
                    Console.Write(" ");
                }
                else if (arr[i,j] == '*') {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else {
                    //Console.Write(arr[i, j]);
                    Console.Write("  ");
                }
            }
            Console.WriteLine("");
        }
    }

    public void MakeBrd(char[,] arr, int size) {//For use later
        for (short i = 0; i < size; i++) {//Cols
            for (short j = 0; j < size; j++) {//Rows
                if (arr[i, j] == '*') {

                }
            }
        }
    }

    public void Input(ref bool [,] arr) {
        int x = -1;
        int y = -1;
        do {
            Console.Write("Enter your guess here: ");
            string inp = Console.ReadLine();
            char [] chars = inp.ToCharArray();
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
// <- - - - - - - - - - - -  Keep code above this - - - - - - - - - - - - - -> //
}
    