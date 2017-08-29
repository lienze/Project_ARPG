﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPopup : MonoBehaviour {

    private InventoryItem it;
    private UISprite equipSprite;
    private UILabel nameLabel;
    private UILabel qualityLabel;
    private UILabel damageLabel;
    private UILabel hpLabel;
    private UILabel powerLabel;
    private UILabel desLabel;

    void Awake() {
        equipSprite = transform.Find("EquipBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        qualityLabel = transform.Find("Quality/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageLabel/Label").GetComponent<UILabel>();
        hpLabel = transform.Find("HpLabel/Label").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel/Label").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();

    }

    public void Show(InventoryItem it, bool isLeft=true) {
        gameObject.SetActive(true);
        this.it = it;
        Vector3 pos = transform.localPosition;
        if (isLeft) {
            transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
        }
        else {
            transform.localPosition = new Vector3(Mathf.Abs(pos.x), pos.y, pos.z);
        }
        equipSprite.spriteName = it.Inventory.ICON;
        nameLabel.text = it.Inventory.Name;
        qualityLabel.text = it.Inventory.Quality.ToString();
        damageLabel.text = it.Inventory.Damage.ToString();
        hpLabel.text = it.Inventory.HP.ToString();
        powerLabel.text = it.Inventory.Power.ToString();
        desLabel.text = it.Inventory.Des;
    }
}
