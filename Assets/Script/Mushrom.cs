using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mushrom : MonoBehaviour
{
    List<Vector3Int> AroundPosition= new List<Vector3Int>();
    public float Pref;
    public float Prov;
    public float Cost;
    private Tilemap map;
    void BasicCheck()
    {
        if (gameObject.tag == "sigma")
        {
            Pref = 2;
            Prov = 1;
        }
        if (gameObject.tag == "alpha")
        {
            Pref = 0;
            Prov = 2;
        }
        if (gameObject.tag == "omega")
        {
            Pref = 6;
            Prov = 3;
        }
        if (gameObject.tag == "gamma")
        {
            Pref = 0;
            Prov = 7;
        }
        if (gameObject.tag == "beta-male")
        {
            Pref = 10;
            Prov = 5;
        }
        if (gameObject.tag == "beta-fem")
        {
            Pref = 0;
            Prov = 7;
        }
    }
    void ChangeIncome()
    {
        BasicCheck();
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
                {
                    if (gameObject.tag == "alpha")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "omega")
                    {
                        Pref *= 0.9f;
                        Prov *= 1.05f;
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Pref *= 0.95f;
                        Prov *= 1.05f;
                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "alpha")
                {

                    if (gameObject.tag == "omega")
                    {
                        Pref *= 0.85f;
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.1f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Pref *= 1.1f;
                        Prov *= 1.05f;
                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "omega")
                {

                    if (gameObject.tag == "alpha")
                    {
                        Prov *= 0.83f;
                    }
                    if (gameObject.tag == "omega")
                    {
                        Pref *= 1.3f;
                    }
                    if (gameObject.tag == "gamma")
                    {
                        Prov *= 0.85f;
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.35f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Pref *= 1.05f;
                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "gamma")
                {
                    Debug.Log("Test1");
                    if (gameObject.tag == "sigma")
                    {
                        Prov *= 1.1f;
                        Pref *= 1.25f;
                    }
                    if (gameObject.tag == "alpha")
                    {
                        Prov *= 0.9f;
                    }
                    if (gameObject.tag == "omega")
                    {
                        Pref *= 1.4f;
                        Prov *= 1.55f;
                    }
                    if (gameObject.tag == "gamma")
                    {
                        Prov *= 1.5f;
                        Debug.Log("Test2");
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Prov *= 1.45f;
                        Pref *= 1.55f;
                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "beta-fem")
                {
                    if (gameObject.tag == "alpha")
                    {
                        Prov *= 1.1f;
                    }
                    if (gameObject.tag == "omega")
                    {
                        Pref *= 0.85f;
                    }
                    if (gameObject.tag == "gamma")
                    {
                        Prov *= 1.05f;
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Prov *= 0.9f;
                        Pref *= 1.2f;
                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "beta-male")
                {
                    if (gameObject.tag == "alpha")
                    {
                        Prov *= 1.07f;
                    }
                    if (gameObject.tag == "omega")
                    {
                        Pref *= 0.75f;
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "gamma")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "beta-male")
                    {
                        Prov *= 1.15f;
                    }
                    if (gameObject.tag == "beta-fem")
                    {
                        Prov *= 1.1f;
                        Pref *= 1.2f;
                    }
                }
            }
            
        }
    }

    // Update is called once per frame

    IEnumerator PrefPerSecond()
    {
        while (true)
        {
            ChangeIncome();
            field.Money += Pref;
            field.Money -= Prov;
            yield return new WaitForSeconds(3);
            Debug.Log(Pref);
        }
    }
    void EndGame()
    {
        if (field.Money <= -1)
        {
            Debug.Log("Game Over!");
            QuitGame();
        }
    }
    void Won()
    {
        if (field.Money >= 100)
        {
            Debug.Log("Won!!!");
            QuitGame();
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
