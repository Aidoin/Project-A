using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SaveGame : MonoBehaviour
{

    public GameObject[] saves = new GameObject[6];
    public GameObject DialodSave;
    public Text noGame;

    int activSave = 0;
    string saveFilePath;

    void Start()
    {
        SaveUpdate();
    }

    void SaveUpdate()
    {
        for (int i = 0; i < 6; i++) // Подгрузка информации о сохранениях
        {
            saveFilePath = Application.persistentDataPath + "/Saves/Game" + (i + 1) + ".save";

            if (File.Exists(saveFilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(saveFilePath, FileMode.Open);

                Save save = (Save)bf.Deserialize(fs);

                fs.Close();

                saves[i].transform.GetChild(2).GetComponent<Text>().text = Convert.ToInt32(save.progressOfPassing * 100).ToString() + "%";
                saves[i].transform.GetChild(3).GetComponent<Text>().text = save.timeGameSave.ToString();
            }
        }
    }

    public void ShowDialodSave(int noSave)
    {
        activSave = noSave;
        noGame.text = "Game " + noSave.ToString();
        DialodSave.SetActive(true);
    }

    public void Save() 
    {
        saveFilePath = Application.persistentDataPath + "/Saves/Game" + activSave + ".save";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(saveFilePath, FileMode.Create);

        Save save = new Save();

        save.active = true;
        save.Level = 1;
        save.progressOfPassing = 0.001f;
        save.timeGameSave = DateTime.Now.ToString("dd/MM/yyyy " + " HH:mm");



        bf.Serialize(fs, save);

        fs.Close();

        SaveUpdate();
    }
}
