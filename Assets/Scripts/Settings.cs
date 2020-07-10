using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{


    public float mous_sensetiviti = 2f; // Чувствитеьность мыши

    [HideInInspector]
    public float player_speed = 4f; // Скорость передвежения
    [HideInInspector]
    public float player_run = 1.5f; // Скорость бега добовляется к скорости движения
    [HideInInspector]
    public float player_jamp = 7f; // Высота прыжка
    [HideInInspector]
    public float graviti = 20f; // Гравитация
    [HideInInspector]
    public float slide = 0.2f; // Скольжение
    [HideInInspector]
    public float inertia = 0.01f; // Инерция в воздухе (чем меньше, тембольше инерция)
    [HideInInspector]
    public float gravityFois = -1f; // Гравитация

    public static GameObject vagon, trigger_move, trigger_on, trigger_of;
    [HideInInspector]
    public GameObject vagonn, trig_move, trig_on, trig_of;

    private void Awake()
    {
        
    }
    private void Start()
    {
        trigger_move = trig_move; trigger_on = trig_on; trigger_of = trig_of; vagon = vagonn;
    }
}
