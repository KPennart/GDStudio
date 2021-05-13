using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    // Start is called before the first frame update
    char[,] mapData;

    public void CreateMap(int x, int y)
    {
        mapData = new char[x, y];
    }

    public int GetLen()
    {
        //Debug.Log("TEST LENGTH: " + mapData.GetLength(0).ToString());
        return mapData.GetLength(0);
    }

    public int GetWid()
    {
        return mapData.GetLength(1);
    }

    public void SetTileData(int x, int y, char data)
    {
        mapData[x, y] = data;
    }

    public char GetTileData(int x, int y)
    {
        if (x < 0 || y < 0 || x >= GetLen() || y >= GetWid())
        {
            return '-';
        }
        else
        {
            return mapData[x, y];
        }
    }

    public char[,] GetDetailTileData(int x, int y)
    {
        char[,] tileInfo;

        tileInfo = new char[3, 3] {
                                    { GetTileData(x-1, y-1), GetTileData(x, y-1), GetTileData(x+1, y-1)},
                                    { GetTileData(x - 1, y), GetTileData(x, y), GetTileData(x + 1, y)},
                                    { GetTileData(x - 1, y + 1), GetTileData(x, y + 1), GetTileData(x + 1, y + 1)}
                                 };

        return tileInfo;
    }

    /*
    public void PrintMap()
    {
        for (int i = 0; i < GetLen(); i++)
        {
            string msg = "";
            for (int j = 0; j < GetWid(); i++)
            {
                msg += GetTileData(i, j);
            }
            Debug.Log(msg);
        }
    }*/
}
