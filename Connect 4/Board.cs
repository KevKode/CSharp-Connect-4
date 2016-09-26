using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Board
    {
        private String[,] board=new String[6,7];
        private bool full0;
        private bool full1;
        private bool full2;
        private bool full3;
        private bool full4;
        private bool full5;
        private bool full6;
        private bool winner;

        public Board() 
        {
            for (int x = 0; x < 6; x++) 
            {
                for (int y = 0; y < 7; y++)
                {
                    board[x, y] = "   ";
                }
            }
        }
        public String toString()
        { 
            String s="  0  1  2  3  4  5  6\n";

            for (int x = 0; x < 6; x++)
            {
                s += "|";
                for (int y = 0; y < 7; y++)
                {
                    s=s+board[x, y];
                }
                s = s + "|\n";
            }

            s += " _____________________ ";

            return s;
        }
        public bool checkTie()
        {
            if (full0 && full1 && full2 && full3 && full4 && full5 && full6)
                return true;
            return false;
        }
        public void checkWinner(int row, int col) 
        {
            String horo="";
            String vert="";
            String negdiag="";
            String posdiag="";
            int startxneg = row - Math.Min(row, col);
            int startyneg = col - Math.Min(row, col);
            int startxpos;
            int startypos = 0;

            if (row + col > 5)
            {
                startxpos = 5;
                startypos = (row + col) - 5;
            }
            else
                startxpos = row + col;

            for (int x=0; x<7; x++)
                horo += board[row, x];
            for (int x = 0; x < 6; x++)
                vert += board[x, col];
            while (startxneg <= 5 && startyneg <= 6)
            {
                negdiag += board[startxneg, startyneg];
                startxneg++;
                startyneg++;
            }

            while (startxpos>=0 && startypos<=6)
            {
                posdiag += board[startxpos, startypos];
                startxpos--;
                startypos++;
            }

           // System.Console.WriteLine(horo+"\n"+vert+"\n"+posdiag+"\n"+negdiag);

            if (horo.IndexOf(" X  X  X  X ") != -1 || horo.IndexOf(" O  O  O  O ") != -1)
                winner = true;
            if (vert.IndexOf(" X  X  X  X ") != -1 || vert.IndexOf(" O  O  O  O ") != -1)
                winner = true;
            if (posdiag.IndexOf(" X  X  X  X ") != -1 || posdiag.IndexOf(" O  O  O  O ") != -1)
                winner = true;
            if (negdiag.IndexOf(" X  X  X  X ") != -1 || negdiag.IndexOf(" O  O  O  O ") != -1)
                winner = true;
        }
        public bool getWinner() { return winner; }
        public bool getFull(int col)
        {
            if (col == 6)
                return full6;
            else if (col == 5)
                return full5;
            else if (col == 4)
                return full4;
            else if (col == 3)
                return full3;
            else if (col == 2)
                return full2;
            else if (col == 1)
                return full1;
            else
                return full0;
        }
        public void setFull(int col) 
        {
            if (col == 6)
                full6 = true;
            else if (col == 5)
                full5 = true;
            else if (col == 4)
                full4 = true;
            else if (col == 3)
                full3 = true;
            else if (col == 2)
                full2 = true;
            else if (col == 1)
                full1 = true;
            else
                full0 = true;
        }
        public String[,] getBoard() { return board; }
        public void setBoard(int x, int y, String name)
        {
            board[x, y] = name;
        }
    }
}
