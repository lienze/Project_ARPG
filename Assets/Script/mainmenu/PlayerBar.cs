using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour {

    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UISlider energySlider;
    private UILabel energyLabel;
    private UISlider toughenSlider;
    private UILabel toughenLabel;
    private UIButton energyPlusButton;
    private UIButton toughtenPlusButton;

    void Awake() {
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = transform.Find("EnergyProgressBar").GetComponent<UISlider>();
        energyLabel = transform.Find("EnergyProgressBar/Label").GetComponent<UILabel>();
        toughenSlider = transform.Find("ToughenProgressBar").GetComponent<UISlider>();
        toughenLabel = transform.Find("ToughenProgressBar/Label").GetComponent<UILabel>();
        energyPlusButton = transform.Find("EnergyPlusButton").GetComponent<UIButton>();
        toughtenPlusButton = transform.Find("ToughenPlusButton").GetComponent<UIButton>();
    }

    void Start() {
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    void OnDestory() {
        PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;

    }

    //当我们的主角信息发生改变的时候会触发这个方法
    void OnPlayerInfoChanged(InfoType type) {
        if (type == InfoType.All|| type == InfoType.Name || type == InfoType.HeadPortrait || type == InfoType.Level || type == InfoType.Energy || type == InfoType.Toughen) {
            UpdateShow();
        }
    }

    //更新显示
    void UpdateShow() {
        PlayerInfo info = PlayerInfo._instance;
        headSprite.spriteName = info.HeadProtrait;
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name.ToString();
        energySlider.value = info.Energy / 100f;
        energyLabel.text = info.Energy + "/100";
        toughenSlider.value = info.Toughten / 100f;
        toughenLabel.text = info.Toughten + "/50";
    }
}
