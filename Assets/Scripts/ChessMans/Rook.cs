using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{
    bool[] hits = new bool[4];

    public override bool[,] PossibleMove()
    {
        bool[,] moves = new bool[8, 8];
        RookMovement(moves, isWhite, CurrentX, CurrentY, this);

        return moves;

    }

    public void RookMovement(bool[,] _moves,bool _isWhite,int _CurrentX, int _CurrentY, ChessMan chess)
    {
        for (int i = 0; i < hits.Length; i++)
            hits[i] = true;

 
        int newX = 0;
        int newY = 0;

        bool condition_left, condition_right, condition_up, condition_down;

       
        

        int color = _isWhite ? 1 : -1;

        for (int i = 1; i < 8; i++)
        {
            newX = _CurrentX - (color * i);
            newY = _CurrentY;
            condition_left = _isWhite ? (_CurrentX != 0 && newX >= 0) : (_CurrentX != 7 && newX >= 7); //ustalanie warunku ograniczającego

            if (condition_left && hits[0]) //ruch w lewo
            {
                CheckMove(chess,_moves,newX,newY, 0);
               
            }
            
            newX = _CurrentX + (color * i);
            newY = _CurrentY;
            condition_right = _isWhite ? (_CurrentX != 7 && newX <= 7) : (_CurrentX != 0 && newX >= 0);

            if (condition_right && hits[1])  //ruch w prawo
            {
                CheckMove(chess, _moves, newX, newY, 1);
            }

            newX = _CurrentX;
            newY = _CurrentY + (color * i);
            condition_up = _isWhite ? (_CurrentY != 7 && newY <= 7) : (_CurrentY != 0 && newY >= 0);

            if (condition_up && hits[2]) //ruch w górę
            {
                CheckMove(chess, _moves, newX, newY, 2);
            }

            newX = _CurrentX;
            newY = _CurrentY - (color * i);
            condition_down = _isWhite ? (_CurrentY != 0 && newY >= 0) : (_CurrentY != 7 && newY <= 0);

            if (condition_down && hits[3]) //ruch w dół
            {
                CheckMove(chess, _moves, newX, newY, 3);
            }


        }

    }

    private void CheckMove(ChessMan current_chess, bool[,] arr, int _newX, int _newY,int hit)
    {

        ChessMan c;
        c = BoardManager.Instance.ChessMens[_newX, _newY];
        if (c == null)
            arr[_newX, _newY] = true;
        if (c != null && current_chess.isWhite == c.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
            hits[hit] = false;
        if (c != null && current_chess.isWhite != c.isWhite) //jeśli na lini jest przeciwnik zbij go
        {
            arr[_newX, _newY] = true;
            hits[hit] = false;
        }

    }






}
