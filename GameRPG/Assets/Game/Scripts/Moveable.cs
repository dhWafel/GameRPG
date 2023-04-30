using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveable :  MonoSingleton<Moveable> {
    private InventoryPanel inventoryPanel;
    public Image image;
    [SerializeField]
    private GameObject m_itemInfo;

    private float m_orginal_x, m_orginal_y;

    public int l;

    public void Start() {
        m_orginal_x = this.gameObject.transform.position.x;
        m_orginal_y = this.gameObject.transform.position.y;
      //  if (image.sprite == null) {
        //    free_slot = true;
        //} else {
        //  free_slot = false;
    //    }
    }

    public void MouseDrag() {

        image.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log("Drag");
    }

    public void MouseDown() {
        gameObject.transform.position = new Vector3(m_orginal_x, m_orginal_y, 1);
    }

    public void MouseUp() {
                gameObject.transform.position = new Vector2(m_orginal_x, m_orginal_y);

    }
    
    public void MouseEnter() {
        m_itemInfo.SetActive(true);
       
        Debug.Log("hover");
    }

    public void MouseExit() {
        m_itemInfo.SetActive(false);
    }

    public void MouseClick(int m) {
        l = m;
        m_itemInfo.SetActive(true);
        m_itemInfo.transform.position = new Vector3(Input.mousePosition.x + 200, Input.mousePosition.y - 300f);      
    }

    public bool free_slot = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("KOLIZJA");
        if(collision.gameObject.tag.Equals("Eq_slot") && collision.gameObject.transform.GetChild(0).GetComponent<Moveable>().free_slot) {
            Debug.Log("KOLIZJA_WYKONANO_PRZENIESIENIE");
            collision.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite;
            collision.gameObject.transform.GetChild(0).GetComponent<Moveable>().free_slot = false;

            gameObject.transform.position = new Vector2(m_orginal_x, m_orginal_y);
            
            image.sprite = null;
            free_slot = true;

        }
        
    }
}