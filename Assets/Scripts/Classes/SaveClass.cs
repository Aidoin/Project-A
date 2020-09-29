using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public bool active;
    public int Level;
    public float progressOfPassing;

    public string timeGameSave;

    public PlayerData Player = new PlayerData();



    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }


    [System.Serializable]
    public struct PlayerData
    {
        public Vec3 Position, Rotation;

        public PlayerData(Vec3 position, Vec3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}
