using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static GameObject vagon, trigger_move, trigger_on, trigger_of;
    [HideInInspector]
    public GameObject vagonn, trig_move, trig_on, trig_of;


    private void Start()
    {
        trigger_move = trig_move; trigger_on = trig_on; trigger_of = trig_of; vagon = vagonn;
    }
}
