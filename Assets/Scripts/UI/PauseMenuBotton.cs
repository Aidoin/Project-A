using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuBotton : MonoBehaviour
{
    public GameObject[] botton = new GameObject[2];
    public GameObject[] panel = new GameObject[2];
    public GameObject confirmationOfSaving;


    public void ShowPanel(int id)
    {
        HidePanel();

        panel[id].SetActive(true);
        botton[id].transform.GetChild(0).GetComponent<Text>().color = Color.red;
    }

    public void HidePanel()
    {
        for (int i = 0; i <= 1; i++)
        {
            botton[i].transform.GetChild(0).GetComponent<Text>().color = Color.white;
            panel[i].SetActive(false);

            confirmationOfSaving.SetActive(false);
        }
    }
}
