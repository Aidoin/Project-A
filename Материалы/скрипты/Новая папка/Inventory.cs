using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;

    public GameObject cellContainer;
    public PlayerController player;
    public GameObject point;
    


    public GameObject massageManager;
    public GameObject massage;


    // Start is called before the first frame update
    void Start()
    {

        item = new List<Item>();

        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
        TakeInventory();
        DisplayItems();
    }

    void ToggleInventory()
    {
        if (Input.GetButtonDown("ShowInventory"))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
                player.canСontrol = true;
                point.SetActive(true);
            }
            else
            {
                cellContainer.SetActive(true);
                player.canСontrol = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                point.SetActive(false);
            }
        }
    }

    void MiniMassage(Item currentItem)
    {
        GameObject miniMassage = Instantiate(massage);
        miniMassage.transform.SetParent(massageManager.transform);
        Image img =  miniMassage.transform.GetChild(0).GetComponent<Image>();
        Text msg = miniMassage.transform.GetChild(1).GetComponent<Text>();

        img.sprite = Resources.Load<Sprite>(currentItem.pathIcon);
        msg.text = currentItem.nameItem;

    }


    void TakeInventory()
    {
        if (Input.GetButtonDown("TakeBotton"))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2.5f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item currentItem = hit.collider.GetComponent<Item>();

                    MiniMassage(currentItem);

                    AddItem(currentItem);
                }
            }
        }
    }

    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable == true)
        {
            AddItemsStackable(currentItem);
        }
        else
        {
            AddItemsUnStackable(currentItem);
        }
    }
    

    void AddItemsUnStackable(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == 0)
            {
                item[i] = currentItem;
                Destroy(currentItem.gameObject);
                DisplayItems();
                break;
            }
        }
    }

    void AddItemsStackable(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == currentItem.id)
            {
                item[i].countItem = item[i].countItem + currentItem.countItem;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        AddItemsUnStackable(currentItem);
    }

    public void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform countItem = icon.GetChild(0);

            Text txt = countItem.GetComponent<Text>();
            Image img = icon.GetComponent<Image>();


            if (item[i].id != 0)
            {
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
                img.enabled = true;

                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();
                }
                else
                {
                    txt.text = null;
                }
                
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }

}
