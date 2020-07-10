using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public int index;

    GameObject inventopyObg;
    Inventory inventory;

    void Start()
    {
        inventopyObg = GameObject.FindGameObjectWithTag("InventoryManager");
        inventory = inventopyObg.GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject dropedObg = Instantiate(Resources.Load<GameObject>(inventory.item[index].pathPrefab));
            dropedObg.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            inventory.item[index].countItem--;
            inventory.DisplayItems();
        }
    }
}
