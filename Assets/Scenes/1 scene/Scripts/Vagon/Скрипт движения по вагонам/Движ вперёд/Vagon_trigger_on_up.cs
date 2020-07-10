using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon_trigger_on_up : MonoBehaviour
{
    private float X, Y, Z; // Координаты

    private GameObject vagon_top, vagon_top_medl, vagon_medl, vagon_medl_bot, vagon_bot, vagon, // Вагоны
        this_trigger; // Этот скрипт

    private void OnTriggerEnter(Collider player) // выполняется при косании тригера
    {   
        if(player.tag =="Player") // Если в тригер входит игрок
        {

            vagon_top = GameObject.FindWithTag("vagon_top"); // Первый вагон
            vagon_top_medl = GameObject.FindWithTag("vagon_top_medl"); // Передпервый вагон
            vagon_medl = GameObject.FindWithTag("vagon_medl"); // Центральный вагон
            vagon_medl_bot = GameObject.FindWithTag("vagon_medl_bot"); // Предпоследний вагон
            vagon_bot = GameObject.FindWithTag("vagon_bot"); // Последний вагон

            this_trigger = GameObject.FindWithTag("vagon_trigger_on"); // Привоение переменной этого скпипта

            Destroy(vagon_bot); // Уничтожение заднего вагона
            X = vagon_medl.gameObject.transform.position.x; Y = vagon_medl.gameObject.transform.position.y; Z = vagon_medl.gameObject.transform.position.z; // Присвоение координат центрального вагона
            Instantiate(Settings.vagon, new Vector3(X + 21, Y, Z), transform.rotation); // Создание нового вагона спереди

            vagon = GameObject.FindWithTag("vagon"); // Привоение нового вагона

            // Смещение тегов вперёд
            vagon.tag = "vagon_top"; // Присвоение тега первого вагона новому вагону
            vagon_top.tag = "vagon_top_medl";
            vagon_top_medl.tag = "vagon_medl";
            vagon_medl.tag = "vagon_medl_bot";
            vagon_medl_bot.tag = "vagon_bot";

            X = vagon_top_medl.gameObject.transform.position.x; Y = vagon_top_medl.gameObject.transform.position.y; Z = vagon_top_medl.gameObject.transform.position.z; // Присвоение координат следующего вагона
            Instantiate(Settings.trigger_move, new Vector3(X, Y, Z), transform.rotation); // Создание тригра перехода

            
            Destroy(this_trigger); // Удаление этого тригера
        }
    }
}
