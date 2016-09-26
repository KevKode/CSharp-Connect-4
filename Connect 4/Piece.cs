using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    class Piece
    {
        public Piece(int col, String name, Board board) 
        {
            
            for (int x = 5; x > -1; x--)
            { 
                if (board.getBoard()[x, col] == "   ")
                {
                    board.setBoard(x, col, name);
                    board.checkWinner(x, col);
                    break;
                }

                if (board.getBoard()[1, col] != "   ")
                {
                    board.setFull(col);
                }
            }
        }
    }
}
