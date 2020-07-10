using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
    public static Vector3 vec = new Vector3(1, 0, 0);
    Rigidbody collis;

    Vector3 q;

    void Start()
    {
        collis = GetComponent<Rigidbody>();
        q = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        //transform.position += vec + cube2.vec * Time.deltaTime;

        //collis.velocity += q * Time.deltaTime * 5;

        //Debug.Log(Vector3.Cross(q, TimedeltaTime));

        //collis.AddForce(transform.forward, 5f);

    }

}
