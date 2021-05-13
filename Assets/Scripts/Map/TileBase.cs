using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBase : MonoBehaviour
{
    //public AnimatedTile[] water;
    [SerializeField] private Tile grass;
    [SerializeField] private RuleTile water;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public AnimatedTile GetAnimTile(char tileLetter)
    {
        switch (tileLetter)
        {
            default:
                Debug.Log("No Animated Tile found for: " + tileLetter.ToString());
                return null;
        }
    }

    public RuleTile GetRuleTile(char tileLetter)
    {
        switch (tileLetter)
        {
            case 'w':
                return water;
            default:
                Debug.Log("No Rule Tile found for: " + tileLetter.ToString());
                return null;
        }
    }

    public Tile GetTile(char tileLetter)
    {
        switch (tileLetter)
        {
            case 'g':
                return grass;
            default:
                Debug.Log("No Tile found for: " + tileLetter.ToString());
                return null;
        }
    }

    /*
    public AnimatedTile GetWater(char[,] tiles)
    {
        string strTiles = "";

        for (int i = 2; i > -1; i--)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tiles[j, i] == '-')
                {
                    strTiles += 'w';
                }
                else
                {
                    strTiles += tiles[j, i].ToString();
                }
            }
        }

        if (strTiles[1] == 'g')
        {
            strTiles = "-g-" + strTiles.Substring(3);
        }

        if (strTiles[3] == 'g')
        {
            strTiles = "-" + strTiles.Substring(1, 5) + "-" + strTiles.Substring(7);
        }

        if (strTiles[5] == 'g')
        {
            strTiles = strTiles.Substring(0, 2) + "-" + strTiles.Substring(3, 5) + "-";
        }

        if (strTiles[7] == 'g')
        {
            strTiles = strTiles.Substring(0, 6) + "-" + strTiles[7].ToString() + "-";
        }

        Debug.Log(strTiles);

        switch (strTiles)
        {

            case "wwwwwwwww":
                return water[1];
            case "gwgwwwgwg":
                return water[2];
            case "wwwwww-g-":
                return water[3];
            case "-wwgww-ww":
                return water[4];
            case "-g-wwwwww":
                return water[5];
            case "ww-wwgww-":
                return water[6];
            case "-wwgww-g-":
                return water[7];
            case "ww-wwg-g-":
                return water[8];
            case "-g-gww-ww":
                return water[9];
            case "-g-wwgww-":
                return water[10];
            case "-g-www-g-":
                return water[11];
            case "-w-gwg-w-":
                return water[12];
            case "-g-gww-g-":
                return water[13];
            case "-g-gwg-w-":
                return water[14];
            case "-g-wwg-g-":
                return water[15];
            case "-w-gwg-g-":
                return water[16];
            case "-g-gwg-g-":
                return water[17];
            case "gwwwww-g-":
                return water[18];
            case "wwgwww-g-":
                return water[19];
            case "gwgwww-g-":
                return water[20];
            case "-wggww-ww":
                return water[21];
            case "-wwgww-wg":
                return water[22];
            case "-wggww-wg":
                return water[23];
            case "-g-wwwgww":
                return water[24];
            case "-g-wwwwwg":
                return water[25];
            case "-g-wwwgwg":
                return water[26];
            case "gw-wwgww-":
                return water[27];
            case "ww-wwggw-":
                return water[28];
            case "gw-wwggw-":
                return water[29];
            case "-g-wwggw-":
                return water[30];
            case "-g-gww-wg":
                return water[31];
            case "gw-wwg-g-":
                return water[32];
            case "-wggww-g-":
                return water[33];
            case "wwwwwwgww":
                // Upper Left Corner
                return water[34];
            case "wwwwwwwwg":
                // Upper Right Corner
                return water[35];
            case "gwwwwwwww":
                //Lower Left Corner
                return water[36];
            case "wwgwwwwww":
                // Lower Right Corner
                return water[37];
            case "wwgwwwgww":
                return water[38];
            case "wwwwwwgwg":
                return water[39];
            case "gwwwwwgww":
                return water[40];
            case "gwwwwwwwg":
                return water[41];
            case "wwgwwwwwg":
                return water[42];
            case "gwgwwwwww":
                return water[43];
            case "gwwwwwgwg":
                return water[44];
            case "wwgwwwgwg":
                return water[45];
            case "gwgwwwgww":
                return water[46];
            case "gwgwwwwwg":
                return water[47];
            default:
                return water[1];
        }
    }*/
}
