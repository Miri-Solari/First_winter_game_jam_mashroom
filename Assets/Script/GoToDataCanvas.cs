using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDataCanvas : MonoBehaviour
{
    public GameObject canvas;
    public void GoToMushroomDataCanvas()
    {
        canvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
