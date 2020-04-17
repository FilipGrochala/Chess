using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan
{




    public override bool[,] PossibleMove()
    {
        ChessMan c1;

        bool[,] moves = new bool[8, 8];



        bool condition_left_up, condition_right_up, condition_left_down, contidion_right_down;
        bool hit_ru, hit_lu, hit_ld, hit_rd;
        hit_ru =hit_lu=hit_ld=hit_rd = true;

        int color = isWhite ? 1 : -1;
        int newX, newY;

        for (int i = 1; i < 8; i++)
        {
            newX = CurrentX - (i * color);
            newY = CurrentY + (i * color);
            condition_left_up = isWhite ? (CurrentX != 0 && CurrentY != 7 && newX >= 0 && newY <= 7) : (CurrentX != 0 && CurrentY != 0 && newX <= 7 && newY >= 0);

            if (condition_left_up && hit_lu) //ruch w lewo
            {

                if (newX >= 0 && newY <= 7)
                {

                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        hit_lu = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        hit_lu = false;
                    }
                }
            }

            newX = CurrentX + (i * color);
            newY = CurrentY + (i * color);
            condition_right_up = isWhite ? (CurrentX != 7 && CurrentY != 7 && newX <= 7 && newY <= 7) : (CurrentX != 7 && CurrentY != 0 && newX >= 0 && newY >= 0);

            if (condition_right_up && hit_ru) //ruch w prawo
            {
                 

                if (newX <= 7  && newY <= 7)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        hit_ru = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        hit_ru = false;
                    }
                }
            }
            newX = CurrentX - (i * color);
            newY = CurrentY - (i * color);
            condition_left_down = isWhite ? (CurrentX != 0 && CurrentY != 0 && newX >= 0 && newY >= 0) : (CurrentX != 7 && CurrentY != 7 && newX <= 7 && newY <= 7);

            if (condition_left_down && hit_ld) //ruch w górę
            {
                 

                if (newX >= 0 && newY >= 0)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        hit_ld = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        hit_ld = false;
                    }
                }
            }


            newX = CurrentX + (i * color);
            newY = CurrentY - (i * color);
            contidion_right_down = isWhite ? (CurrentX != 7 && CurrentY != 0 && newX <=7 && newY >=0) : (CurrentX != 0 && CurrentY != 7 && newX >= 0 && newY <= 7);

            if (contidion_right_down && hit_rd) //ruch w dół
            {

              

                if (newX <= 7 && newY >= 0)
                {
                    c1 = BoardManager.Instance.ChessMens[newX, newY];
                    if (c1 == null)
                        moves[newX, newY] = true;
                    if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                        hit_rd = false;
                    if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                    {
                        moves[newX, newY] = true;
                        hit_rd= false;
                    }
                }
            }


        }



        return moves;

    }

}
