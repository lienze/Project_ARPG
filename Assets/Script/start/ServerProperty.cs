using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerProperty : MonoBehaviour
{

    public string ip = "127.0.0.1:7878";
    public string _name;
    public string Name
    {
        get {
            return _name;
        }
        set {
            _name = value;
            transform.Find("Label").GetComponent<UILabel>().text = value;
        }
    }
    public int count=100;


    public void OnPress(bool isPress) {
        if (isPress == false) {
            //选择了当前的服务器
            transform.root.SendMessage("OnServerselect", this.gameObject);
        }
    }
}
