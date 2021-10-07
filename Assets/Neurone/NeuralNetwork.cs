using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;
using Random = System.Random;

public class NeuralNetwork : MonoBehaviour
{

    public Neurons qwe;

    private void Start()
    {
        qwe.play(6);

        //Random random = new Random();

        //double rand = random.Next(0, 100);
        //rand = rand / 100;
        //Debug.Log(qw);

       // Play();
    }




    void Play()
    {






        ////Neuron[,] network = new Neuron[2, 5];
        ////network[0, 0] = new Neuron();
        ////Debug.Log(network.Length);

        //////for (int i=0; i==(network.Length))

        //////int[,] network = new int[2, 2];
        //////network[0, 0] = 1;
        //////Debug.Log(network[0, 0]);
    }

    private double Sigmoid(double i)
    {
        return Round(1 / (1 + (1 / (Exp(i)))), 2);
    }
}
