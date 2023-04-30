namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;
    public class SkillsPanel : Panel {
        [SerializeField]
        private GameObject m_category1Panel;
        [SerializeField]
        private GameObject m_category2Panel;
        [SerializeField]
        private GameObject m_category3Panel;
        [SerializeField]
        private Text m_quantityTxt;

        private void Update() {
            m_quantityTxt.text = "Punkty: " + PlayerStatisticController.Instance.playerSp.ToString();
        }

        public void ShowCategorySkills(int a) {
            switch (a) {
                case 1:
                    m_category1Panel.SetActive(true);
                    m_category2Panel.SetActive(false);
                    m_category3Panel.SetActive(false);
                    break;
                case 2:
                    m_category1Panel.SetActive(false);
                    m_category2Panel.SetActive(true);
                    m_category3Panel.SetActive(false);
                    break;
                case 3:
                    m_category1Panel.SetActive(false);
                    m_category2Panel.SetActive(false);
                    m_category3Panel.SetActive(true);
                    break;
            }
        }
        
    }
}

