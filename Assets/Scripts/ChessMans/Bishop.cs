using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan
{




    public override bool[,] PossibleMove()
    {
        ChessMan c1;

        bool[,] moves = new bool[8, 8];



        bool condition_left_up = isWhite ? (CurrentX != 0 && CurrentY != 7) : (CurrentX != 0 && CurrentY != 0);
        bool condition_right_up = isWhite ? (CurrentX != 7 && CurrentY != 7) : (CurrentX != 7 && CurrentY != 0);
        bool condition_left_down = isWhite ? CurrentX != 0 && CurrentY != 0 : CurrentX != 7 && CurrentY != 7;
        bool condition_right_down = isWhite ? CurrentX != 7 && CurrentY != 0 : CurrentX != 0 && CurrentY != 7;

        int color = isWhite ? 1 : -1;
        int newX, newY;

        for (int i = 1; i < 8; i++)
        {

            if (condition_left_up) //ruch w lewo
            {
                
                 newX = CurrentX - (i * color);
                 newY = CurrentY + (i * color);

                if (newX >= 0 && newY <= 7)
                {

                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        condition_left_up = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        condition_left_up = false;
                    }
                }
            }

            if (condition_right_up) //ruch w prawo
            {
                 newX = CurrentX + (i * color);
                 newY = CurrentY + (i * color);

                if (newX <= 7  && newY <= 7)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        condition_left_up = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        condition_left_up = false;
                    }
                }
            }
            if (condition_left_down) //ruch w górę
            {
                 newX = CurrentX - (i * color);
                 newY = CurrentY - (i * color);

                if (newX >= 0 && newY >= 0)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        condition_left_up = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        condition_left_up = false;
                    }
                }
            }
            if (condition_right_down) //ruch w dół
            {

                newX = CurrentX + (i * color);
                newY = CurrentY - (i * color);

                if (newX <= 7 && newY >= 0)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        condition_left_up = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        condition_left_up = false;
                    }
                }
            }


        }



        return moves;

    }

}
