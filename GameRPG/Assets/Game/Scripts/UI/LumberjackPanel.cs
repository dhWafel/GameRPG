namespace Game.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class LumberjackPanel : Panel {

        private int m_counter;
        private bool is_work;
        private bool is_click;
        [SerializeField]
        private Button workerButton;

        private void Start() {
            m_counter = 0;
            is_work = false;
            is_click = false;
        }

        private void Update() {
            if (is_work == true) {
                StartCoroutine(Worker());
                workerButton.image.color = Color.red;
                is_click = true;
                Debug.Log("trees start" + IngredientsController.Instance.ingredientsList[0].ingredientQuantity);
            }
            if (is_work == false) {
                StopAllCoroutines();
                workerButton.image.color = Color.clear;
                is_click = false;
                Debug.Log("trees stop" + IngredientsController.Instance.ingredientsList[0].ingredientQuantity);
            }

        }

        public void Cut() {
            Debug.Log("drzewo " + m_counter);
            if (m_counter >= 20) {
                IngredientsController.Instance.ingredientsList[0].ingredientQuantity++;
                m_counter -= 20;
            }
            m_counter += 9;
        }

        public void Job() {
            if (is_click == false) {
                is_work = true;
            }
            if (is_click == true) {
                is_work = false;
            }

        }

        public IEnumerator Worker() {
            yield return new WaitForSeconds(5f);
            IngredientsController.Instance.ingredientsList[0].ingredientQuantity+=1;
        }
    }
}