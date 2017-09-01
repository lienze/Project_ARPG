using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonBar : MonoBehaviour {

    private UIButton knapsackButton;

    void Awake(){
        knapsackButton = transform.Find("Knapsack").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this,"OnKnapsack");
        knapsackButton.onClick.Add(ed1);
    }

    void OnKnapsack(){
        Knapsack._instance.Show();
    }
}
