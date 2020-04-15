using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const float tile_size = 1f; // rozmiar pola
    private const float tile_offset = 0.5f; // margines pola

    private int selectedX = -1; //wybrane pole
    private int selectedY = -1;

    private void Update()
    {
        UpdateSelection();
        DrawChessboard();
        
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
            LayerMask.GetMask("ChessPlane")))
            {
            Debug.Log(hit.point);
            }
    }
    private void DrawChessboard()
    {
        Vector3 width_line = Vector3.right * 8;
        Vector3 height_line = Vector3.forward * 8;

        for(int i = 0; i<=8;i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + width_line);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * i;
                Debug.DrawLine(start, start + height_line);
            }
        }
    }


}
