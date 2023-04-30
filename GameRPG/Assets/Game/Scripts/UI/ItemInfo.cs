using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemInfo : MonoBehaviour {
    [SerializeField]
    private Text discriptionInfoPanelTxt;

    public int b;
    private void OnEnable() {
        b = Moveable.Instance.l;
        discr(b);
        /*Lola();
        for (int i = 0; i < InventoryController.Instance.itemsList.Count; i++) {
            if (i == a) {
                discriptionInfoPanelTxt.text = InventoryController.Instance.itemsListOk[i].itemDescription;
            }
            if (i == a) {
                discriptionInfoPanelTxt.text = InventoryController.Instance.itemsListOk[i].itemDescription;
            }
        }*/
    }

    public void Lola() {
        List<int> kolo = new List<int>();
        //var kolo = new List<int>();
        for(int i = 0; i < InventoryController.Instance.itemsList.Count; i++) {
            kolo.Add(i);
        }     
    }

    private void discr(int a) {
        for (int i = 0; i < InventoryController.Instance.itemsList.Count; i++) {
            if (i == a) {
                discriptionInfoPanelTxt.text = InventoryController.Instance.itemsListOk[i].itemDescription;
            }
        }
    }
}