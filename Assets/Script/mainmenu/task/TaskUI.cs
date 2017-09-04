using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {
    public static TaskUI _instance;
    private UIGrid taskListGrid;
    public TweenPosition tween;
    private UIButton closeButton;
    public GameObject taskItemPrefab;


    void Awake(){
        _instance = this;
        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        tween = this.GetComponent<TweenPosition>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);
    }

    void Start(){
        InitTaskList();
    }

    /// <summary>
    /// 初始化任务列表信息
    /// </summary>
    void InitTaskList(){
        ArrayList taskList = TaskManager._instance.GetTaskList();

        foreach(Task task in taskList){
            GameObject go = NGUITools.AddChild(taskListGrid.gameObject,taskItemPrefab);
            taskListGrid.AddChild(go.transform);
            TaskItemUI ti = go.GetComponent<TaskItemUI>();
            ti.SetTask(task);
        }
    }

    public void Show(){
        tween.PlayForward();
    }

    public void Hide(){
        tween.PlayReverse();
    }

    void OnClose(){
        Hide();
    }
}
