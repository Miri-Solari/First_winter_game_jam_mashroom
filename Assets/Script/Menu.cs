using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Armagedon()
    {
        SceneManager.LoadScene("Armagedon");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
