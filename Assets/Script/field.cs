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
    public static float Money=70;
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
        Money_output.text ="Money " + Money;
        if (Input.GetMouseButtonDown(0))
        {
            if (readyToBuild == false)
            {
                Vector3 MousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
                Vector3Int cellPosition = map.WorldToCell(MousePosition);
                if(map.GetTile(cellPosition) == BasicTile)
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
        if (Money >= MoneyToBuild[index] && readyToBuild == true && AllMushrom.Contains(CellToBuild) == false  )
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
   
    public void DeleteMushrom()
    {
        int numberOfGameObject=0; 
        if (AllMushrom.Contains(CellToBuild) == true)
        {
            for (int io = 0; io < AllMushrom.Count; io++)
            {
                if (AllMushrom[io] == CellToBuild)
                    numberOfGameObject = io;
                break;
            }
            readyToBuild = false;
            AllMushrom.Remove(CellToBuild);
            map.SetColor(CellToBuild, Color.white);
            if (AllMushromGameObject[numberOfGameObject].tag == "sigma")
            {
                Money += 3;
            }
            if (AllMushromGameObject[numberOfGameObject].tag == "alpha")
            {
                Money += 5;
            }
            if (AllMushromGameObject[numberOfGameObject].tag == "omega")
            {
                Money += 6;
            }
            if (AllMushromGameObject[numberOfGameObject].tag == "gamma")
            {
                Money += 20;
            }
            if (AllMushromGameObject[numberOfGameObject].tag == "beta-male")
            {
                Money += 25;
            }
            if (AllMushromGameObject[numberOfGameObject].tag == "beta-fem")
            {
                Money += 36;
            }
            Destroy(AllMushromGameObject[numberOfGameObject]);
        }

    }
}
        
