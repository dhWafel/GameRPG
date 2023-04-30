namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;

    public class ArmorerPanel : Panel {
        [SerializeField]
        private GameObject m_forge;
        [SerializeField]
        private GameObject m_buy;

        public void ShowForgePanel() {
            OffArmorerPanel();
            m_forge.SetActive(true);
        }

        public void AcceptedForge() {
            //ControlPanel.Instance.ShowPanel("Ingredients");
            ControlPanel.Instance.ShowPanel("CreateArmor");
        }

        public void ShowBuyPanel() {
            OffArmorerPanel();
            m_buy.SetActive(true);
        }

        public void AcceptedShoping() {
            ControlPanel.Instance.ShowPanel("Shop");
        }

        public void OffArmorerPanel() {
            m_forge.SetActive(false);
            m_buy.SetActive(false);
        }

    }
}