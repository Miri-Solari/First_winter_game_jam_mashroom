using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrom : MonoBehaviour
{
    List<Vector3Int> AroundPosition;
    public int[] Pref;
    public int[] Repr;
    public int[] Prov;
    public int[] Cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ChangeIncome()
    {
        GameObject CheckTupeOfMushrum;
        int numberOfGameObject=0;
        for (int i = 0; i < AroundPosition.Count; i++)
        {
            if (field.AllMushrom.Contains(AroundPosition[i]))
            {
                for (int io = 0; io < field.AllMushrom.Count; io++)
                {
                    if (field.AllMushrom == AroundPosition)
                        numberOfGameObject = io;
                        break;
                }
                CheckTupeOfMushrum = field.AllMushromGameObject[numberOfGameObject];
                if (field.AllMushromGameObject[numberOfGameObject].tag == "Sigma")
                {
                    if (gameObject.tag == "alpha")
                    {

                    }
                    if (gameObject.tag == "omega")
                    {

                    }
                    if (gameObject.tag == "gamma")
                    {

                    }
                    if (gameObject.tag == "beta-fem")
                    {

                    }
                    if (gameObject.tag == "beta-male")
                    {

                    }
                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "alpha")
                {

                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "omega")
                {

                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "gamma")
                {

                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "beta-fem")
                {

                }
                if (field.AllMushromGameObject[numberOfGameObject].tag == "beta-male")
                {

                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
