using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
    public static TaskManager _instance;
    public TextAsset taskinfoText;
    private ArrayList taskList = new ArrayList();
    void Awake(){
        _instance = this;
        InitTask();
    }
    /// <summary>
    /// 初始化任务信息
    /// </summary>
    public void InitTask(){
        string[] taskinfoArray = taskinfoText.ToString().Split('\n');
        foreach (string str in taskinfoArray) {
            string[] proArray = str.Split('|');
            Task task = new Task();
            task.Id = int.Parse(proArray[0]);
            switch (proArray[1]) {
                case "Main":
                    task.TaskTYPE = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskTYPE = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskTYPE = TaskType.Dally;
                    break;
            }
            task.Name = proArray[2];
            task.Icon = proArray[3];
            task.Des = proArray[4];
            task.Coin = int.Parse(proArray[5]);
            task.Diamond = int.Parse(proArray[6]);
            task.IdNpc = int.Parse(proArray[8]);
            task.IdTranscript = int.Parse(proArray[9]);
            taskList.Add(task);
        }
    }

    public ArrayList GetTaskList(){
        return taskList;
    }
}
