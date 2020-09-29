using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{ 
    public GameObject[] saves = new GameObject[6];
    public Sprite gameActiv;

    int saveSelected = 0;
    float saveSelectedTime;

    string saveFilePath;


    void Start()
    {
        for (int i = 0; i < 6; i++) // Подгрузка информация о сохранениях
        {
            saveFilePath = Application.persistentDataPath + "/Saves/Game" + (i + 1) + ".save";

            if (File.Exists(saveFilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(saveFilePath, FileMode.Open);

                Save save = (Save)bf.Deserialize(fs);

                fs.Close();

                saves[i].transform.GetChild(0).GetComponent<Image>().sprite = gameActiv;
                saves[i].transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
                saves[i].transform.GetChild(2).GetComponent<Scrollbar>().size = save.progressOfPassing;
            }
        }
    }


    public void Load(int noSave) // Загрузка сохранений
    {
        if (DoubleClickSaveLoad(noSave))
        {
            saveFilePath = Application.persistentDataPath + "/Saves/Game" + noSave + ".save";

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(saveFilePath, FileMode.Open);
            Save save = (Save)bf.Deserialize(fs);
            fs.Close();


            SceneManager.LoadScene("1Level");
        }
    }

    bool DoubleClickSaveLoad(int save) // Проверка даблклика
    {
        if (saveSelected == save)
        {
            if (Time.time - saveSelectedTime < 0.5)
            {
                return true;
            }
        }

        saveSelected = save;
        saveSelectedTime = Time.time;
        return false;
    }
}
