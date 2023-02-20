using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushromData : MonoBehaviour
{
    public List<GameObject> AllMushromData = new List<GameObject>();
    private int saveIndex=0;
    public GameObject canvas;
    
    void Start()
    {
        
    }

    public void ShowMushroom(int index)
    {
        AllMushromData[saveIndex].SetActive(false);
        AllMushromData[index].SetActive(true);
        saveIndex = index;
    }
    public void GoToField()
    {
        canvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
