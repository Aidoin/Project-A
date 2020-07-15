using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardAndMouseSettings : MonoBehaviour
{
    public Transform KeyMousPanel;

    public bool Rewrite = false;

    int IdBotton;

    Color colText, colBotton; // переменные для изменения цвета



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            if (PlayerPrefs.GetString("KeyMotion" + (i + 1)).Length == 6)
            {
                KeyMousPanel.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("KeyMotion" + (i + 1)).Trim('a', 'l', 'p', 'h');
            }
            else
            { 
                KeyMousPanel.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("KeyMotion" + (i + 1));
            }
        }
    }


    void OnGUI()
    {
        if (Rewrite)
        {
            Event e = Event.current;

            if (e.isKey || e.isMouse)
            {
                if (e.keyCode.ToString() != "None" && e.keyCode != KeyCode.Escape)
                {
                    RewriteKeyControl(e.keyCode.ToString().ToLower()); 
                }
            }

            if (Input.GetKey("left shift"))
                RewriteKeyControl("left shift");
            if (Input.GetKey("right shift"))
                RewriteKeyControl("right shift");
        }
    }

    void RewriteKeyControl(string key)
    {
        if (key.Length == 6)
        {
            KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().text = key.Trim('a', 'l', 'p', 'h');
        }
        else
        {
            KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().text = key;
        }

        PlayerPrefs.SetString("KeyMotion" + (IdBotton + 1), key);
        Rewrite = false;

        RewriteKolors();
    }

    public void UndoChanges()
    {
        Rewrite = false;
        RewriteKolors();
    }

    public void RewriteKeyBotton(int IdBotton)
    {
        this.IdBotton = IdBotton;
        Rewrite = true;

        // Изменение цвета текста
        colText = KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().color;
        colText.r = colText.g = colText.b = 0;
        KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().color = colText;

        // Изменение цвета кнопки
        colBotton = KeyMousPanel.GetChild(IdBotton).GetComponent<Image>().color;
        colBotton.a = 0.588f;
        KeyMousPanel.GetChild(IdBotton).GetComponent<Image>().color = colBotton;
    }

    public void RewriteKolors()
    {
        // Возвращение цвета текста
        colText.r = colText.g = colText.b = 1;
        KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().color = colText;

        // Возвращение цвета кнопки
        colBotton.a = 1;
        KeyMousPanel.GetChild(IdBotton).GetComponent<Image>().color = colBotton;
    }

}

