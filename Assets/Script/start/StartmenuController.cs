using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartmenuController : MonoBehaviour {

	public TweenScale startpanelTween;
	public TweenScale loginpanelTween;
	public TweenScale registerpanelTween;

	public UIInput usernameInputLogin;
	public UIInput passwordInputLogin;

	public UILabel usernameLabelStart;

	public static string username;
	public static string password;

	public UIInput usernameInputRegister;
	public UIInput passwordInutRegister;
	public UIInput repasswordInputRegister;

	public void OnUsernameClick(){
		//输入账号进行登录
		startpanelTween.PlayForward();
		StartCoroutine(HidePanel(startpanelTween.gameObject));
		loginpanelTween.gameObject.SetActive(true);
		loginpanelTween.PlayForward();
	}

	public void OnServerClick(){
		//选择服务器
		//TODO
	}

	public void OnEnterGameClick(){
		//1.连接服务器，验证用户名和服务器
		//TODO

		//2.进入角色选择界面
		//TODO
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
}

