using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon_triger_down : MonoBehaviour
{
    private GameObject this_trigger;
    float X, Y, Z; // Переменные для получения координат

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            X = this.gameObject.transform.position.x; Y = this.gameObject.transform.position.y; Z = this.gameObject.transform.position.z;
            Instantiate(Settings.trigger_of, new Vector3(X, Y, Z), transform.rotation);

            this_trigger = GameObject.FindWithTag("vagon_trigger_move");
            Destroy(this_trigger);
        }
    }
}



















/*
 *  void OnTriggerEnter(Collider col)
    {
        X = this.gameObject.transform.position.x; Y = this.gameObject.transform.position.y; Z = this.gameObject.transform.position.z; // Получение координат тригера

        nobg = Глобальные_значения.plane_down_two;
        Destroy(nobg); // Удаляется объект с позиции 2, если его нет то ничего не делается
        Глобальные_значения.plane_down_two = Глобальные_значения.plane_down_one; // Переносит объект с позиции 1 в позицию 2
        Глобальные_значения.plane_down_one = obg; // Переносит объект в позицию 1

        obg.name = "платформа"; // Даёт имя объекту чтобы небыло (Clone)

        Instantiate(obg, new Vector3(X - 1.5f, Y, Z), transform.rotation); // Создание платформы на 1.5 спереди от тригера и персонажа
        Destroy(gameObject); // Уничтожение этоого триггера
    }
    */
