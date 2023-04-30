using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour{
    
    private Rigidbody2D player;

    private void Start() {
        
    }
    public void LoadGame() {
        LoadPlayerPosition();
        LoadIngreadients();
        LoadStatictic();
    }

    private void LoadIngreadients() {
        for (int i = 0; i < IngredientsController.Instance.ingredientsList.Count; i++) {
            IngredientsController.Instance.ingredientsList[i].ingredientQuantity =  PlayerPrefs.GetInt("Ingrediedent" + i);
        }
        //IngredientsController.Instance.ingredientsList[0].ingredientQuantity = PlayerPrefs.GetInt("trees");
    }

    public void LoadStatictic() {
        PlayerStatisticController.Instance.strength.value = PlayerPrefs.GetInt("strengthSave");
        PlayerStatisticController.Instance.defense.value = PlayerPrefs.GetInt("defenseSave");
        PlayerStatisticController.Instance.dexterity.value = PlayerPrefs.GetInt("dexteritySave");
        PlayerStatisticController.Instance.endurance.value = PlayerPrefs.GetInt("enduranceSave");
        PlayerStatisticController.Instance.intelligence.value = PlayerPrefs.GetInt("intelligenceSave");
        PlayerStatisticController.Instance.luck.value = PlayerPrefs.GetInt("luckSave");
        PlayerStatisticController.Instance.gold.value = PlayerPrefs.GetInt("goldSave");

        PlayerStatisticController.Instance.life.value = PlayerPrefs.GetInt("lifeSave");
        PlayerStatisticController.Instance.life.valueMax = PlayerPrefs.GetInt("lifeMaxSave");
        PlayerStatisticController.Instance.mana.value = PlayerPrefs.GetInt("manaSave");
        PlayerStatisticController.Instance.mana.valueMax = PlayerPrefs.GetInt("manaMaxSave");
        PlayerStatisticController.Instance.exp.value = PlayerPrefs.GetInt("expSave");
        PlayerStatisticController.Instance.exp.valueMax = PlayerPrefs.GetInt("expMaxSave");
    }

    public void LoadPlayerPosition() {
        player = FindObjectOfType<PlayerController>().getPlayerRB();
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("position x"), PlayerPrefs.GetFloat("position y"));
    }
}