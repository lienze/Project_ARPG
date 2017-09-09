using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType{
    Main,//主线任务
    Reward,//赏金任务
    Dally//日常任务
}

public enum TaskProgress{
    NoStart,
    Accept,
    Complete,
    Reward
}

public class Task {

    private int id;
    private TaskType taskType;
    private string name;
    private string icon;
    private string des;
    private int coin;
    private int diamond;
    private string talkNpc;
    private int idNpc;
    private int idTranscript;
    private TaskProgress taskProgress = TaskProgress.NoStart;

    public delegate void OnTaskChangeEvent();//定义了一个委托
    public event OnTaskChangeEvent OnTaskChage;//利用以上委托定义一个事件

    public int Id {
        get {
            return id;
        }
        set {
            id = value;
        }
    }

    public TaskType TaskTYPE {
        get {
            return taskType;
        }
        set {
            taskType = value;
        }
    }

    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    public string Icon {
        get {
            return icon;
        }
        set {
            icon = value;
        }
    }

    public string Des {
        get {
            return des;
        }
        set {
            des = value;
        }
    }

    public int Coin {
        get {
            return coin;
        }
        set {
            coin = value;
        }
    }

    public int Diamond {
        get {
            return diamond;
        }
        set {
            diamond = value;
        }
    }

    public string TalkNpc {
        get {
            return talkNpc;
        }
        set {
            talkNpc = value;
        }
    }

    public int IdNpc {
        get {
            return idNpc;
        }
        set {
            idNpc = value;
        }
    }

    public int IdTranscript {
        get {
            return idTranscript;
        }
        set {
            idTranscript = value;
        }
    }

    public TaskProgress TaskPROGRESS {
        get {
            return taskProgress;
        }
        set {
            if (taskProgress != value) {
                taskProgress = value;
                OnTaskChage();
            }

        }
    }
}
