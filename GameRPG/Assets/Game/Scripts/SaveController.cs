using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour{

    private Rigidbody2D player;

    private void Start() {
        //player = player.GetComponent<ScriptableObject>(PlayerController.FindObjectOfType); 
    }

    public void SaveGame() {
        SavePlayerPosition();
        SaveIngredients();
        SaveStatistic();
    }

    private void SaveIngredients() {
        for (int i=0; i<IngredientsController.Instance.ingredientsList.Count; i++) {
            PlayerPrefs.SetInt("Ingrediedent" + i, IngredientsController.Instance.ingredientsList[i].ingredientQuantity) ;
        }

        //PlayerPrefs.SetInt("trees", IngredientsController.Instance.ingredientsList[0].ingredientQuantity);
    }

    public void SaveStatistic() {
        PlayerPrefs.SetInt("strengthSave", PlayerStatisticController.Instance.strength.value);
        PlayerPrefs.SetInt("defenseSave", PlayerStatisticController.Instance.defense.value);
        PlayerPrefs.SetInt("dexteritySave", PlayerStatisticController.Instance.dexterity.value);
        PlayerPrefs.SetInt("enduranceSave", PlayerStatisticController.Instance.endurance.value);
        PlayerPrefs.SetInt("intelligenceSave", PlayerStatisticController.Instance.intelligence.value);
        PlayerPrefs.SetInt("luckSave", PlayerStatisticController.Instance.luck.value);
        PlayerPrefs.SetInt("goldSave", PlayerStatisticController.Instance.gold.value);

        PlayerPrefs.SetInt("lifeSave", PlayerStatisticController.Instance.life.value);
        PlayerPrefs.SetInt("lifeMaxSave", PlayerStatisticController.Instance.life.valueMax);
        PlayerPrefs.SetInt("manaSave", PlayerStatisticController.Instance.mana.value);
        PlayerPrefs.SetInt("manaMaxSave", PlayerStatisticController.Instance.mana.valueMax);
        PlayerPrefs.SetInt("expSave", PlayerStatisticController.Instance.exp.value);
        PlayerPrefs.SetInt("expMaxSave", PlayerStatisticController.Instance.exp.valueMax);
        PlayerPrefs.SetInt("playerLvSave", PlayerStatisticController.Instance.playerLevel);
        PlayerPrefs.SetInt("playerApSave", PlayerStatisticController.Instance.playerAp);
        PlayerPrefs.SetInt("playerSpSave", PlayerStatisticController.Instance.playerSp);
        
    }

    public void SavePlayerPosition() {
        player = FindObjectOfType<PlayerController>().getPlayerRB();
        Debug.Log("x = " + player.transform.position.x);
        PlayerPrefs.SetFloat("position x", player.transform.position.x);
        PlayerPrefs.SetFloat("position y", player.transform.position.y);
    }
}