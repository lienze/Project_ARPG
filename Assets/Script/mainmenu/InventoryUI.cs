using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();

    void Awake() {
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
    }

    void OnDestory() {
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;

    }

    void OnInventoryChange() {
        UpdateShow();
    }

    void UpdateShow() {
        for (int i = 0; i < InventoryManager._instance.inventoryItemList.Count; i++) {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            itemUIList[i].SetInventoryItem(it);
        }
        for (int i = InventoryManager._instance.inventoryItemList.Count; i < itemUIList.Count; i++) {
            itemUIList[i].Clear();
        }
    }
}
