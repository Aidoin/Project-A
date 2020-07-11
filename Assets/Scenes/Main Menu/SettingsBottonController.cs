using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBottonController : MonoBehaviour
{
    public GameObject[] paragraph = new GameObject[3];
    public GameObject[] panel = new GameObject[3];

    [Space(20)]
    public Sprite spriteOn; 
    public Sprite spriteOff;

    public void Transition(int index)
    {
        for (int i=0; i<paragraph.Length; i++)
        {
            panel[i].SetActive(false);
            paragraph[i].GetComponent<Image>().sprite = spriteOff;
        }

        panel[index].SetActive(true);
        paragraph[index].GetComponent<Image>().sprite = spriteOn;

    }
}
