using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public LayerMask whatCanKlikcrdOn;

    private NavMeshAgent myAgent;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(myRay, out hit, 100, whatCanKlikcrdOn))
            {
                myAgent.SetDestination(hit.point);
            }
        }

    }

}
