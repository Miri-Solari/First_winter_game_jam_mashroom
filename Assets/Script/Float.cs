using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Float : MonoBehaviour
{
    [SerializeField] private int time;
    public TileBase BasicTile;
    public TileBase Whater;
    public static List<Vector3Int> AllGrass = new List<Vector3Int>();
    public static List<Vector3Int> AllRemainGrass = new List<Vector3Int>();
    public static List<Vector3Int> AllWhater = new List<Vector3Int>();

    private Tilemap map;
    private Camera mainCamera;
        
    void Start()
    {
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        mainCamera = Camera.main;
        StartCoroutine(Drown());
        for (int io = 0; io < 5; io++)
        {
            for (int i = 0; i < 5; i++)
            {
                AllGrass.Add(new Vector3Int(-5 + i, -io, 0));
            }
        }
        AllRemainGrass = AllGrass;
    }

    IEnumerator Drown()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (time > 1)
                time -= 1;
            int r = Random.Range(0, AllRemainGrass.Count-1);
            Debug.Log(AllRemainGrass.Count - 1);
            Debug.Log(r);
            map.SetTile(AllRemainGrass[r], Whater);
            if (field.AllMushrom.Contains(AllRemainGrass[r]))
            {
                int index = 0;
                for (int i = 0; i < field.AllMushrom.Count; i++)
                {
                    if (field.AllMushrom[i] == AllGrass[r])
                    {
                        index = i;
                        break;
                    }
                }
                Destroy(field.AllMushromGameObject[index]);
                field.AllMushromGameObject.RemoveAt(index);
                field.AllMushrom.RemoveAt(index);
            }
            AllWhater.Add(AllRemainGrass[r]);
            AllRemainGrass.RemoveAt(r);
        }
    }
}
