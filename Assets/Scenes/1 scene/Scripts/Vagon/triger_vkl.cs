using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger_vkl : MonoBehaviour
{
    private float X, Y, Z;
    private GameObject obg;
    void OnTriggerEnter(Collider col)
    {
        obg = Settings.trigger_on;
        X = obg.gameObject.transform.position.x; Y = obg.gameObject.transform.position.y; Z = obg.gameObject.transform.position.z;
        Instantiate(Settings.trigger_on, new Vector3(X, Y, Z), transform.rotation); // Создание платформы на 1.5 спереди от тригера и персонажа
        Destroy(obg);
    }
}
