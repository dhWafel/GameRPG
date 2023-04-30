using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class QuestController : MonoSingleton<QuestController>{

    public UnityAction onQuestChange {
        get;
        set;
    }

    public List<string> quests;
    public List<Game.Data.Quest> questList;


    private void Start() {
        quests = new List<string>();
        LoadQuest();
    }

    public void AddQuest() {
        quests.Add("grzybki");
        onQuestChange?.Invoke();
    }

    public void RemoveQuest() {
        if (quests.Count>0) {
            quests.RemoveAt(0);
            onQuestChange?.Invoke();
        }  
    }

    public void LoadQuest() {
        string path = Application.dataPath + Game.Const.c_questsPath;

        StreamReader sr = new StreamReader(path);
        if (sr != null) {
            int lineNumber = 0;
            while (!sr.EndOfStream) {
                var line = sr.ReadLine();
                if (lineNumber > 0) {
                    var values = line.Split(';');
                    Game.Data.Quest quest = new Game.Data.Quest();
                    quest.questName = values[0];
                    quest.questDiscription = values[1];
                    quest.questExp = int.Parse(values[2]);
                    //quest.questIsActive = Random.Range(0, 100) < 50;
                    //quest.questIsDone = Random.Range(0, 100) < 50;
                    questList.Add(quest);
                }
                lineNumber++;
            }
            sr.Close();
        } 
    }


}