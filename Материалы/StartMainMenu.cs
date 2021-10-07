using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class StartMainMenu : MonoBehaviour
{
    [HideInInspector]
    public List<Resolution> resList = new List<Resolution>();
    [HideInInspector]
    public List<string> strRes = new List<string>();


    void Awake()
    {
        // Получение разрешений экрана
        {
            Resolution[] resS = Screen.resolutions.Reverse().ToArray(); // Получения списка разрешений экрана (разворачиваем потому что по умолчанию список по возрастанию)

            // Проверка и отсеивание одинаковых разрешений с разной герцовкой
            for (int i = 0; i < resS.Length; i++) // Проверяемые значения
            {
                bool repetition = false; // Переменная отображает наличие повторения

                for (int o = 0; o < resList.Count; o++) // Записанные значения
                {
                    if (resS[i].height == resList[o].height && resS[i].width == resList[o].width) { repetition = true; break; /* Значение повторяется - пропуск */}

                }
                if (!repetition) // Если значение не повторилось, добавляем в списки
                {
                   // resList.Add(resS[i]);
                    //strRes.Add(resS[i].width.ToString() + " x " + resS[i].height.ToString());
                }
            }

            if (strRes.Count == 0) // Если разрешения не были найдены
            {
                Resolution res = new Resolution();

                if (!PlayerPrefs.HasKey("ScreenResolutionWidth") || !PlayerPrefs.HasKey("ScreenResolutionHeight"))
                {
                    PlayerPrefs.SetInt("ScreenResolutionWidth", res.width = Screen.width);
                    PlayerPrefs.SetInt("ScreenResolutionHeight", res.height = Screen.height);
                }
                else
                {
                    res.width = PlayerPrefs.GetInt("ScreenResolutionWidth");
                    res.height = PlayerPrefs.GetInt("ScreenResolutionHeight");
                }

                resList.Add(res);
                strRes.Add(PlayerPrefs.GetInt("ScreenResolutionWidth") + "X" + PlayerPrefs.GetInt("ScreenResolutionHeight"));
            }
        }
    }

    void Start()
    {
        // Качество графики
        //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));

        // Разрешение экрана
        if (PlayerPrefs.GetInt("ScreenResolutionWidth") != 0 || PlayerPrefs.GetInt("ScreenResolutionHeight") != 0)
            Screen.SetResolution(PlayerPrefs.GetInt("ScreenResolutionWidth"), PlayerPrefs.GetInt("ScreenResolutionHeight"), PlayerPrefs.GetInt("ScreenMode") == 1);
    }
}
