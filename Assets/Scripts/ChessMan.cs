using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour
{
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }

    public bool isWhite;

    public bool firstmove = true; 


    public void SetPosition(int x,int y)
    {
        CurrentX = x;
        CurrentY = y;
    }
    public virtual bool[,] PossibleMove() //virtual oznacza że klasa może zosta nadpisana
    {
        return new bool[8,8];
    }

    public static void CheckMove(ChessMan current_chess, bool[,] arr, int _newX, int _newY, bool[] _hits, int hit)
    {

        ChessMan c;
        c = BoardManager.Instance.ChessMens[_newX, _newY];
        if (c == null)
            arr[_newX, _newY] = true;
        if (c != null && current_chess.isWhite == c.isWhite) //jeśli na lini jest sojusznik nie można ruszyć dalej
            _hits[hit] = false;
        if (c != null && current_chess.isWhite != c.isWhite) //jeśli na lini jest przeciwnik zbij go
        {
            arr[_newX, _newY] = true;
            _hits[hit] = false;
        }

    }




}
