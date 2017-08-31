using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour {
    public static MessageManager _instance;
    private UILabel messageLabel;
    private TweenAlpha tween;
    private bool isSetActive = true;

    void Awake(){
        _instance = this;
        messageLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();

        EventDelegate ed = new EventDelegate(this, "OnTweenFinished");
        tween.onFinished.Add(ed);

        gameObject.SetActive(false);
    }

    public void ShowMessage(string message,float time = 1.0f){
        gameObject.SetActive(true);
        StartCoroutine(Show(message, time));
    }

    IEnumerator Show(string message,float time){
        
        isSetActive = true;
        messageLabel.text = message;
        tween.PlayForward();
       
        yield return new WaitForSeconds(time);
        isSetActive = false;
        tween.PlayReverse();
    }

    public void OnTweenFinished(){
        if (isSetActive == false) {
            gameObject.SetActive(false);
        }
    }
}
