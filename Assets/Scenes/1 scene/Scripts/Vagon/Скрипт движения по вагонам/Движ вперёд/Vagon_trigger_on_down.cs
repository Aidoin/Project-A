using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon_trigger_on_down : MonoBehaviour // Возвращение в вагон
{
    private float X, Y, Z; // Координаты
    
    private GameObject vagon_medl, // Центральный вагон
        this_trigger; // Этот скрипт

    private void OnTriggerEnter(Collider player) // выполняется при косании тригера
    {
        if (player.tag == "Player") // Если в тригер входит игрок
        {
            this_trigger = GameObject.FindWithTag("vagon_trigger_on"); // Привоение переменной этого скпипта
            vagon_medl = GameObject.FindWithTag("vagon_medl"); // Центральный вагон

            X = vagon_medl.gameObject.transform.position.x; Y = vagon_medl.gameObject.transform.position.y; Z = vagon_medl.gameObject.transform.position.z; // Присвоение координат центрального вагона
            Instantiate(Settings.trigger_move, new Vector3(X, Y, Z), transform.rotation); // Создание тригра перехода


            Destroy(this_trigger); // Удаление этого тригера
        }
    }
}
