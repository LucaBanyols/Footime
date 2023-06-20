using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftInventoryManager : MonoBehaviour
{
    private LeftPlayerInventoryDisplay playerInventoryDisplay;
    private Dictionary<PickUp.PickUpType, int> items = new Dictionary<PickUp.PickUpType, int>();

    void Start()
    {
        playerInventoryDisplay = GetComponent<LeftPlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeInventory(items);
    }

    public void Add(PickUp pickup)
    {
        PickUp.PickUpType type = pickup.type;
        int oldTotal = 0;
        if (items.TryGetValue(type, out oldTotal))
            items[type] = oldTotal + 1;
        else
            items.Add (type, 1);

        playerInventoryDisplay.OnChangeInventory(items);
    }
}
