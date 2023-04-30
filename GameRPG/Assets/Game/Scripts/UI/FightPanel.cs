namespace Game.UI {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class FightPanel : Panel {

        private FightController fightController;

        [SerializeField]
        private GameObject m_spellPanel;
        [SerializeField]
        private GameObject m_normalAttackPanel;
        [SerializeField]
        private GameObject m_potionsPanel;
        [SerializeField]
        private GameObject[] m_spellButtons;
        [SerializeField]
        private GameObject[] m_normalAttackButtons;
        [SerializeField]
        private GameObject m_hitPanel;
        [SerializeField]
        private Text m_damageTxt;



        public void ShowSpells() {
            m_spellPanel.SetActive(!m_spellPanel.activeInHierarchy);
                m_spellButtons[0].SetActive(PlayerStatisticController.Instance.intelligence.value >= 1);
                m_spellButtons[1].SetActive(PlayerStatisticController.Instance.intelligence.value > 10);
                m_spellButtons[2].SetActive(PlayerStatisticController.Instance.intelligence.value > 20);
                m_spellButtons[3].SetActive(PlayerStatisticController.Instance.intelligence.value > 30 );
                m_spellButtons[4].SetActive(PlayerStatisticController.Instance.intelligence.value > 40);
                m_spellButtons[5].SetActive(PlayerStatisticController.Instance.intelligence.value > 50);
        }

        public void MagicAttack(int id) {
            fightController.MagicAttack(id);
            ShowDamage();
        }

        public void ShowNormalAttack() {
            m_normalAttackPanel.SetActive(!m_normalAttackPanel.activeInHierarchy);
                m_normalAttackButtons[0].SetActive(PlayerStatisticController.Instance.strength.value >= 1);
                m_normalAttackButtons[1].SetActive(PlayerStatisticController.Instance.strength.value > 10);
                m_normalAttackButtons[2].SetActive(PlayerStatisticController.Instance.strength.value > 20);
                m_normalAttackButtons[3].SetActive(PlayerStatisticController.Instance.strength.value > 30);
        }

        public void NormalAttack(int id) {
            fightController.NormalAttack(id);
            ShowDamage();
        }

        public void ShowPotions() {
            m_potionsPanel.SetActive(!m_potionsPanel.activeInHierarchy);
        }

        public void DrinkPotion(int id) {
            fightController.DrinkPotion(id);
        }

        private void OnEnable() {
            fightController = FindObjectOfType<FightController>();
            fightController.isFight = true;
        }

        private void OnDisable() {
            fightController.isFight = false;
        }

        public void ShowDamage() {
            m_hitPanel.SetActive(true);
            m_damageTxt.text = fightController.damage.ToString();
            StartCoroutine(WaitForTime());
        }

        private IEnumerator WaitForTime() {
            yield return new WaitForSeconds(0.4f);
            m_hitPanel.SetActive(false);

        }
    }
}