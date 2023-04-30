namespace Game.UI {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class IngredientsPanel : Panel {
        //private IngredientsController m_ingredientsController;
        private Game.Data.IngredientsRow ingredientsRow;
        public Scrollbar sb;
        [SerializeField]
        private GameObject m_ingredientsRow;
        [SerializeField]
        private GameObject m_rowParent;
        //private List<Text> m_IngredientsNameTxtList;
        private Image[] m_IngredientsImageList;

        //[SerializeField]
        private List<GameObject> m_IngredientsRowsList;   
       

        private void Start() {
            m_IngredientsRowsList = new List<GameObject>();
            ShowRow();
        }

        private void Clear() {
            for (int i=0; i<m_IngredientsRowsList.Count; i++) {
                Destroy(m_IngredientsRowsList[i].gameObject);
            }
            m_IngredientsRowsList = new List<GameObject>();
        }

        public void ShowRow() {
            Clear();         
            for (int i = 0; i < IngredientsController.Instance.ingredientsList.Count; i++) {
                var newRow = Instantiate(m_ingredientsRow, m_rowParent.transform);
                m_IngredientsRowsList.Add(newRow);
                //Debug.Log("surowiec" + i);
                Debug.Log(IngredientsController.Instance.ingredientsList[i].ingredientName + " " + IngredientsController.Instance.ingredientsList[i].ingredientQuantity);
            }
        }


    }
}