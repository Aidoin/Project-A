using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    [Header("Старт игры")]
    public StartGame resolution;
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

    Resolution[] res;

    
    void Start()
    {
        Debug.Log(QualitySettings.pixelLightCount);
        QualitySettings.pixelLightCount = 5;
        Debug.Log(QualitySettings.pixelLightCount);

        ///////////////////////////////////////////////////////////////////////////// Graphics
        {
            graphics.ClearOptions();
            graphics.AddOptions(QualitySettings.names.ToList());

            graphics.value = PlayerPrefs.GetInt("GraphicsQuality");
        }

        ///////////////////////////////////////////////////////////////////////////// ScreenResolution
        {
            res = resolution.resList.ToArray();
            screenResolution.ClearOptions();
            screenResolution.AddOptions(resolution.strRes);


            try // Отсечение ошибки если происходит запуск игры с новыми разрешениями экрана
            {
                screenResolution.value = PlayerPrefs.GetInt("Resolution");
            }
            catch
            {
                screenResolution.value = 0;
                Screen.SetResolution(res[0].width, res[0].height, Screen.fullScreen);
            }


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

        ///////////////////////////////////////////////////////////////////////////// MainCamera
        {
            fieldOfView.value = PlayerPrefs.GetInt("FieldOfView");
            textFOV.text = fieldOfView.value.ToString();
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
