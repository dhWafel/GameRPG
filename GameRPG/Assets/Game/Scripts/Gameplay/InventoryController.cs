using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventoryController : MonoSingleton<InventoryController>{
    
    [HideInInspector]
    public Game.Data.Item item;

    public List<Game.Data.Item> itemsList;
    public List<Game.Data.Item> itemsListOk;

    private void Start() { 
        LoadItem();
    }

    public void LoadItem() {
        string path = Application.dataPath + Game.Const.c_itemsPath;

        Game.Data.Items data = new Game.Data.Items();
        string content = File.ReadAllText(path);
        data = JsonUtility.FromJson<Game.Data.Items>(content);
        itemsList = new List<Game.Data.Item>(data.myData);
        itemsListOk = new List<Game.Data.Item>();
        for (int i=0; i < itemsList.Count; i++) {
            itemsListOk.Add(itemsList[i]);
        }
    }

    public void PutOnItem() {

        Debug.Log("założone");
    }

    public void ThrowOutItem() {
        Debug.Log("wyrzucone");
        //LoadItem();
        
    }
}