namespace Game.UI {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ShopPanel : Panel {

        private InventoryPanel inventoryPanel;

        [SerializeField]
        private GameObject slots;
        private Image[] inventorySlots;

        private void Start() {
            //inventoryPanel.LoadItems();
            inventorySlots = new Image[slots.transform.childCount];

            for (var i = 0; i < slots.transform.childCount; i++) {
                inventorySlots[i] = slots.transform.GetChild(i).GetChild(0).GetComponent<Image>();

                if (i < InventoryController.Instance.itemsListOk.Count) {

                    var item = InventoryController.Instance.itemsListOk[i];

                    inventorySlots[i].sprite = Resources.Load<Sprite>("ItemImage/" + item.imageName);
                }
            }
        }
    }
}