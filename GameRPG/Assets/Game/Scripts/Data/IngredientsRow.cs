namespace Game.Data {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


    public class IngredientsRow : MonoBehaviour {
        [SerializeField]
        private Image m_img;
        public Text nameTxt;
        [SerializeField]
        private Text quantityTxt;
        public static int index = 0;
        private int local_index;


        private void Start() {
            local_index = index;
            nameTxt.text = IngredientsController.Instance.ingredientsList[index].ingredientName;
            quantityTxt.text = IngredientsController.Instance.ingredientsList[index].ingredientQuantity.ToString();          
            m_img.sprite = Resources.Load<Sprite>("IngredientsImage/" + IngredientsController.Instance.ingredientsList[index].ingredientImageName);                           
            index++;
            
        }

        public void Update() {
            //Debug.Log("Aktualizacja");

            quantityTxt.text = IngredientsController.Instance.ingredientsList[local_index].ingredientQuantity.ToString();
        }
    }
}