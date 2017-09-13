using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTranscript : MonoBehaviour {

    public int id;
    public int needLevel;
    public string sceneName;

    public string des = "这里是一个阴森恐怖的地方，你敢来吗？";

    public void OnClick(){
        transform.parent.SendMessage("OnBtnTranscriptClick", this);
    }
}
