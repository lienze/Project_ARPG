using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {

    private EquipPopup equipPopup;

    void Awake(){
        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
    }

    public void OnInventoryClick(object[] objectArray){
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isLeft = (bool)objectArray[1];

        equipPopup.Show(it, isLeft);
    }
}
