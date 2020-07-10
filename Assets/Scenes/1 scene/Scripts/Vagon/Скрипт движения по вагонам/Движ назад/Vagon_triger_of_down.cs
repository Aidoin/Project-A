using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon_triger_of_down : MonoBehaviour
{
    private float X, Y, Z; // Координаты

    private GameObject vagon_top, vagon_top_medl, vagon_medl, vagon_medl_bot, vagon_bot, vagon, // Вагоны
        this_trigger; // Этот скрипт

    private void OnTriggerEnter(Collider player) // выполняется при косании тригера
    {
        if (player.tag == "Player") // Если в тригер входит игрок
        {

            vagon_top = GameObject.FindWithTag("vagon_top"); // Первый вагон
            vagon_top_medl = GameObject.FindWithTag("vagon_top_medl"); // Передпервый вагон
            vagon_medl = GameObject.FindWithTag("vagon_medl"); // Центральный вагон
            vagon_medl_bot = GameObject.FindWithTag("vagon_medl_bot"); // Предпоследний вагон
            vagon_bot = GameObject.FindWithTag("vagon_bot"); // Последний вагон

            this_trigger = GameObject.FindWithTag("vagon_trigger_of"); // Привоение переменной этого скпипта

            Destroy(vagon_top); // Уничтожение переднего вагона
            X = vagon_medl.gameObject.transform.position.x; Y = vagon_medl.gameObject.transform.position.y; Z = vagon_medl.gameObject.transform.position.z; // Присвоение координат центрального вагона
            Instantiate(Settings.vagon, new Vector3(X - 21, Y, Z), transform.rotation); // Создание нового вагона сзади

            vagon = GameObject.FindWithTag("vagon"); // Привоение нового вагона

            // Смещение тегов вперёд
            vagon_top_medl.tag = "vagon_top";
            vagon_medl.tag = "vagon_top_medl";
            vagon_medl_bot.tag = "vagon_medl";
            vagon_bot.tag = "vagon_medl_bot";
            vagon.tag = "vagon_bot"; // Присвоение тега последнего вагона новому вагону

            X = vagon_medl_bot.gameObject.transform.position.x; Y = vagon_medl_bot.gameObject.transform.position.y; Z = vagon_medl_bot.gameObject.transform.position.z; // Присвоение координат предыдущего вагона
            Instantiate(Settings.trigger_move, new Vector3(X, Y, Z), transform.rotation); // Создание тригра перехода


            Destroy(this_trigger); // Удаление этого тригера
        }
    }
}
