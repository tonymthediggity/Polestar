using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        

        if(instance != null)
        {
            Debug.LogWarning("More than one Inventory Instance Found!!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange OnItemChangeCallBack;

    public int space = 20;

   


    public List<Item> invItems = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(invItems.Count >= space)
            {
                Debug.Log("Not Enough Space");
                return false;
            }

            invItems.Add(item);

            if(OnItemChangeCallBack != null)
            OnItemChangeCallBack.Invoke();
        }
        return true;
        

        }

    public void Remove(Item item)
    {

        invItems.Remove(item);
        if (OnItemChangeCallBack != null)
            OnItemChangeCallBack.Invoke();
    }

    }







