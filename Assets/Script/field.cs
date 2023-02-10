using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class field : MonoBehaviour
{
    public TileBase BasicTile;
    private Tilemap map;
    public TMP_Text Money_output;
    public static float Money=500;
    public GameObject[] Mushrom;
    public static List<Vector3Int> AllMushrom = new List<Vector3Int>();
    public static List<GameObject> AllMushromGameObject = new List<GameObject>();
    private Camera mainCamera;
    public int[] MoneyToBuild ;
    private Vector3Int CellToBuild;
    private bool readyToBuild = false;
    void Start()
    {
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Money_output.text ="V" + Money;
        if (Input.GetMouseButtonDown(0))
        {
            if (readyToBuild == false)
            {
                Vector3 MousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
                Vector3Int cellPosition = map.WorldToCell(MousePosition);
                if(AllMushrom.Contains(cellPosition) == false && map.GetTile(cellPosition) == BasicTile)
                {
                    CellToBuild = cellPosition;
                    map.SetTileFlags(cellPosition, TileFlags.None);
                    map.SetColor(cellPosition, Color.red);
                    readyToBuild = true;
                }
            }
        }
    }
    public void ButtonBuild(int index)
    {
        if (Money >= MoneyToBuild[index] && readyToBuild == true)
        {
            readyToBuild = false;
            AllMushromGameObject.Add(Instantiate(Mushrom[index], new Vector3 (map.CellToWorld(CellToBuild).x+1.1f, map.CellToWorld(CellToBuild).y+1.1f, -1), Quaternion.identity));
            AllMushrom.Add(CellToBuild);
            Money -= MoneyToBuild[index];
            map.SetColor(CellToBuild, Color.white);
        }
    }
   public void CancelClick()
   {
        readyToBuild = false;
        map.SetColor(CellToBuild, Color.white);
   }
}
        
