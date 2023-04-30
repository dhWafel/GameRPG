using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class EnemyWindow : EditorWindow{

    private List<Game.Data.Enemy> m_enemyList;
    Vector2 scrollPosition; 

    [MenuItem("Window/Enemy Window")]

    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(EnemyWindow));
    }

    void OnGUI() {
        if (m_enemyList == null) {
            m_enemyList = new List<Game.Data.Enemy>();
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.ExpandHeight(true));

        for(int i=0; i<m_enemyList.Count; i++) {
            GUILayout.Label("wróg " + i, EditorStyles.boldLabel);
            GUILayout.Space(10);
            m_enemyList[i].imageName = EditorGUILayout.TextField(m_enemyList[i].imageName);
            m_enemyList[i].lvl = (int)EditorGUILayout.Slider("lvl", m_enemyList[i].lvl, 0, 10);
            m_enemyList[i].lifeMax = (int)EditorGUILayout.Slider("lifeMax", m_enemyList[i].lifeMax, 0, 10000);
            m_enemyList[i].atak = (int)EditorGUILayout.Slider("atak", m_enemyList[i].atak, 0, 1000);
            m_enemyList[i].armor = (int)EditorGUILayout.Slider("armor", m_enemyList[i].armor, 0, 1000);
            GUILayout.Space(25);
        }

        EditorGUILayout.EndScrollView();

        if(GUILayout.Button("Dodaj wroga")) {
            AddEnemy();
        }

        if (GUILayout.Button("Zapisz")) {
            SaveEnemy(m_enemyList);
        }

        if (GUILayout.Button("Wczytaj")) {
            LoadEnemy();
        }
    }

    private void AddEnemy() {
        m_enemyList.Add(new Game.Data.Enemy());
    }

    private void SaveEnemy(List<Game.Data.Enemy> enemies) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + Game.Const.c_enemiesPath;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, m_enemyList);
        stream.Close();
    }

    private void LoadEnemy() {
        string path = Application.dataPath + Game.Const.c_enemiesPath;
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            m_enemyList = (List<Game.Data.Enemy>)formatter.Deserialize(stream);
            stream.Close();
        } else {
            Debug.LogError("Save file not found");
        }
    }
}


