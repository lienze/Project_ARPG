﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {

    public static Knapsack _instance;

    private EquipPopup equipPopup;
    private InventoryPopup inventoryPopup;

    private UIButton saleButton;
    private UILabel priceLabel;

    private InventoryItem it;
    private InventoryItemUI itUI;
    private TweenPosition tween;
    private UIButton closeKnapsackButton;

    void Awake(){
        _instance = this;
        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();

        saleButton = transform.Find("Inventory/ButtonSale").GetComponent<UIButton>();
        priceLabel = transform.Find("Inventory/PriceBg/Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenPosition>();
        closeKnapsackButton = transform.Find("CloseButton").GetComponent<UIButton>();
        DisableButton();
        priceLabel.text = "";

        EventDelegate ed = new EventDelegate(this,"OnSale");
        saleButton.onClick.Add(ed);

        EventDelegate ed2 = new EventDelegate(this,"OnKnapsackClose");
        closeKnapsackButton.onClick.Add(ed2);
    }

    public void OnInventoryClick(object[] objectArray){
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isLeft = (bool)objectArray[1];
        if (it.Inventory.InventoryTYPE == InventoryType.Equip) {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isLeft == true) {
                itUI = objectArray[2] as InventoryItemUI;
            } else {
                roleEquip = objectArray[2] as KnapsackRoleEquip;
            }
            inventoryPopup.Close();
            equipPopup.Show(it, itUI, roleEquip, isLeft);
        } else {
            InventoryItemUI itUI = objectArray[2] as InventoryItemUI;
            equipPopup.Close();
            inventoryPopup.Show(it,itUI);
        }

        if ((it.Inventory.InventoryTYPE == InventoryType.Equip && isLeft == true)||(it.Inventory.InventoryTYPE != InventoryType.Equip)) {
            this.itUI = objectArray[2] as InventoryItemUI;
            EnableButton();
            priceLabel.text = (this.itUI.it.Inventory.Price * this.itUI.it.Count).ToString();
        }
    }

    public void Show(){
        tween.PlayForward();
    }
    public void Hide(){
        tween.PlayReverse();
    }

    void DisableButton(){
        saleButton.SetState(UIButtonColor.State.Disabled, true);
        saleButton.GetComponent<BoxCollider>().enabled = false;
        priceLabel.text = "";
    }

    void EnableButton(){
        saleButton.SetState(UIButtonColor.State.Normal, true);
        saleButton.GetComponent<BoxCollider>().enabled = true;
    }

    void OnSale(){
        int price = int.Parse(priceLabel.text);
        PlayerInfo._instance.AddCoin(price);

        InventoryManager._instance.RemoveInventoryItem(itUI.it);
        itUI.Clear();

        equipPopup.Close();
        inventoryPopup.Close();
        DisableButton();
    }
    void OnKnapsackClose(){
        Hide();
    }
}
