using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour {

    public PosType posType;
    private Skill skill;
    private UISprite sprite;
    private UISprite Sprite{
        get{
            if (sprite == null) {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite;
        }
    }

    void Start(){
        UpdateShow();
    }

    void UpdateShow(){
        skill = SkillManager._instance.GetSkillByPosition(posType);
        Sprite.spriteName = skill.Icon;
    }
}
