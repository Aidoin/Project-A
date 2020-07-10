using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon_triger_up : MonoBehaviour
{
    private GameObject this_trigger;
    float X,Y,Z; // Переменные для получения координат

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            X = this.gameObject.transform.position.x; Y = this.gameObject.transform.position.y; Z = this.gameObject.transform.position.z;
            Instantiate(Settings.trigger_on, new Vector3(X, Y, Z), transform.rotation);

            this_trigger = GameObject.FindWithTag("vagon_trigger_move");
            Destroy(this_trigger);
        }
    }
}
