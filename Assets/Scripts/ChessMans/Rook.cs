using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{


    public override bool[,] PossibleMove()
    {
        ChessMan c1;

        bool[,] moves = new bool[8, 8];



        bool condition_left = isWhite ? CurrentX != 0 : CurrentX != 7;
        bool condition_right = isWhite ? CurrentX != 7 : CurrentX != 0;
        bool condition_up = isWhite ? CurrentY != 7 : CurrentY != 0;
        bool condition_down = isWhite ? CurrentY != 0 : CurrentY != 7;

        int color = isWhite ? 1 : -1;

        for (int i = 1; i < 8; i++)
        {
            

            if (condition_left) //ruch w lewo
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX - (color * i), CurrentY];
                if (c1 == null)
                    moves[CurrentX - (color * i), CurrentY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    condition_left = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[CurrentX - (color * i), CurrentY] = true;
                    condition_left = false;
                }
            }
            if (condition_right) //ruch w prawo
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX + (color * i), CurrentY];
                if (c1 == null)
                    moves[CurrentX + (color * i), CurrentY] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    condition_right = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[CurrentX + (color * i), CurrentY] = true;
                    condition_right = false;
                }
            }
            if (condition_up) //ruch w górę
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY + (color * i)];
                if (c1 == null)
                    moves[CurrentX, CurrentY + (color * i)] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    condition_up = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[CurrentX, CurrentY + (color * i)] = true;
                    condition_up = false;
                }
            }
            if (condition_down) //ruch w dół
            {
                c1 = BoardManager.Instance.ChessMens[CurrentX, CurrentY - (color)];
                if (c1 == null)
                    moves[CurrentX, CurrentY - (color)] = true;
                if (c1 != null && this.isWhite == c1.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
                    condition_down = false;
                if (c1 != null && this.isWhite != c1.isWhite) //jeśli na lini jest przeciwnik zbij go
                {
                    moves[CurrentX, CurrentY - (color * i)] = true;
                    condition_down = false;
                }
            }


        }
        



        return moves;

    }



    


}
