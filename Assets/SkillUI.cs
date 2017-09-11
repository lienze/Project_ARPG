using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    private UILabel skillNameLabel;
    private UILabel skillDesLabel;
    private UIButton closeButton;
    private UIButton upgradeButton;
    private UILabel upgradeButtonLabel;
    private Skill skill;

    void Awake(){
        skillNameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        upgradeButtonLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();
        skillNameLabel.text = "";
        skillDesLabel.text = "";

        DisableUpgradeButton("选择技能");

        EventDelegate ed = new EventDelegate(this, "OnUpgrade");
        upgradeButton.onClick.Add(ed);
    }

    void DisableUpgradeButton(string label=""){
        upgradeButton.SetState(UIButton.State.Disabled,true);
        upgradeButton.GetComponent<BoxCollider>().enabled = false;
        if (label != "") {
            upgradeButtonLabel.text = label;
        }
    }

    void EnableUpgradeButton(string label=""){
        upgradeButton.SetState(UIButton.State.Normal,true);
        upgradeButton.GetComponent<BoxCollider>().enabled = true;
        if (label != "") {
            upgradeButtonLabel.text = label;
        }
    }

    void OnSkillClick(Skill skill){
        this.skill = skill;
        PlayerInfo info = PlayerInfo._instance;
        if ((500 * (skill.Level + 1)) <= info.Coin) {
            if (skill.Level < info.Level) {
                EnableUpgradeButton("升级");
            } else {
                DisableUpgradeButton("最大等级");
            }
        } else {
            DisableUpgradeButton("金币不足");
        }
        skillNameLabel.text = skill.Name + "Lv." + skill.Level;
        skillDesLabel.text = "当前技能的攻击力为：" + (skill.Damage * skill.Level) + "下一级技能的攻击力为：" + (skill.Damage * skill.Level)+"升级所需要的金币数："+(skill.Damage*(skill.Level+1));
    }

    void OnUpgrade(){
        PlayerInfo info = PlayerInfo._instance;
        if (skill.Level < info.Level) {
            int coinNeed = (500 * (skill.Level + 1));
            bool isSuccess = info.GetCoin(coinNeed);
            if (isSuccess) {
                skill.Upgrade();
                OnSkillClick(skill);
            } else {
                DisableUpgradeButton("金币不足");
            }
        } else {
            DisableUpgradeButton("最大等级");
        }

    }
}
