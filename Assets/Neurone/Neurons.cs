using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using Random = System.Random;

public class Neurons : MonoBehaviour
{
    public Transform previousLayer;
    public Transform mineLayer;
    public Transform nextLayer;
    int mineID, numberLayers;
    int place;
    List<NandW> neuronsBefore = new List<NandW>();
    List<NandW> neuronsAfter = new List<NandW>();
    Random random = new Random();
    double rand;



    public class NandW
    {
        public GameObject name;
        public double weight;
    }

    private void Start()
    {
        mineID = gameObject.transform.parent.transform.GetSiblingIndex();
        numberLayers = gameObject.transform.parent.transform.parent.transform.childCount;

        mineLayer = gameObject.transform.parent.transform;
       

        if (mineID == 0)
        {
            nextLayer = gameObject.transform.parent.transform.parent.transform.GetChild(mineID + 1);
            place = 1;

            Transform[] tr = gameObject.transform.parent.transform.parent.transform.GetChild(mineID + 1).GetComponentsInChildren<Transform>();
            for (int i = 1; i != tr.Length; i++)
            {
                rand = random.Next(0, 100); rand = rand / 100;
                neuronsAfter.Add(new NandW { name = tr[i].gameObject, weight = rand });
            }
        }
        else if (mineID == numberLayers - 1)
        {
            previousLayer = gameObject.transform.parent.transform.parent.transform.GetChild(mineID - 1);
            place = 3;

            Transform[] tr = gameObject.transform.parent.transform.parent.transform.GetChild(mineID - 1).GetComponentsInChildren<Transform>();
            for (int i = 1; i != tr.Length; i++)
            {
                neuronsBefore.Add(new NandW { name = tr[i].gameObject });
            }
        }
        else
        {
            previousLayer = gameObject.transform.parent.transform.parent.transform.GetChild(mineID - 1);
            nextLayer = gameObject.transform.parent.transform.parent.transform.GetChild(mineID + 1);
            place = 2;

            Transform[] tr = gameObject.transform.parent.transform.parent.transform.GetChild(mineID - 1).GetComponentsInChildren<Transform>();
            for (int i = 1; i != tr.Length; i++)
            {
                neuronsBefore.Add(new NandW { name = tr[i].gameObject });
            }

            tr = gameObject.transform.parent.transform.parent.transform.GetChild(mineID + 1).GetComponentsInChildren<Transform>();
            for (int i = 1; i != tr.Length; i++)
            {
                rand = random.Next(0, 100); rand = rand / 100;
                neuronsAfter.Add(new NandW { name = tr[i].gameObject, weight = rand });
            }

        }



            {
                //efef 
                //efwe 
                //efw 

            }



        //Debug.Log(previousLayer.GetSiblingIndex() + " " + mineLayer.GetSiblingIndex() + " " + nextLayer.GetSiblingIndex());
        //Debug.Log("до - " + previousLayer.name + "    сейчас - " + mineLayer.name + "    след - " + nextLayer.name);

        //Debug.Log(previousLayer.GetSiblingIndex() + " " + mineLayer.GetSiblingIndex() );
        //Debug.Log("до - " + previousLayer.name + "    сейчас - " + mineLayer.name );

        //Debug.Log(place);
    }


    public void play(double ent)
    {
        Debug.Log("Слой " + mineLayer + " " + place);

        Debug.Log("Вошло у " + this.name + " В слое " + mineLayer.name + " = " + ent);



        if (place == 3)
        {
            Debug.Log("Конечная у " + this.name + " В слое " + mineLayer.name + "Итог = " + ent);
        }
        else
        {

            if(place == 1)
            {
                ent = Sigmoid(ent);
            }
            else
            {
                ent = Sigmoid(ent * neuronsAfter[0].weight);
                
            }


            

            






            Debug.Log("ушло у " + this.name + " В слое " + mineLayer.name + " = " + ent);
            neuronsAfter[0].name.transform.GetComponent<Neurons>().play(ent);
        }
    }

    private double Sigmoid(double i)
    {
        return Round(1 / (1 + (1 / (Exp(i)))), 2);
    }
}
