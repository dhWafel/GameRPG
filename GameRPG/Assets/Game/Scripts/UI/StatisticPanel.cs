namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;

    public class StatisticPanel : MonoBehaviour {
        [SerializeField]
        private Text m_playerNameText;
        [SerializeField]
        private Text m_playerRaceText;
        [SerializeField]
        private Text m_playerClassText;
        [SerializeField]
        private Text m_goldText;
        [SerializeField]
        private Text m_levelText;
        [SerializeField]
        private Text m_apText;
        [SerializeField]
        private Text m_spText;
        [SerializeField]
        private Text m_lifeText;
        [SerializeField]
        private Text m_manaText;
        [SerializeField]
        private Text m_expText;
        [SerializeField]
        private Text m_strengthText;
        [SerializeField]
        private Text m_defenseText;
        [SerializeField]
        private Text m_dexterityText;
        [SerializeField]
        private Text m_enduranceText;
        [SerializeField]
        private Text m_intelligenceText;
        [SerializeField]
        private Text m_luckText;

        public void UpdateStatistic(PlayerStatisticController statistic) {

            if (PlayerStatisticController.Instance.isReady) {
                m_playerNameText.text = "Fernus";
                m_playerRaceText.text = "Człowiek";
                m_playerClassText.text = "Rycerz";
                m_goldText.text = statistic.gold.value.ToString();
                m_expText.text = statistic.exp.value.ToString();
                m_levelText.text = statistic.playerLevel.ToString();
                m_apText.text = statistic.playerAp.ToString();
                m_spText.text = statistic.playerSp.ToString();

                m_lifeText.text = statistic.life.value.ToString() + " / " + statistic.life.valueMax.ToString();
                m_manaText.text = statistic.mana.value.ToString() + " / " + statistic.mana.valueMax.ToString();

                m_strengthText.text = statistic.strength.value.ToString();
                m_defenseText.text = statistic.defense.value.ToString();
                m_dexterityText.text = statistic.dexterity.value.ToString();
                m_enduranceText.text = statistic.endurance.value.ToString();
                m_intelligenceText.text = statistic.intelligence.value.ToString();
                m_luckText.text = statistic.luck.value.ToString();
            }
        }
    }
}