using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{

    public Dropdown graphics;
    public Dropdown screenResolution;
    public Toggle fullScreen;
    public Slider fieldOfView;
    public Text TextFOV;
    public GameObject BottonFOV;
    
    int refreshRate = 60;

    Resolution[] res;

    

    void Start()
    {
        PlayerPrefs.DeleteAll();

        ///////////////////////////////////////////////////////////////////////////// Graphics
        {
            graphics.ClearOptions();
            graphics.AddOptions(QualitySettings.names.ToList());

            if (PlayerPrefs.HasKey("Graphics"))
            {
                graphics.value = PlayerPrefs.GetInt("Graphics");
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Graphics"));
            }
            else
            {
                graphics.value = QualitySettings.GetQualityLevel();
            }
        }

        ///////////////////////////////////////////////////////////////////////////// ScreenResolution
        {

            List<Resolution> resList = new List<Resolution>();
            List<string> strRes = new List<string>();

            Resolution[] resS;

            resS = Screen.resolutions.Reverse().ToArray();

            for (int i = 0; i < resS.Length; i++)
            {
                if (resS[i].refreshRate == refreshRate)
                {
                    resList.Add(resS[i]);
                    strRes.Add(resS[i].width.ToString() + " x " + resS[i].height.ToString());
                }
            }

            res = resList.ToArray();

            screenResolution.ClearOptions();
            screenResolution.AddOptions(strRes);

            if (PlayerPrefs.HasKey("Resolution")) // Если настройки при первом запуске были изменены
            {
                try // Отсечение ошибки если происходит запуск игры с новыми разрешениями экрана
                {
                    screenResolution.value = PlayerPrefs.GetInt("Resolution");
                    Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width, res[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
                }
                catch 
                {try 
                    {
                        screenResolution.value = 0;
                        Screen.SetResolution(res[0].width, res[0].height, Screen.fullScreen);
                    } 
                 catch { Debug.Log("Разрешения экрана не найдены"); }
                }
            }
            else // Если настройки при первом запуске не были изменены
            {
                screenResolution.value = 0;
                Screen.SetResolution(res[0].width, res[0].height, Screen.fullScreen);
            }

            if (PlayerPrefs.HasKey("ScreenMode")) // Если настройки при первом запуске были изменены
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
            else // Если настройки при первом запуске не были изменены
            {
                Screen.fullScreen = true;
                fullScreen.isOn = true;
            }
        }

        ///////////////////////////////////////////////////////////////////////////// MainCamera
        {
            if (PlayerPrefs.HasKey("FieldOfView"))
            {
                fieldOfView.value = PlayerPrefs.GetFloat("FieldOfView");
                TextFOV.text = fieldOfView.value.ToString();
            }
            else
            {
                fieldOfView.value = 80;
                TextFOV.text = "80";
            }
            BottonFOV.SetActive(false);
        }
    }



    public void SetScreenMode()
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

    public void SetResolution()
    {
        Screen.SetResolution(res[screenResolution.value].width, res[screenResolution.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", screenResolution.value);
    }

    public void SetGraphics()
    {
        QualitySettings.SetQualityLevel(graphics.value);
        PlayerPrefs.SetInt("Graphics", graphics.value);
    }

    public void SetSliderFOV()
    {
        TextFOV.text = fieldOfView.value.ToString();
        BottonFOV.SetActive(true);
    }

    public void SetFieldOfView()
    {
        PlayerPrefs.SetFloat("FieldOfView", fieldOfView.value);
        BottonFOV.SetActive(false);
    }
}
