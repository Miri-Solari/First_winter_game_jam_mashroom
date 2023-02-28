using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End : MonoBehaviour
{
    private int time;
    private int money;
    public TMP_Text TextTime;
    public TMP_Text TextMoney;
    public TMP_Text TextScore;
    public TMP_Text ShowTime;
    public GameObject Bacground;
    void Start()
    {
        StartCoroutine(Clock());
        Bacground.SetActive(false);
    }
    IEnumerator Clock()
    {
        while (true)
        {
            time += 1;
            if (time/60<=10)
            {
                ShowTime.text = "0" + time / 60 + ":" + time % 60;
                if (time%60<10)
                {
                    ShowTime.text = "0" + time / 60 + ":" + "0" + time % 60;
                }
            }
            else
            {
                ShowTime.text = time / 60 + ":" + time % 60;
                if (time % 60 < 10)
                {
                    ShowTime.text = time / 60 + ":" + "0" + time % 60;
                }
            }
            yield return new WaitForSeconds(1);
        }   
    }
    public void ShowScore()
    {
        for (int i = 0; i < field.AllMushromGameObject.Count; i++)
        {
            switch (field.AllMushromGameObject[i].tag)
            {
                case "sigma":
                    money += field.SaveMoneyToBuild[0];
                    break;

                case "alpha":
                    money += field.SaveMoneyToBuild[1];
                    break;

                case "omega":
                    money += field.SaveMoneyToBuild[2];
                    break;

                case "gamma":
                    money += field.SaveMoneyToBuild[3];
                    break;

                case "beta-male":
                    money += field.SaveMoneyToBuild[4];
                    break;

                case "beta-fem":
                    money += field.SaveMoneyToBuild[5];
                    break;
            }
        }
        Bacground.SetActive(true);
        if (time / 60 <= 10)
        {
            TextTime.text = "0" + time / 60 + ":" + time % 60;
            if (time % 60 < 10)
            {
                TextTime.text = "0" + time / 60 + ":" + "0" + time % 60;
            }
        }
        else
        {
            TextTime.text = time / 60 + ":" + time % 60;
            if (time % 60 < 10)
            {
                TextTime.text = time / 60 + ":" + "0" + time % 60;
            }
        }
        TextMoney.text = field.Money.ToString();
        TextScore.text = (time * 7 + (field.Money + money)).ToString();
        StopAllCoroutines();
        Debug.Log("score");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
