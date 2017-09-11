using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    private UILabel skillNameLabel;
    private UILabel skillDesLabel;
    private UIButton closeButton;
    private UIButton upgradeButton;
    private UILabel upgradeButtonLabel;

    void Awake(){
        skillNameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        upgradeButtonLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();
        skillNameLabel.text = "";
        skillDesLabel.text = "";

        DisableUpgradeButton("选择技能");
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
}
