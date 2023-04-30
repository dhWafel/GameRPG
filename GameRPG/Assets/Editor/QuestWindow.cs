using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class QuestWindow : EditorWindow{

    private List<Game.Data.Quest> m_questList;
    Vector2 scrollPosition;

    [MenuItem("Window/Quest Window")]

    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(QuestWindow));
    }

    void OnGUI() {
        if (m_questList == null) {
            m_questList = new List<Game.Data.Quest>();
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.ExpandHeight(true));
        
        for (int i = 0; i < m_questList.Count; i++) {
            GUILayout.Label("Zadanie nr. " + i, EditorStyles.boldLabel);
            GUILayout.Space(10);
            m_questList[i].questName = EditorGUILayout.TextField("Nazwa zadania: ", m_questList[i].questName);
            m_questList[i].questDiscription = EditorGUILayout.TextField("Opis zadania: ", m_questList[i].questDiscription);
            m_questList[i].questExp = (int)EditorGUILayout.Slider("Nagroda exp: ", m_questList[i].questExp, 100, 10000);
            GUILayout.Space(25);
        }

        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Dodaj")) {
            NewQuest();
        }
        if (GUILayout.Button("Zapisz")) {
            SaveQuest();
        }
        if (GUILayout.Button("Wczytaj")) {
            LoadQuest();         
        }
    }

    public void NewQuest() {
        m_questList.Add(new Game.Data.Quest());
    }

    public void SaveQuest() {
        string path = Application.dataPath + Game.Const.c_questsPath;

        StreamWriter sw = new StreamWriter(path, false);
        if(sw != null) {
            sw.WriteLine(@"questName; questDiscription;");
            foreach(Game.Data.Quest quest in m_questList) {
                sw.WriteLine(string.Format(@"{0};{1};{2}", quest.questName, quest.questDiscription, quest.questExp));
            }
            sw.Close();
        }
        Debug.Log("zapisane");
    }

    public void LoadQuest() {
        string path = Application.dataPath + Game.Const.c_questsPath;

        StreamReader sr = new StreamReader(path);
        if(sr != null) {
            int lineNumber = 0;
            while (!sr.EndOfStream) {
                var line = sr.ReadLine();
                if (lineNumber > 0) {
                    var values = line.Split(';');
                    Game.Data.Quest quest = new Game.Data.Quest();
                    quest.questName = values[0];
                    quest.questDiscription = values[1];
                    quest.questExp = int.Parse(values[2]);
                    m_questList.Add(quest);
                }
                lineNumber++;
            }
            sr.Close();
        }
    }
}