using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour
{
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }

    public bool isWhite;

    public void SetPosition(int x,int y)
    {
        CurrentX = x;
        CurrentX = y;
    }
    public virtual bool PossibleMove(int x, int y) //virtual oznacza że klasa może zosta nadpisana
    {
        return true;
    }

}
