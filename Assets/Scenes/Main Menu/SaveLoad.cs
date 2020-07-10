using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{ 
    public GameObject[] saves = new GameObject[6];

    public Sprite gameActiv;

    int saveSelected = 0;
    float saveSelectedTime;

    string saveFilePath;


    void Start()
    {
        //saves = new GameObject[] ;

        

        for (int i = 0; i < 6; i++)
        {
            saveFilePath = Application.persistentDataPath + "/save" + (i + 1) + ".gamesave";

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




    public void SaveGame()
    {
        saveFilePath = Application.persistentDataPath + "/save1.gamesave";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(saveFilePath, FileMode.Create);

        Save save = new Save();

        save.progressOfPassing = 0.001f;

        save.active = true;

        bf.Serialize(fs, save);

        fs.Close();

        Debug.Log(saveFilePath);
    }











    public bool DoubleClick(int save)
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


    public void Load(int save)
    {

        if (DoubleClick(save))
        {
            Debug.Log("Загрузка " + save + "го сохранения");
        }

    }
}
