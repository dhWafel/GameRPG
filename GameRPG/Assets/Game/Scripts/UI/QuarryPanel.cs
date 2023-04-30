namespace Game.UI {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class QuarryPanel : Panel {
        private int m_counter;

        private void Start() {
            m_counter = 0;
        }
        public void Digging() {
            Debug.Log("kamień " + m_counter);
            if (m_counter >= 20) {
                IngredientsController.Instance.ingredientsList[2].ingredientQuantity++;
                m_counter -= 20;
            }
            m_counter++;
        }
    }
}

