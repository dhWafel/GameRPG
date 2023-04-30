using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour{

    private InventoryController inventoryController;

    [SerializeField]
    private GameObject midUp;
    [SerializeField]
    private GameObject midMidLeft1;
    [SerializeField]
    private GameObject midMidLeft2;
    [SerializeField]
    private GameObject midMidRight1;
    [SerializeField]
    private GameObject midMidRight2;
    [SerializeField]
    private GameObject midDown;
    //[SerializeField]
    //private GameObject InfoPanel;
    [SerializeField]
    private Text discriptionInfoPanelTxt;
    

    [SerializeField]
    private GameObject Slots;
    private Image[] inventorySlots;

    [SerializeField]
    private Text textButton;

    private bool isArmor;

    private void OnMouseDrag() {
        
    }

    private void OnMouseDown() {
        
    }

    private void OnMouseUp() {
        
    }

    private void Start() {
        LoadItems();
    }
     public void LoadItems() {
        inventorySlots = new Image[Slots.transform.childCount];

        for (var i = 0; i < Slots.transform.childCount; i++) {
            inventorySlots[i] = Slots.transform.GetChild(i).GetChild(0).GetComponent<Image>();

            if (i < InventoryController.Instance.itemsListOk.Count) {

                var item = InventoryController.Instance.itemsListOk[i];

                inventorySlots[i].sprite = Resources.Load<Sprite>("ItemImage/" + item.imageName);
            }
        }
     }


    public void ChangeView() {
        if (isArmor) {
            ShowArmor();
        }
        else if (!isArmor) {

            ShowWeapon();
        }
    }

    public void ShowArmor() {
        midUp.SetActive(true);
        midMidLeft1.SetActive(true);
        midMidLeft2.SetActive(false);
        midMidRight1.SetActive(true);
        midMidRight2.SetActive(false);
        midDown.SetActive(true);
        textButton.text = "W";
        isArmor = false;
    }

    public void ShowWeapon() {
        midUp.SetActive(false);
        midMidLeft1.SetActive(false);
        midMidLeft2.SetActive(true);
        midMidRight1.SetActive(false);
        midMidRight2.SetActive(true);
        midDown.SetActive(false);
        textButton.text = "A";
        isArmor = true;
    }

    public void ShowInfoPanel() {
        discriptionInfoPanelTxt.text = "opis" + InventoryController.Instance.itemsListOk[5].itemDescription;
        InventoryController.Instance.PutOnItem();
    }
}