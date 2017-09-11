using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour {

    public PosType posType;
    private Skill skill;
    private UISprite sprite;
    private UIButton button;
    private UISprite Sprite{
        get{
            if (sprite == null) {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    private UIButton Button{
        get{
            if (button == null) {
                button = this.GetComponent<UIButton>();
            }
            return button;
        }
    }

    void Start(){
        UpdateShow();
    }

    void UpdateShow(){
        skill = SkillManager._instance.GetSkillByPosition(posType);
        Sprite.spriteName = skill.Icon;
        Button.normalSprite = skill.Icon;
    }

    void OnClick(){
        transform.parent.parent.SendMessage("OnSkillClick",skill);
    }
}
