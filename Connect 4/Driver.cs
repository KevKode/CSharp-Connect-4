using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Driver
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            System.Console.WriteLine("Welcome to C# Connect 4!\nEnter player 1s name...");
            String name1 = System.Console.ReadLine();
            System.Console.WriteLine("Enter player 2s name...");
            String name2 = System.Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Alright lets start!\n"+board.toString());

            int count = 1;
            while ((!board.getWinner()) && (!board.checkTie()))
            {
                if (count%2==1){play1(name1, board);}
                else {play2(name2, board);}

                //Console.Clear();
                System.Console.WriteLine("\n" + board.toString());
                sayRandom();
                count++;
            }

            if (board.checkTie()) { System.Console.WriteLine("Tie!"); }
            if (board.getWinner()) { System.Console.WriteLine("We have a winner!"); }

            String dummy = System.Console.ReadLine();
        }

        public static void play1(String name, Board board) 
        {
            System.Console.WriteLine(name + ", enter a column...(0-6)");
            String column = System.Console.ReadLine();
            int col = Convert.ToInt32(column);

            while ((col < 0 || col > 6) || (board.getFull(col)))
            {
                System.Console.WriteLine(name + ", enter a column...(0-6)");
                column = System.Console.ReadLine();
                col = Convert.ToInt32(column);
            }

            new Piece(col, " X ", board);
        }

        public static void play2(String name, Board board)
        {
            System.Console.WriteLine(name + ", enter a column...(0-6)");
            String column = System.Console.ReadLine();
            int col = Convert.ToInt32(column);

            while ((col < 0 || col > 6) || (board.getFull(col)))
            {
                System.Console.WriteLine(name + ", enter a column...(0-6)");
                column = System.Console.ReadLine();
                col = Convert.ToInt32(column);
            }

            new Piece(col, " O ", board);
        }
    
        public static void sayRandom()
        {
            Random r = new Random();
            int rand = r.Next(1, 5);

            if (rand == 1)
                System.Console.WriteLine("Wowie! Nice move!");
            else if (rand == 2)
                System.Console.WriteLine("Gee wiz! That was a smart move!");
            else if (rand == 3)
                System.Console.WriteLine("That move was the bee's knees!");
            else if (rand == 4)
                System.Console.WriteLine("Golly! With a move like that, you could be the king/queen of C# Connect 4!");
            else
                System.Console.WriteLine("Wowza! That move was tactical genius!");
        }
    }
}
