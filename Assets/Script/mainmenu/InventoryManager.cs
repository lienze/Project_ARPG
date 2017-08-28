using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager _instance;


    public TextAsset listinfo;
    public Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();
    //public Dictionary<int, InventoryItem> inventoryItemDict = new Dictionary<int, InventoryItem>();
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    void Awake() {
        _instance = this;
        ReadInventoryInfo();
        ReadInventoryItemInfo();
    }

    void ReadInventoryInfo() {
        string str = listinfo.ToString();
        string[] itemStrArray = str.Split('\n');
        int j = 0;
        foreach (string itemStr in itemStrArray) {
            if (j == 0) {
                j++;
                continue;
            }
            
            string[] proArray = itemStr.Split('|');
            Inventory inventory = new Inventory();
            inventory.ID = int.Parse(proArray[0]);
            inventory.Name = proArray[1];
            inventory.ICON = proArray[2];
            switch (proArray[3]) {
                case "Equip":
                    inventory.InventoryTYPE = InventoryType.Equip;
                    break;
                case "Drug":
                    inventory.InventoryTYPE = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryTYPE = InventoryType.Box;
                    break;
            }
            if (inventory.InventoryTYPE == InventoryType.Equip) {
                switch(proArray[4]){
                    case "Helm":
                        inventory.EquipTYPE = EquipType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipTYPE = EquipType.Cloth;
                        break;
                    case "Weapon":
                        inventory.EquipTYPE = EquipType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipTYPE = EquipType.Shoes;
                        break;
                    case "Necklace":
                        inventory.EquipTYPE = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipTYPE = EquipType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipTYPE = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipTYPE = EquipType.Wing;
                        break;
                }
            }
            inventory.Price = int.Parse(proArray[5]);
            if (inventory.InventoryTYPE == InventoryType.Equip) {
                inventory.StarLevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.HP = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            if (inventory.InventoryTYPE == InventoryType.Drug) {
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            inventory.Des = proArray[13];
            inventoryDict.Add(inventory.ID, inventory);
        }
    }

    //完成角色背包信息的初始化，获得拥有的物品
    void ReadInventoryItemInfo() {
        for (int j = 0; j < 20; j++) {
            int id = Random.Range(1001, 1020);
            Inventory i = null;
            inventoryDict.TryGetValue(id, out i);
            if (i.InventoryTYPE == InventoryType.Equip) {
                InventoryItem it = new InventoryItem();
                it.Inventory = i;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                inventoryItemList.Add(it);
            }
            else {
                InventoryItem it = null;
                bool isExit = false;
                foreach (InventoryItem temp in inventoryItemList) {
                    if (temp.Inventory.ID == id) {
                        isExit = true;
                        it = temp;
                        break;
                    }
                }
                if (isExit) {
                    it.Count++;
                }
                else {
                    it = new InventoryItem();
                    it.Inventory = i;
                    it.Count = 1;
                    inventoryItemList.Add(it);
                }
            }
        }
    }
}
