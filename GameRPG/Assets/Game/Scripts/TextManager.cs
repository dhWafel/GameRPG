using UnityEngine;
using UnityEngine.UI;
using FernusGames.RPGSystem;

public class TextManager : MonoBehaviour{


    public GameObject choice;
    
    public Text executionTxt;

    private string execution;
    


    public void WritteText(string a) {
        //OffPanelText();
        executionTxt.gameObject.SetActive(true);
        if (a == "Gossip") {
            //WritteGossipTxt();
            //execution = gossip;
        }
        if (a == "Room") {
            int g = 0;
            //WritteRoom (g);
        }
        if (a == "Quest") {
            //WritteQuest();
        }
        if (a == "Forge") {
            execution = "Wykuj broń";
            choice.SetActive(true);
        }
        if (a == "Buy") {
            execution = "Chcesz coś kupić?";
            choice.SetActive(true);
        }
        if (a == "Training") {
            execution = "Trenujemy?!";
        }
        if (a == "Travel") {
            execution = "Dokąd jedziemy?";
        }
        executionTxt.text = execution;
    }
}