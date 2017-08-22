using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerProperty : MonoBehaviour
{

    public string ip = "127.0.0.1:7878";
    public string name
    {
        get {
            return name;
        }
        set {
            transform.Find("Label").GetComponent<UILabel>().text = value;
        }
    }
    public int count=100;



}
