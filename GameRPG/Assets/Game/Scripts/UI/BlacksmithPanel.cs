namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;

    public class BlacksmithPanel : Panel {
        [SerializeField]
        private GameObject m_forge;
        [SerializeField]
        private GameObject m_buy;

        public void ShowForgePanel() {
            OffBlacksmithPanel();
            m_forge.SetActive(true);         
        }

        public void Forge() {

        }

        public void AcceptedForge() {
            //ControlPanel.Instance.ShowPanel("Ingredients");
            ControlPanel.Instance.ShowPanel("CreateWeapon");
        }

        public void ShowBuyPanel() {
            OffBlacksmithPanel();
            m_buy.SetActive(true);
        }

        public void AcceptedShoping() {
            ControlPanel.Instance.ShowPanel("Shop");
        }

        public void OffBlacksmithPanel() {
            m_forge.SetActive(false);
            m_buy.SetActive(false);
        }

    }
}