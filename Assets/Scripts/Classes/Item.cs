using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    public int countItem;
    public bool isStackable;

    [Multiline(10)]
    public string descriptionItem;
    public string pathIcon;
    public string pathPrefab;
}
