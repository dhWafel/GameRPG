using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ItemWindow : EditorWindow{

    public static string[] attributeArray = new string[] { "Brak", "Życie", "Mana", "Max Życia", "Max Mana", "Siła", "Obrona", "Zręczność", "Wytrzymałość", "Inteligencja", "Szczęście" };

    public string[] itemType;
    public string[] armorType;
    public string[] weaponType;
    public string[] accessoriesType;
    public string[] potionsType;

    private List<Game.Data.Item> m_itemsList;
    Vector2 scrollPosition;

    [MenuItem("Window/Item Window")]

    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(ItemWindow));
    }

    void OnGUI() {
        if (m_itemsList == null) {
            m_itemsList = new List<Game.Data.Item>();
        }

        itemType = new string[] { "Broń", "Zbroja", "Dodatki", "Mikstury" };
        armorType = new string[] { "Hełm", "Rękawice", "Naramienniki", "Napierśnik", "Spodnie", "Buty" };
        weaponType = new string[] { "Biała jednoręczna", "Biała dwuręczna", "Obuchowa", "Drzewcowa",  "Dystansowa" };
        accessoriesType = new string[] {"Pierścień", "Amulet", "Pas", "Płaszcz" };
        potionsType = new string[] {"Mikstura życia", "Mikstura mana" };

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.ExpandHeight(true));

        for(int i=0; i<m_itemsList.Count; i++) {
            GUILayout.Label("Przedmiot " + i, EditorStyles.boldLabel);
            GUILayout.Space(5);

            m_itemsList[i].name = EditorGUILayout.TextField("Nazwa: ", m_itemsList[i].name);
            m_itemsList[i].imageName = EditorGUILayout.TextField("Obrazek: ", m_itemsList[i].imageName);
            m_itemsList[i].indexItemType = EditorGUILayout.Popup("Item type", m_itemsList[i].indexItemType, itemType);
            
           

            var type = itemType[m_itemsList[i].indexItemType];
 
            m_itemsList[i].type = type;
            string[] subType= new string[] { };

            if (type.Equals("Zbroja")) {
                subType = armorType;
            }
            if (type.Equals("Broń")) {
                subType = weaponType;  
            }
            if (type.Equals("Dodatki")) {
                subType = accessoriesType;   
            }
            if (type.Equals("Mikstury")) {
                subType = potionsType;
            }
            m_itemsList[i].indexItemSubType = EditorGUILayout.Popup("Sub Type", m_itemsList[i].indexItemSubType, subType);

            m_itemsList[i].quality = (int)EditorGUILayout.Slider("Jakość: ", m_itemsList[i].quality, 0, 4);

            m_itemsList[i].itemDescription = EditorGUILayout.TextField("Opis: ", m_itemsList[i].itemDescription);
            DrawItem(i);

            m_itemsList[i].price = (int)EditorGUILayout.Slider("Cena: ", m_itemsList[i].price, 0, 10000);

            GUILayout.Space(30);
        }     

        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Dodaj")) {
            AddItem();
        }

        if (GUILayout.Button("Zapisz")) {
            SaveItem();
        }

        if (GUILayout.Button("Wczytaj")) {
            LoadItem();
        }
    }

    public void AddItem() {
        var item = new Game.Data.Item();
        item.attributes = new Game.Data.ItemAttribute[3];
        for(int i=0; i<3; i++) {
            item.attributes[i] = new Game.Data.ItemAttribute();
        }
        m_itemsList.Add(item);

    }

    public void SaveItem() {
        string c_path = Application.dataPath + Game.Const.c_itemsPath;
       
        Game.Data.Items data = new Game.Data.Items();
        data.myData = m_itemsList.ToArray();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(c_path, json);
    }

    public void LoadItem() {
        string c_path = Application.dataPath + Game.Const.c_itemsPath;

        Game.Data.Items data = new Game.Data.Items();
        string content = File.ReadAllText(c_path);
        data = JsonUtility.FromJson<Game.Data.Items>(content);
        m_itemsList = new List<Game.Data.Item>(data.myData);
    }

    public void DrawItem(int i) {
        var item = m_itemsList[i];
       for (int j=0; j<m_itemsList[i].attributes.Length; j++) {
            int n = j + 1;
            var attribute = item.attributes[j];
            GUILayout.BeginHorizontal();
            attribute.indexItemAttribute = EditorGUILayout.Popup("Atrybut " + n + ":", attribute.indexItemAttribute, attributeArray);
            attribute.value = (int)EditorGUILayout.Slider("wartość: ", attribute.value, 0, 200);
            GUILayout.EndHorizontal();
        }
    } 
}
