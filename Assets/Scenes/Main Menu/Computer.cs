using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public StartGame startGame;
    public GameObject windowPlayGame;
    public GameObject windowSettings;
    public GameObject windowExit;
    public KeyboardAndMouseSettings KeyBindings;

    private void Start()
    {
        PlayerPrefs.DeleteAll();


        if (!Directory.Exists(Application.persistentDataPath + "/Saves")) // Если Папки с сохранениями нет, она генирируется 
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }

        if (!PlayerPrefs.HasKey("GraphicsQuality")) // Если переменных управления нет, они генирируются 
        {
            // Настройки графики
            PlayerPrefs.SetInt("GraphicsQuality", 3);
            PlayerPrefs.SetInt("ScreenMode", 1);
            PlayerPrefs.SetInt("FieldOfView", 80);
            PlayerPrefs.SetInt("ScreenResolutionWidth", startGame.resList[0].width);
            PlayerPrefs.SetInt("ScreenResolutionHeight", startGame.resList[0].height);

            // Чувствительность мыши
            PlayerPrefs.SetFloat("MouseSensitivity", 10);

            // Клавиши управления
            PlayerPrefs.SetString("KeyMotion1", "w");
            PlayerPrefs.SetString("KeyMotion2", "s");
            PlayerPrefs.SetString("KeyMotion3", "a");
            PlayerPrefs.SetString("KeyMotion4", "d");
            PlayerPrefs.SetString("KeyMotion5", "space");
            PlayerPrefs.SetString("KeyMotion6", "left shift");
            PlayerPrefs.SetString("KeyMotion7", "e");
            PlayerPrefs.SetString("KeyMotion8", "i");
        }
    }

    private void Update()
    {
        // Отлавливает нажатие Escape
        if (Input.GetButtonDown("Cancel"))
        {
            // Отключаем в настройках изменение клавиш если оно активно
            if (KeyBindings.Rewrite)
                KeyBindings.UndoChanges();
            else
            { 
                // Сворачиваем окна в компьютере 
                windowPlayGame.SetActive(false);
                windowSettings.SetActive(false);
                windowExit.SetActive(false);
            }
        }
    }
    

    // Действие на кнопки с рабочего стола компьютера
    public void ShowPanel(GameObject obj) 
    {
        obj.SetActive(true);
    }

    // Действие на закрытие открытого окна крестиком
    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    // Действие на кнопку подтверждения выхода из игры
    public void Exit()
    {
        Application.Quit();
    }

}
