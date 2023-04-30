namespace Game.UI {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SawmillPanel : Panel {     
        private int m_counter;
        private int m_trees;

        private void Start() {
            m_counter = 0;
            m_trees = IngredientsController.Instance.ingredientsList[0].ingredientQuantity;
        }

        public void CuttingTree() {
            Debug.Log("licznik " + m_counter);
            Debug.Log("drewno " + IngredientsController.Instance.ingredientsList[1].ingredientQuantity);
            Debug.Log("drzewo " + m_trees);
            //m_trees = IngredientsController.Instance.ingredientsList[0].ingredientQuantity;
            if (m_trees >= 20) {
                m_trees -= 20;
                IngredientsController.Instance.ingredientsList[0].ingredientQuantity -= 20;
                IngredientsController.Instance.ingredientsList[1].ingredientQuantity++;
                
            }
            m_counter++;
        }
    }
}