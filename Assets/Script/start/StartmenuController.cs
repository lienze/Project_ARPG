using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartmenuController : MonoBehaviour {

	public TweenScale startpanelTween;
	public TweenScale loginpanelTween;
	public TweenScale registerpanelTween;
    public TweenScale serverpanelTween;
	public TweenPosition startpanelTweenPos;
	public TweenPosition characterselectTween;

	public UIInput usernameInputLogin;
	public UIInput passwordInputLogin;

	public UILabel usernameLabelStart;
    public UILabel servernameLabelStart;

	public static string username;
	public static string password;
    public static ServerProperty sp;

	public UIInput usernameInputRegister;
	public UIInput passwordInutRegister;
	public UIInput repasswordInputRegister;

    public UIGrid serverlistGrid;

    public GameObject serveritemRed;
    public GameObject serveritemGreen;

    private bool haveInitServerlist = false;

    public GameObject serverSelectedGo;

    void Start() {
        InitServerlist();//初始化服务器列表
    }

    public void OnUsernameClick(){
		//输入账号进行登录
		startpanelTween.PlayForward();
		StartCoroutine(HidePanel(startpanelTween.gameObject));
		loginpanelTween.gameObject.SetActive(true);
		loginpanelTween.PlayForward();
	}

	public void OnServerClick(){
        //选择服务器
        startpanelTween.PlayForward();
        StartCoroutine(HidePanel(startpanelTween.gameObject));
        serverpanelTween.gameObject.SetActive(true);
        serverpanelTween.PlayForward();
    }

    public void OnEnterGameClick(){
		//1.连接服务器，验证用户名和服务器
		//TODO

		//2.进入角色选择界面
		startpanelTweenPos.PlayForward();
		HidePanel(startpanelTweenPos.gameObject);
		characterselectTween.gameObject.SetActive(true);
		characterselectTween.PlayForward();
	}

	//隐藏面板
	IEnumerator HidePanel(GameObject go){
		yield return new WaitForSeconds(0.4f);
		go.SetActive(false);
	}

	public void OnLoginClick(){
		//得到用户名和密码 存储起来
		username = usernameInputLogin.value;
		password = passwordInputLogin.value;
		//返回开始界面
		loginpanelTween.PlayReverse();
		StartCoroutine(HidePanel(loginpanelTween.gameObject));
		startpanelTween.gameObject.SetActive(true);
		startpanelTween.PlayReverse();

		usernameLabelStart.text = username;
	}

	public void OnRegisterShowClick(){
		//隐藏当前面板
		loginpanelTween.PlayReverse();
		StartCoroutine(HidePanel(loginpanelTween.gameObject));
		registerpanelTween.gameObject.SetActive(true);
		registerpanelTween.PlayForward();
	}

	public void OnLoginCloseClick(){
		loginpanelTween.PlayReverse();
		StartCoroutine(HidePanel(loginpanelTween.gameObject));
		startpanelTween.gameObject.SetActive(true);
		startpanelTween.PlayReverse();

		usernameLabelStart.text = username;
	}

	public void OnCancelClick(){
		//隐藏注册面板
		registerpanelTween.PlayReverse();
		StartCoroutine(HidePanel(registerpanelTween.gameObject));
		//显示登录面板
		loginpanelTween.gameObject.SetActive(true);
		loginpanelTween.PlayForward();
	}

	public void OnRegisterCloseClick(){
		OnCancelClick();
	}

	public void OnRegisterAndLoginClick(){
		username = usernameInputRegister.value;
		password = passwordInutRegister.value;

		registerpanelTween.PlayReverse();
		StartCoroutine(HidePanel(registerpanelTween.gameObject));
		startpanelTween.gameObject.SetActive(true);
		startpanelTween.PlayReverse();

		usernameLabelStart.text = username;
    }

    public void InitServerlist() {
        if (haveInitServerlist) return;

        //1.连接服务器，取得游戏服务器列表信息
        //TODO
        //2.根据上面的信息 添加服务器列表
        
        for (int i = 0; i < 20; i++) {
            string ip = "127.0.0.1:9080";
            string name = (i + 1) + "区 马达加斯加";
            int count = Random.Range(0, 100);
            GameObject go = null;
            if (count > 50) {
                //火爆
                go = NGUITools.AddChild(serverlistGrid.gameObject, serveritemRed);
                
            }
            else {
                //流畅
                go = NGUITools.AddChild(serverlistGrid.gameObject, serveritemGreen);
            }
            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.ip = ip;
            sp.Name = name;
            sp.count = count;

            //serverlistGrid.gameObject.AddChild(go.transform);

        }

        haveInitServerlist = true;
    }

    public void OnServerselect(GameObject serverGo) {
        sp = serverGo.GetComponent<ServerProperty>();
        serverSelectedGo.GetComponent<UISprite>().spriteName = serverGo.GetComponent<UISprite>().spriteName;
        serverSelectedGo.transform.Find("Label").GetComponent<UILabel>().text = sp.Name;
    }

    public void OnServerpanelClose() {
        //隐藏服务器列表
        serverpanelTween.PlayReverse();
        StartCoroutine(HidePanel(serverpanelTween.gameObject));
        //显示开始界面
        startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayReverse();

        servernameLabelStart.text = sp.Name;
    }
}

