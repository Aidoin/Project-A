using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube2 : MonoBehaviour
{
    public static Vector3 vec = new Vector3(1, 0, 0);
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position += vec * Time.deltaTime;
    }
}
