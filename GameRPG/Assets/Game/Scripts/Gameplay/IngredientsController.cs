using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class IngredientsController : MonoSingleton<IngredientsController>{
    [HideInInspector]
    public Game.Data.Ingredients ingredients;

    public List<Game.Data.Ingredients> ingredientsList;

    private void Start() {
        LoadIndredients();
    }

    public void LoadIndredients() {
        string path = Application.dataPath + Game.Const.c_ingredientsPath;
        //ingredientsList = new List<Game.Data.Ingredients>();

        StreamReader sr = new StreamReader(path);
        if (sr != null) {
            int lineNumber = 0;
            while (!sr.EndOfStream) {
                var line = sr.ReadLine();
                if (lineNumber > 0) {
                    var values = line.Split(';');
                    Game.Data.Ingredients ingredient = new Game.Data.Ingredients();
                    ingredient.ingredientName = values[0];
                    ingredient.ingredientImageName = values[1];
                    ingredient.ingredientQuantity = int.Parse(values[2]);
                    ingredientsList.Add(ingredient);
                }
                lineNumber++;
            }
            sr.Close();
        }
        Debug.Log("wczytaj : "+ ingredientsList.Count);
    }
}