using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{


    public override bool[,] PossibleMove()
    {
        ChessMan c1;

        bool[,] moves = new bool[8, 8];

        int newX = 0; 
        int newY = 0;

        bool condition_left, condition_right, condition_up, condition_down;
        bool hit_left, hit_right, hit_up, hit_down;
        hit_left = hit_right = hit_up = hit_down = true;

        int color = isWhite ? 1 : -1;

        for (int i = 1; i < 8; i++)
        {
            newX = CurrentX - (color * i);
            newY = CurrentY;
            condition_left = isWhite ? (CurrentX != 0 && newX >= 0) : (CurrentX != 7 && newX >=7);

            if (condition_left  && hit_left ) //ruch w lewo
            {

                c1 = BoardManager.Instance.ChessMens[CurrentX - (color * i), CurrentY];
                if (c1 == null)
                    moves[newX, newY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    hit_left = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[newX, newY] = true;
                    hit_left = false;
                }
            }

            newX = CurrentX + (color * i);
            newY = CurrentY;
            condition_right = isWhite ? (CurrentX != 7 && newX <= 7) : (CurrentX != 0 && newX >= 0);

            if (condition_right && hit_right)  //ruch w prawo
            {
                c1 = BoardManager.Instance.ChessMens[newX, newY];
                if (c1 == null)
                    moves[newX, newY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    hit_right = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[newX, newY] = true;
                    hit_right = false;
                }
            }

            newX = CurrentX ;
            newY = CurrentY + (color * i);
            condition_up = isWhite ? (CurrentY != 7 && newY <= 7) : (CurrentY != 0 && newY >=0);

            if (condition_up && hit_up) //ruch w górę
            {
                c1 = BoardManager.Instance.ChessMens[newX, newY];
                if (c1 == null)
                    moves[newX, newY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    hit_up = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[newX, newY] = true;
                    hit_up = false;
                }
            }
            newX = CurrentX;
            newY = CurrentY - (color * i);
            condition_down = isWhite ? (CurrentY != 0 && newY >= 0) : (CurrentY != 7 && newY <= 0);

            if (condition_down && hit_down) //ruch w dół
            {
                c1 = BoardManager.Instance.ChessMens[newX, newY];
                if (c1 == null)
                    moves[newX, newY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    hit_down = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[newX, newY] = true;
                    hit_down = false;
                }
            }


        }


        return moves;

    }



    


}
