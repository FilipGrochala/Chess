using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessMan
{
    

    public override bool[,] PossibleMove()
    {
        ChessMan c1, c2;

        bool[,] moves = new bool[8, 8];
        bool firstmove = true;
        

        //białe
        #region
        if (isWhite)
        {
            //bicie w lewo
            if(CurrentX != 0 && CurrentX !=7)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX - 1, CurrentY + 1];
                if (c1 != null && !c1.isWhite)
                    moves[CurrentX - 1, CurrentY + 1] = true;

            }

            //bisie w prawo
            if (CurrentX != 0 && CurrentX != 7)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX + 1, CurrentY + 1];
                if (c1 != null && !c1.isWhite)
                    moves[CurrentX + 1, CurrentY + 1] = true;
            }


            //przód
            if (CurrentY!=1)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY + 1];
                if (c1 == null) 
                    moves[CurrentX, CurrentY+1] = true;
            }

            //pierwszy ruch
            if (CurrentY==1)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.ChessMens[CurrentX, CurrentY + 2];
                if (c1 == null && c2==null)
                {
                    moves[CurrentX, CurrentY + 2] = true;
                }
            }
        }
        #endregion

        //czarne
        #region
        else
        {
            //bicie w lewo
            if (CurrentX != 0 && CurrentX != 7)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX + 1, CurrentY - 1];
                if (c1 != null && !c1.isWhite)
                    moves[CurrentX + 1, CurrentY - 1] = true;

            }

            //bisie w prawo
            if (CurrentX != 0 && CurrentX != 7)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX - 1, CurrentY - 1];
                if (c1 != null && !c1.isWhite)
                    moves[CurrentX - 1, CurrentY - 1] = true;
            }


            //przód
            if (CurrentY!=6)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY - 1];
                if (c1 == null)
                    moves[CurrentX, CurrentY - 1] = true;
            }

            //pierwszy ruch
            if (CurrentY==6)
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY - 2];
                if (c1 == null)
                {
                    moves[CurrentX, CurrentY - 2] = true;
                    
                }
            }
        }
            #endregion

            return moves;
    }

}
