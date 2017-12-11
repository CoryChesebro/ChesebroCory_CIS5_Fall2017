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
        char[,] board = new char[size, size];

        prg.InitArr(mines, size);
        prg.InitArr(board, size);

        prg.GenMines(mines, rnd);
        prg.GenMines(mines, rnd);
        prg.GenMines(mines, rnd);

        prg.PrntArr(board, size);
        Console.WriteLine("");
        prg.PrntArr(mines, size);

        Console.ReadLine();
    }

    public void InitArr(char[,] arr, int size) {
        for (short i = 0; i < size; i++) {
            for (short j = 0; j < size; j++) {
                arr[i, j] = 'X';
            }
        }
    }

    public void GenMines(char[,] arr, Random rnd) {
        int temp1, temp2;
        temp1 = rnd.Next(0, 9);
        temp2 = rnd.Next(0, 9);
        arr[temp1, temp2] = '-';
        Console.Write(temp1.ToString());
        Console.WriteLine(temp2.ToString());

    }

    public void PrntArr(char[,] arr, int size) {
        for (short i = 0; i < size; i++) {
            for(short j = 0; j < size; j++) {
                Console.Write(arr[i, j]);
                Console.Write("");
            }
            Console.WriteLine("");
        }
    }

    public void MakeBrd(char[,] arr, int size) {

    }

// - - - - - - - - - Keep code above this - - - - - - - - - - - - - -
}
    