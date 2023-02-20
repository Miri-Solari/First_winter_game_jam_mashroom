using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mushrom : MonoBehaviour
{
    List<Vector3Int> AroundPosition= new List<Vector3Int>();
    public float income;
    public float Cost;
    public GameObject[] GoodMushroom;
    public GameObject[] BadMushroom;
    private Tilemap map;

    void ChangeIncome()
    {
        GameObject CheckTupeOfMushrum;
        int numberOfGameObject=0;
        GetPositionArround(map.WorldToCell(gameObject.transform.position));
        for (int i = 0; i < AroundPosition.Count; i++)
        {
            Debug.Log("Test3");
            if (field.AllMushrom.Contains(AroundPosition[i]))
            {
                Debug.Log("Test4");
                for (int io = 0; io < field.AllMushrom.Count; io++)
                {
                    if (field.AllMushrom == AroundPosition)
                        numberOfGameObject = io;
                    break;
                }
                CheckTupeOfMushrum = field.AllMushromGameObject[numberOfGameObject];

                if (field.AllMushromGameObject[numberOfGameObject].tag == "sigma")
                { }

            }
        }
    }

    // Update is called once per frame

    IEnumerator PrefPerSecond()
    {
        while (true)
        {
            ChangeIncome();
            field.Money += Mathf.Round(income);
            yield return new WaitForSeconds(3);
            Debug.Log(income);
        }
    }
    private void Update()
    {
        if (field.Money >= 10000)
        {
            GameObject.Find("Win").SetActive(true);
        }
    }
    void Start()
    {
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        ChangeIncome();
        StartCoroutine(PrefPerSecond());
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
