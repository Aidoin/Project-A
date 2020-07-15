using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Computer : MonoBehaviour
{

    public GameObject windowPlayGame;
    public GameObject windowSettings;
    public GameObject windowExit;
    public KeyboardAndMouseSettings KeyBindings;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();

        if (!Directory.Exists(Application.persistentDataPath + "/Saves")) // Если Папки с сохранениями нет, она генирируется 
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }

        if (!PlayerPrefs.HasKey("KeyMotion1")) // Если переменных управления нет, они генирируются 
        {
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
        if (Input.GetButtonDown("Cancel"))
        {
            // Отключаем изменение клавиши
            if (KeyBindings.Rewrite)
                KeyBindings.UndoChanges();
            else
            {
                windowPlayGame.SetActive(false);
                windowSettings.SetActive(false);
                windowExit.SetActive(false);
            }
        }
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
