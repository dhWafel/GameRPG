using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RecipesWindow : EditorWindow {
    private List<Game.Data.Recipe> m_recipeList;
    Vector2 scrollPosition;

    [MenuItem("Window/Recipe Window")]

    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(RecipesWindow));
    }

    private void OnGUI() {
        if(m_recipeList == null) {
            m_recipeList = new List<Game.Data.Recipe>();
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.ExpandHeight(true));

        for (int i=0; i<m_recipeList.Count; i++) {
            GUILayout.Label("Receptura nr. " + i, EditorStyles.boldLabel);
            GUILayout.Space(10);
            m_recipeList[i].name = EditorGUILayout.TextField("Nazwa receptury: ", m_recipeList[i].name);
            m_recipeList[i].imageName = EditorGUILayout.TextField("Nazwa receptury: ", m_recipeList[i].imageName);
            m_recipeList[i].price = (int)EditorGUILayout.Slider("Cena: ",m_recipeList[i].price, 0, 10000);

            GUILayout.Space(25);
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Dodaj")) {
            NewRecipe();
        }
        if (GUILayout.Button("Zapisz")) {
            SaveRecipes();
        }
        if (GUILayout.Button("Wczytaj")) {
            LoadRecipes();
        }
    }
    public void NewRecipe() {
        m_recipeList.Add(new Game.Data.Recipe());
    }

    public void SaveRecipes() {
        string path = Application.dataPath + Game.Const.c_recipesPath;

        StreamWriter sw = new StreamWriter(path, false);
        if (sw != null) {
            sw.WriteLine(@"recipesName; recipesImageName; recipesPrice;");
            foreach(Game.Data.Recipe recipe in m_recipeList){
                sw.WriteLine(string.Format(@"{0};{1};{2}", recipe.name, recipe.imageName, recipe.price));
            }
            sw.Close();
        }
        Debug.Log("zapis");
    }

    public void LoadRecipes() {
        string path = Application.dataPath + Game.Const.c_recipesPath;
        StreamReader sr = new StreamReader(path);
        if (sr != null) {
            int lineNumber = 0;
            while (!sr.EndOfStream) {
                var line = sr.ReadLine();
                if (lineNumber > 0) {
                    var values = line.Split(';');
                    Game.Data.Recipe recipe = new Game.Data.Recipe();
                    recipe.name = values[0];
                    recipe.imageName = values[1];
                    recipe.price = int.Parse(values[2]);
                    m_recipeList.Add(recipe);
                }
                lineNumber++;
            }
            sr.Close();
        }
        Debug.Log("wczyt");
    }
}