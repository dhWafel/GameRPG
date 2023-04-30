namespace Game.UI {
    using FernusGames.RPGSystem;
    using UnityEngine;
    using UnityEngine.UI;

    public class TopBar : MonoBehaviour {
        [SerializeField]
        private Image m_bar;
        [SerializeField]
        private Text m_text;


        public void UpdateAttribute(AttributeMinMax attribute) {
            m_bar.fillAmount = attribute.normalizedValue;
            m_text.text = attribute.value.ToString() + " / " + attribute.valueMax.ToString();
        }
    }
}

