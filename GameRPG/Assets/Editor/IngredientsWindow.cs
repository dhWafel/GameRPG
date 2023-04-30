using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class IngredientsWindow : EditorWindow{
    private List<Game.Data.Ingredients> m_ingredientsList;
    Vector2 scrollPosition;

    [MenuItem("Window/Ingredients Window")]

    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(IngredientsWindow));
    }

    void OnGUI() {
        if(m_ingredientsList == null) {
            m_ingredientsList = new List<Game.Data.Ingredients>();
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.ExpandHeight(true));

        for(int i=0; i < m_ingredientsList.Count; i++) {
            GUILayout.Label("Surowiec nr. " + i, EditorStyles.boldLabel);
            GUILayout.Space(10);
            m_ingredientsList[i].ingredientName = EditorGUILayout.TextField("Nazwa surowca: ", m_ingredientsList[i].ingredientName);
            m_ingredientsList[i].ingredientImageName = EditorGUILayout.TextField("Obrazek surowca: ", m_ingredientsList[i].ingredientImageName);
            m_ingredientsList[i].ingredientQuantity = (int)EditorGUILayout.Slider("Ilość surowca: ", m_ingredientsList[i].ingredientQuantity, 0, 1000000);
            GUILayout.Space(25);
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Dodaj")) {
            NewIngredient();
        }
        if (GUILayout.Button("Zapisz")) {
            SaveIngredients();
        }
        if (GUILayout.Button("Wczytaj")) {
            LoadIndredients();
        }
    }

    private void NewIngredient() {
        m_ingredientsList.Add(new Game.Data.Ingredients());
    }

    private void SaveIngredients() {
        string path = Application.dataPath + Game.Const.c_ingredientsPath;

        StreamWriter sw = new StreamWriter(path, false);
        if (sw!=null) {
            sw.WriteLine(@"Nazwa surowca; Obrazek surowca; Ilość surowca; ");
            foreach(Game.Data.Ingredients ingredient in m_ingredientsList) {
                sw.WriteLine(string.Format(@"{0};{1};{2}", ingredient.ingredientName, ingredient.ingredientImageName, ingredient.ingredientQuantity));
            }
            sw.Close();
        }

        Debug.Log("zapis");
    }

    private void LoadIndredients() {
        string path = Application.dataPath + Game.Const.c_ingredientsPath;

        StreamReader sr = new StreamReader(path);
        if(sr != null) {
            int lineNumber = 0;
            while (!sr.EndOfStream) {
                var line = sr.ReadLine();
                if(lineNumber > 0) {
                    var values = line.Split(';');
                    Game.Data.Ingredients ingredient = new Game.Data.Ingredients();
                    ingredient.ingredientName = values[0];
                    ingredient.ingredientImageName = values[1];
                    ingredient.ingredientQuantity = int.Parse(values[2]);
                    m_ingredientsList.Add(ingredient);
                }
                lineNumber++;
            }
            sr.Close();
        }
        Debug.Log("wczytaj");
    }
}