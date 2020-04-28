using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System;

public class BoardManager : MonoBehaviour
{



    public static BoardManager Instance { get; set; }
    private bool[,] allowedMoves;

    public ChessMan[,] ChessMens { get; set; }
    public ChessMan SelectedChessman;

   

    public int selectedX = -1; //wybrane pole
    public int selectedY = -1;


    public bool isWhiteTurn = true; //czyja kolej?
    int number_of_move = 0;

    [SerializeField]
    CardManager WhiteDeck;
    [SerializeField]
    CardManager BlackDeck;


    private void Start()
    {
        Instance = this;
        ChessMens = new ChessMan[8, 8];
        WhiteDeck.UpdateSpawn(ChessMens);
        BlackDeck.UpdateSpawn(ChessMens);
    }
    private void Update()
    {
        UpdateSelection();
        DrawChessboard();
       

        if (Input.GetMouseButtonDown(0)) //wduszenie lewego przycisku myszy
        {
            if (selectedX >= 0 || selectedY >= 0) //sprawdzenie czy kliknięto na planszy
            {
                if (SelectedChessman == null) //jeśli nic nie wybrano wybierz danego piona 
                {
                    try
                    {
                        SelectChessman(selectedX, selectedY);
                    }
                    catch (Exception e)
                    {

                    }
                }
                else //jeśli wcześniej wybrano piona rusz nim na wybrane pole
                {
                    MoveChessman(selectedX, selectedY);
                }

            }
        }

    }

    private void MoveChessman(int x, int y)
    {
        if (allowedMoves[x, y]) // można wykonać taki ruch?
        {
            ChessMan target = ChessMens[x, y];


            if (target != null && target.isWhite != isWhiteTurn) //czy na wybranym polu jest figura i czy należy do gracza?
            {
                KillChessMan(target);
            }

            ChessMens[SelectedChessman.CurrentX, SelectedChessman.CurrentY] = null; //wybrany pion 'znika' z aktualnej pozycji
            SelectedChessman.transform.position = GetTileCenter(x, y);
            SelectedChessman.SetPosition(x, y);
            ChessMens[x, y] = SelectedChessman;
            UpdateMove();

            if (SelectedChessman.firstmove) //wykonanie pierwszego ruchu potrzebne przy pionach
                SelectedChessman.firstmove = false;


        }
        BoardHighlitghs.Instance.HideAll();
        SelectedChessman = null; //klinięcie w inne niż możliwe miejsce anuluje wybór


    }

    private void KillChessMan(ChessMan target)
    {
        if (target.GetType() == typeof(King)) //jeśli to król zakończ grę
        {
            Endgame();
            
        }
        //usunięcie z listy aktywnych figur
        Destroy(target.gameObject); //zniszczenie figury
    }

    private void SelectChessman(int x, int y)
    {
        if (ChessMens[x, y] == null) //sprawdzenie czy na wybranej pozycji jest pion
            return;
        if (ChessMens[x, y].isWhite != isWhiteTurn) //sprawdzenie czy pion ma kolor danego gracza
            return;

        SelectedChessman = ChessMens[x, y];

        allowedMoves = ChessMens[x, y].PossibleMove();
        BoardHighlitghs.Instance.HighlightAllowedMoves(allowedMoves);


    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;

        if (Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out hit,
            25.0f,
            LayerMask.GetMask("ChessPlane"))) //warunek określający nad jakim polem gracz ma umieszczoną myszkę
        {
            selectedX = (int)hit.point.x;
            selectedY = (int)hit.point.z;
        }
        else
        {
            selectedX = -1;
            selectedX = -1;
        }

    }
    private void DrawChessboard() //pomocnicza funkcja rysująca pole
    {
        Vector3 width_line = Vector3.right * 8;
        Vector3 height_line = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + width_line);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * i;
                Debug.DrawLine(start, start + height_line);
            }
        }

        if (selectedX >= 0 && selectedY >= 0) //coś zaznaczono
        {
            Debug.DrawLine(
                Vector3.forward * selectedY + Vector3.right * selectedX,
                Vector3.forward * (selectedY + 1) + Vector3.right * (selectedX + 1));
        }
    }

    


    private Vector3 GetTileCenter(int x, int y) //umieszczanie figury na środku danego pola
    {
        Vector3 origin = Vector3.zero;
        origin.x += (1 * x) + 0.5f; //ustawianie na  srodku
        origin.z += (1 * y) + 0.5f;
        return origin;
    }

    

    public void UpdateMove() //funkcja przełącza aktywnego gracza
        {
            if (number_of_move < 2) 
            number_of_move++;

            if (number_of_move == 2)
            {
            isWhiteTurn = !isWhiteTurn;
            number_of_move = 0;
            }

        
        }

    private void Endgame()
    {
     
        Debug.Log("Wygrana!");
    }
    


}
