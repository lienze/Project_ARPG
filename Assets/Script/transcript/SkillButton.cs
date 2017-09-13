using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

    public PosType posType = PosType.Basic;

    private PlayerAnimation playerAnimation;

    void Awake(){
        playerAnimation = TranscriptManager._instance.player.GetComponent<PlayerAnimation>();
    }

    void OnPress(bool isPress){
        playerAnimation.OnAttackButtonClick(isPress, posType);
    }
}
