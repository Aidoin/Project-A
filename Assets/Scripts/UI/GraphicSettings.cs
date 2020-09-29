using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{

    [Header("Качество графики")]
    public Dropdown graphics;
    [Header("Разрешение экрана")]
    public Dropdown screenResolution;
    [Header("Полноэкранный режим")]
    public Toggle fullScreen;
    [Header("Поле зрения")]
    public Slider fieldOfView;
    public Text textFOV;
    public Camera mainCamera;

    List<Resolution> resList = new List<Resolution>();
    List<string> resStr = new List<string>();
    Resolution[] res;


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
                    resList.Add(resS[i]);
                    resStr.Add(resS[i].width.ToString() + " x " + resS[i].height.ToString());
                }
            }

            if (resStr.Count == 0) // Если разрешения не были найдены
            {
                Resolution res = new Resolution();

                if (!PlayerPrefs.HasKey("ScreenResolutionWidth") || !PlayerPrefs.HasKey("ScreenResolutionHeight"))
                {
                    res.width = Screen.width;
                    res.height = Screen.height;
                    resList.Add(res);
                    resStr.Add(res.width + "X" + res.height);
                }
                else
                {
                    res.width = PlayerPrefs.GetInt("ScreenResolutionWidth");
                    res.height = PlayerPrefs.GetInt("ScreenResolutionHeight");
                    resList.Add(res);
                    resStr.Add(PlayerPrefs.GetInt("ScreenResolutionWidth") + "X" + PlayerPrefs.GetInt("ScreenResolutionHeight"));

                    if (PlayerPrefs.GetInt("ScreenResolutionWidth") != Screen.width && PlayerPrefs.GetInt("ScreenResolutionHeight") != Screen.height)
                    {
                        res.width = Screen.width;
                        res.height = Screen.height;
                        resList.Add(res);
                        resStr.Add(res.width + "X" + res.height);
                    }
                }
            }
        }
    }


    void Start()
    {
        ///////////////////////////////////////////////////////////////////////////// Graphics
        {
            graphics.ClearOptions();
            graphics.AddOptions(QualitySettings.names.ToList());

            if (PlayerPrefs.HasKey("GraphicsQuality")) 
                graphics.value = PlayerPrefs.GetInt("GraphicsQuality");
            else 
                graphics.value = 3;
        }

        ///////////////////////////////////////////////////////////////////////////// ScreenResolution
        {
            res = resList.ToArray();
            screenResolution.ClearOptions();
            screenResolution.AddOptions(resStr);


            try // Отсечение ошибки если происходит запуск игры с новыми разрешениями экрана
            {
                if (PlayerPrefs.HasKey("Resolution"))
                    screenResolution.value = PlayerPrefs.GetInt("Resolution");
                else
                    screenResolution.value = 0;
            }
            catch
            {
                // Юнити сама возвращает наименьшее значение, эта часть кода бесполезна
                Debug.Log("Сработало? Разрешение в графиксеттингсе");
                screenResolution.value = 0;
                Screen.SetResolution(res[0].width, res[0].height, Screen.fullScreen);
            }

            if (PlayerPrefs.HasKey("ScreenMode"))
            {
                if (PlayerPrefs.GetInt("ScreenMode") == 1)
                {
                    Screen.fullScreen = true;
                    fullScreen.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreen.isOn = false;
                }
            }
            else
            {
                Screen.fullScreen = true;
                fullScreen.isOn = true;
            }
        }

        ///////////////////////////////////////////////////////////////////////////// MainCamera
        {
            if (PlayerPrefs.HasKey("FieldOfView"))
            {
                fieldOfView.value = PlayerPrefs.GetInt("FieldOfView");
                textFOV.text = fieldOfView.value.ToString();
            }
            else
            {
                fieldOfView.value = 60;
                textFOV.text = "60";
            }
        }
    }


    public void SetScreenMode() // Режим экрана (оконный\полноэкранных)
    {
        Screen.fullScreen = fullScreen.isOn;

        if (Screen.fullScreen == true)
        {
            PlayerPrefs.SetInt("ScreenMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ScreenMode", 0);
        }
    }

    public void SetResolution() // Выставление разрешения экрана
    {
        Screen.SetResolution(res[screenResolution.value].width, res[screenResolution.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", screenResolution.value);

        PlayerPrefs.SetInt("ScreenResolutionWidth", res[screenResolution.value].width);
        PlayerPrefs.SetInt("ScreenResolutionHeight", res[screenResolution.value].height);
    }

    public void SetGraphics() // Выставление графики
    {
        QualitySettings.SetQualityLevel(graphics.value);
        PlayerPrefs.SetInt("GraphicsQuality", graphics.value);
    }

    public void SetSliderFOV() // Выставление поля зрения
    {
        textFOV.text = ((int)fieldOfView.value).ToString();
        PlayerPrefs.SetInt("FieldOfView", (int)fieldOfView.value);
        if (mainCamera != null)
            mainCamera.fieldOfView = PlayerPrefs.GetInt("FieldOfView");
    }
}
