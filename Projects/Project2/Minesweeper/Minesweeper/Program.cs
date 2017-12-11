﻿using System;


//Minesweeper
//Need function that generates mines
//Need function to initialize arrays
//Need function to output arrays
//Need function that counts mines around the position that was chosen
//Need to implement everything for CSC-5 requirements
//Pre - generate board in mines array



class Program {
    static void Main() {
        //Set random seed
        Random rnd = new Random();

        //Declare variables
        int size = 10;//Testing purposes, change this to input later
        char[,] mines = new char[size, size];
        char[,] board = new char[size, size];

        initArr(mines, size);
        initArr(board, size);

        genMines(mines, rnd);
        genMines(mines, rnd);
        genMines(mines, rnd);

        prntArr(board, size);
        Console.WriteLine("");
        prntArr(mines, size);

        Console.ReadLine();
    }

    static void initArr(char[,] arr, int size) {
        for (short i = 0; i < size - 1; i++) {
            for (short j = 0; j < size - 1; j++) {
                arr[i, j] = '0';
            }
        }
    }

    static void genMines(char[,] arr, Random rnd) {
        arr[rnd.Next(0, 9), rnd.Next(0, 9)] = 'M';

    }

    static void prntArr(char[,] arr, int size) {
        for (short i = 0; i < size - 1; i++) {
            for (short j = 0; j < size - 1; j++) {
                Console.Write(arr[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine("");
        }
    }

}