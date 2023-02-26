using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mushrom : MonoBehaviour
{
    List<Vector3Int> AroundPosition= new List<Vector3Int>();
    public float income;
    private float startIncome;
    public float Cost;
    public int Procent;
    public TileBase BasicTile;
    public TileBase DeadTile;
    public List<string> GoodMushroom;
    public List<string> BadMushroom;
    private Tilemap map;
    private GameObject CheckTupeOfMushrum;
    public GameObject Sigma;

    void ChangeIncome()
    {
        Procent = 100;
        income = startIncome;
        int numberOfGameObject=0;
        GetPositionArround(map.WorldToCell(gameObject.transform.position));
        for (int i = 0; i < AroundPosition.Count; i++)
        {
            if (field.AllMushrom.Contains(AroundPosition[i]))
            {
                for (int io = 0; io < field.AllMushrom.Count; io++)
                {
                    if (field.AllMushrom[io] == AroundPosition[i])
                    {
                        numberOfGameObject = io;
                        break;
                    }
                        
                }
                CheckTupeOfMushrum = field.AllMushromGameObject[numberOfGameObject];
                switch (gameObject.tag)
                {
                    case "sigma":
                        sigma();
                        break;

                    case "alpha":
                        alpha();
                        break;

                    case "omega":
                        omega();
                        break;

                    case "gamma":
                        gamma();
                        break;

                    case "beta-male":
                        bettaMale();
                        break;

                    case "beta-fem":
                        bettaFemale();
                        break;
                }


            }
        }
    }
    void sigma()
    {
        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 25;
        }
        if (BadMushroom.Contains(CheckTupeOfMushrum.tag))
        {

            Procent -= 10000;
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent -= 10000;
        }
    }
    void alpha()
    {

        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 25;
        }
        if (BadMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent -= 25;
        }
    }
    void omega()
    {
        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 100;
        }
        if (BadMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent -= 25;
        }
    }
    void gamma()
    {
        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 25;
        }
        if (BadMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent -= 100;
        }
    }
    void bettaMale()
    {
        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 20;
        }
        if (BadMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent -= 45;
        }
    }
    void bettaFemale()
    {
        if (GoodMushroom.Contains(CheckTupeOfMushrum.tag))
        {
            CheckTupeOfMushrum.GetComponent<Mushrom>().Procent += 25;
        }
    }

    IEnumerator PrefPerSecond()
    {
        while (true)
        {
            ChangeIncome();
            yield return new WaitForSeconds(3);

            income = startIncome * (Procent / 100);
            if (income < 0)
                income = 0;
            field.Money += Mathf.Round(income);
            Debug.Log(income);
        }
    }
    IEnumerator SigmaSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 0; i < AroundPosition.Count; i++)
            {
                if (field.AllMushrom.Contains(AroundPosition[i]) == false && map.GetTile(AroundPosition[i]) == BasicTile)
                {
                    int r = Random.Range(0, 100);
                    if (r >= 70)
                    {
                        field.AllMushromGameObject.Add(Instantiate(Sigma, new Vector3(map.CellToWorld(AroundPosition[i]).x + 1.1f, map.CellToWorld(AroundPosition[i]).y + 1.1f, -1), Quaternion.identity));
                        field.AllMushrom.Add(AroundPosition[i]);
                    }
                    break;
                }

            }
        }
    }
    void Start()
    {
        startIncome = income;
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        ChangeIncome();
        StartCoroutine(PrefPerSecond());
        if (gameObject.tag=="alpha")
        {
            StartCoroutine(SigmaSpawn());
        }
        if (gameObject.tag== "beta-male")
        {
            int kill=0;
            GetPositionArround(map.WorldToCell(gameObject.transform.position));
            for (int i = 0; i < AroundPosition.Count; i++)
            {
                if (map.GetTile(AroundPosition[i])==BasicTile && field.AllMushrom.Contains(AroundPosition[i]) == false)
                {
                    kill += 1;
                    map.SetTile(AroundPosition[i], DeadTile);
                }
                if (kill == 2)
                    break;
            }
            if (kill<2)
            {
                for (int i = 0; i < AroundPosition.Count; i++)
                {
                    if(map.GetTile(AroundPosition[i]) == BasicTile)
                    {
                        kill += 1;
                        map.SetTile(AroundPosition[i], DeadTile);
                        if (field.AllMushrom.Contains(AroundPosition[i]))
                        {
                            if (field.AllMushrom.Contains(AroundPosition[i]))
                            {
                                for (int io = 0; io < field.AllMushrom.Count; io++)
                                {
                                    if (field.AllMushrom[io] == AroundPosition[i])
                                    {
                                        
                                        Destroy(field.AllMushromGameObject[io]);
                                        field.AllMushrom.Remove(field.AllMushrom[io]);
                                        field.AllMushromGameObject.Remove(field.AllMushromGameObject[io]);
                                        break;
                                    }
                                    
                                }
                            }
                        }
                    }
                    if (kill == 2)
                        break;
                }
            }
        }
    }
    void QuitGame()
    {
        Application.Quit();
    }
    void GetPositionArround(Vector3Int startPosition)
    {
        AroundPosition.Clear();
        AroundPosition.Add(new Vector3Int(startPosition.x + 0, startPosition.y + 1, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x + 0, startPosition.y - 1, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x + 1, startPosition.y + 0, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x - 1, startPosition.y + 0, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x + 1, startPosition.y + 1, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x - 1, startPosition.y - 1, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x + 1, startPosition.y - 1, 0));
        AroundPosition.Add(new Vector3Int(startPosition.x - 1, startPosition.y + 1, 0));
    }
}
