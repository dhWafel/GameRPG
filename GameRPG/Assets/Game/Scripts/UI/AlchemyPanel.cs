namespace Game.UI {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AlchemyPanel : Panel {
        [SerializeField]
        private GameObject m_forge;
        [SerializeField]
        private GameObject m_buy;


        public void ShowForgePanel() {
            OffAlchemyPanel();
            m_forge.SetActive(true);
        }

        public void AcceptedForge() {
            ControlPanel.Instance.ShowPanel("CreatePotion");
        }

        public void ShowBuyingPanel() {
            OffAlchemyPanel();
            m_buy.SetActive(true);
        }

        public void AcceptedShoping() {
            ControlPanel.Instance.ShowPanel("Shop");
        }

        private void OffAlchemyPanel() {
            m_forge.SetActive(false);
            m_buy.SetActive(false);
        }
    }
}

