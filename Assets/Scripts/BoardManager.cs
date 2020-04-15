using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    private const float tile_size = 1f; // rozmiar pola
    private const float tile_offset = 0.5f; // margines pola

    private int selectedX = -1; //wybrane pole
    private int selectedY = -1;

    [SerializeField]
    List<GameObject> chessmanPrefabs;

    private List<GameObject> active_chessmanPrefabs;
    private void Start()
    {
        SpawnAllChessMans();
    }
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

        if(selectedX >= 0 && selectedY >=0) //coś zaznaczono
        {
            Debug.DrawLine(
                Vector3.forward * selectedY + Vector3.right * selectedX,
                Vector3.forward * (selectedY + 1) + Vector3.right * (selectedX + 1));
        }
    }
    private void SpawnChessMan(int prefab_index,Vector3 position)
    {
        GameObject temp = Instantiate(chessmanPrefabs[prefab_index],position,Quaternion.Euler(0,180,0)) as GameObject; //tworzy obiekt na podstawie prefabu o określonej pozycji
        temp.transform.SetParent(transform);
        active_chessmanPrefabs.Add(temp);
    }

    private void SpawnAllChessMans()
    {
        active_chessmanPrefabs = new List<GameObject>();

        //Biały team
        #region 
        //Król
        SpawnChessMan(0, GetTileCenter(3, 0));
        //Królowa
        SpawnChessMan(1, GetTileCenter(4, 0));
        //wieże
        SpawnChessMan(2, GetTileCenter(0, 0));
        SpawnChessMan(2, GetTileCenter(7, 0));
        //piony
        for(int i =0;i<=7;i++)
            SpawnChessMan(3, GetTileCenter(i, 1));
        //konie
        SpawnChessMan(4, GetTileCenter(1, 0));
        SpawnChessMan(4, GetTileCenter(6, 0));
        //gońce
        SpawnChessMan(5, GetTileCenter(2, 0));
        SpawnChessMan(5, GetTileCenter(5, 0));
        #endregion
        //Czarny team
        #region 
        //Król
        SpawnChessMan(6, GetTileCenter(3, 7));
        //Królowa
        SpawnChessMan(7, GetTileCenter(4, 7));
        //wieże
        SpawnChessMan(8, GetTileCenter(0, 7));
        SpawnChessMan(8, GetTileCenter(7, 7));
        //piony
        for (int i = 0; i <= 7; i++)
            SpawnChessMan(9, GetTileCenter(i, 6));
        //konie
        SpawnChessMan(10, GetTileCenter(1, 7));
        SpawnChessMan(10, GetTileCenter(6, 7));
        //gońce
        SpawnChessMan(11, GetTileCenter(2, 7));
        SpawnChessMan(11, GetTileCenter(5, 7));
        #endregion


    }

    private Vector3 GetTileCenter(int x,int y) //umieszczanie figury na środku danego pola
    {
        Vector3 origin = Vector3.zero;
        origin.x += (tile_size * x) + tile_offset;
        origin.z += (tile_size * y) + tile_offset;
        return origin;
    }

}
