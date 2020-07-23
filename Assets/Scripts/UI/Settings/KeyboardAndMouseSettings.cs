using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardAndMouseSettings : MonoBehaviour
{
    public Transform KeyMousPanel; // Пространство кнопок управления

    public Transform MouseSensitivity; // Пространство элементов настройки чувствительности

    Slider MouseSensitivitySlider;
    InputField MouseSensitivityText;

    [HideInInspector]
    public bool Rewrite = false; // Считывать нажатые клавиши для перезаписи?

    int IdBotton; // Индекс кнопки

    Color colText, colBotton; // Переменные для изменения цвета


    void Start()
    {
        // Присвоение элементов управления чувствительности мыши
        MouseSensitivitySlider = MouseSensitivity.GetChild(0).GetComponent<Slider>();
        MouseSensitivityText = MouseSensitivity.GetChild(1).GetComponent<InputField>();


        //// Выставление настроенного управления

        // Выставление чувствительности мыши
        MouseSensitivityText.text = PlayerPrefs.GetFloat("MouseSensitivity").ToString();
        MouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");

        // Выставление кнопок управления
        for (int i = 0; i < 8; i++)
        {
            if (PlayerPrefs.GetString("KeyMotion" + (i + 1)).Length == 6)
            {
                KeyMousPanel.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = CuttingOffAlphaFromKey(PlayerPrefs.GetString("KeyMotion" + (i + 1)));
            }
            else
            { 
                KeyMousPanel.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("KeyMotion" + (i + 1));
            }
        }
    }


    void OnGUI() // Смена управления
    {
        if (Rewrite) // Если активна смена управления
        {
            Event e = Event.current;

            if (e.isKey || e.isMouse)
            {

                if (e.keyCode.ToString() != "None" && e.keyCode != KeyCode.Escape)
                {
                    RewriteKeyControl(e.keyCode.ToString().ToLower()); 
                }
            }
            // ДА! Я устал искать эти чёртовы методы получения нажатий! я уже нашёл как правильно реализовать шифт, но ещё и на дополнительные кнопки мыши искать у меня нет сил. Поэтому я оставлю так. Если конечно потом не переделаю 
            if (Input.GetKey("left shift"))
                RewriteKeyControl("left shift");
            if (Input.GetKey("right shift"))
                RewriteKeyControl("right shift");
            if (Input.GetKey("mouse 0"))
                RewriteKeyControl("mouse 0");
            if (Input.GetKey("mouse 1"))
                RewriteKeyControl("mouse 1");
            if (Input.GetKey("mouse 2"))
                RewriteKeyControl("mouse 2");
            if (Input.GetKey("mouse 3"))
                RewriteKeyControl("mouse 3");
            if (Input.GetKey("mouse 4"))
                RewriteKeyControl("mouse 4");
            if (Input.GetKey("mouse 5"))
                RewriteKeyControl("mouse 5");
            if (Input.GetKey("mouse 6"))
                RewriteKeyControl("mouse 6");
        }
    }

    void RewriteKeyControl(string key) // Запись новой клавиши
    {
        if (key.Length == 6)
        {
            KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().text = CuttingOffAlphaFromKey(key);
        }
        else
        {
            KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().text = key;
        }

        PlayerPrefs.SetString("KeyMotion" + (IdBotton + 1), key);
        Rewrite = false;

        RewriteKolors();
    }

    public void UndoChanges() // Отмена перезаписи
    {
        Rewrite = false;
        RewriteKolors();
    }

    public void RewriteKeyBotton(int IdBotton) // Активация перезаписи клавиши управления
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

    public void RewriteKolors() // Возвращение цвета по оконьчанию или отмене перезаписи клавиш
    {
        // Возвращение цвета текста
        colText.r = colText.g = colText.b = 1;
        KeyMousPanel.GetChild(IdBotton).transform.GetChild(0).GetComponent<Text>().color = colText;

        // Возвращение цвета кнопки
        colBotton.a = 1;
        KeyMousPanel.GetChild(IdBotton).GetComponent<Image>().color = colBotton;
    }

    string CuttingOffAlphaFromKey(string key) // отсечение приставки Alpha у численых значений кнопок
    {
        return key.Trim('a', 'l', 'p', 'h');
    }


    public void SetMouseSensitivitySlider() // Изменение чувствительности мыши при движении ползунка
    {
        float value = (float) Math.Round(MouseSensitivitySlider.value, 2); // Отсекаются тысячные после запятой
        MouseSensitivityText.text = value.ToString();
        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }

    public void SetMouseSensitivityBoxAdjustment() // Отсекается ввод значений "-" и "."
    {
        MouseSensitivityText.text = MouseSensitivityText.text.Trim('-', '.');
    }

    public void SetMouseSensitivityBox() // Изменение чувствительности мыши при вводе вручную
    {
        if (MouseSensitivityText.text == "" || MouseSensitivityText.text == ",") // Если в поле отсутствует значение
        {
            MouseSensitivitySlider.value = 0.01f;
            MouseSensitivityText.text = "0,01";

            PlayerPrefs.SetFloat("MouseSensitivity", MouseSensitivitySlider.value);
            return;
        }

        if (float.Parse(MouseSensitivityText.text) > 50)
        {
            MouseSensitivitySlider.value = 50f;
            MouseSensitivityText.text = "50";
        }
        else
        if (float.Parse(MouseSensitivityText.text) < 0.01f)
        {
            MouseSensitivitySlider.value = 0.01f;
            MouseSensitivityText.text = "0,01";
        }
        else
        {
            MouseSensitivitySlider.value = float.Parse(MouseSensitivityText.text);
        }

        PlayerPrefs.SetFloat("MouseSensitivity", MouseSensitivitySlider.value);
    }
}

