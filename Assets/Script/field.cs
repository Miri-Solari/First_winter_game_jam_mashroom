using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class field : MonoBehaviour
{
    public TileBase BasicTile;
    public TMP_Text Money_output;
    public static float Money=1170;
    public GameObject[] Mushrom;
    public static List<Vector3Int> AllMushrom = new List<Vector3Int>();
    public static List<GameObject> AllMushromGameObject = new List<GameObject>();
    public int[] MoneyToBuild;
    public static int[] SaveMoneyToBuild;
    public int CostOfGrass;

    private Tilemap map;
    private Camera mainCamera;
    private Vector3Int CellToBuild;
    private bool readyToBuild = false;
    void Start() 
    {
        SaveMoneyToBuild = MoneyToBuild;
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Money_output.text ="Money " + Money;
        if (Input.GetMouseButtonDown(0))
        {

                Vector3 MousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
                Vector3Int cellPosition = map.WorldToCell(MousePosition);
                if(map.GetTile(cellPosition) == BasicTile || Float.AllWhater.Contains(cellPosition))
                {
                    map.SetColor(CellToBuild, Color.white);
                    CellToBuild = cellPosition;
                    map.SetTileFlags(cellPosition, TileFlags.None);
                    map.SetColor(cellPosition, Color.gray);
                }
        }
    }
    public void ButtonBuild(int index)
    {
        if (Money >= MoneyToBuild[index] && AllMushrom.Contains(CellToBuild) == false && map.GetTile(CellToBuild) == BasicTile)
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
                {
                    numberOfGameObject = io;
                    break;
                }
            }
            readyToBuild = false;
            Debug.Log(numberOfGameObject); Debug.Log(AllMushrom.Count);
            AllMushrom.Remove(CellToBuild);
            map.SetColor(CellToBuild, Color.white);
            switch (AllMushromGameObject[numberOfGameObject].tag)
            {
                case "sigma":
                    Money += MoneyToBuild[0] / 2;
                    break;

                case "alpha":
                    Money += MoneyToBuild[1] / 2;
                    break;

                case "omega":
                    Money += MoneyToBuild[2] / 2;
                    break;

                case "gamma":
                    Money += MoneyToBuild[3] / 2;
                    break;

                case "beta-male":
                    Money += MoneyToBuild[4] / 2;
                    break;

                case "beta-fem":
                    Money += MoneyToBuild[5] / 2;
                    break;
            }

            Destroy(AllMushromGameObject[numberOfGameObject]);
            AllMushromGameObject.Remove(AllMushromGameObject[numberOfGameObject]);
        }

    }
    public void BuyGrass()
    {
        if (map.GetTile(CellToBuild)!=BasicTile)
        {
            if (Money>= CostOfGrass)
            {
                map.SetColor(CellToBuild, Color.white);
                map.SetTile(CellToBuild, BasicTile);
                Float.AllRemainGrass.Add(CellToBuild);
                Float.AllWhater.Remove(CellToBuild);
                Money -= CostOfGrass;
            }

        }
    }
    public void red()
    {
        map.SetColor(CellToBuild, Color.red);
        CellToBuild = new Vector3Int(99,0,0);
    }

    public void green()
    {
        map.SetColor(CellToBuild, Color.green);
        CellToBuild = new Vector3Int(99, 0, 0);
    }

}
        
