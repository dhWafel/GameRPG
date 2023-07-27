namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;
    using FernusGames.RPGSystem;

    public class TrainingGroundPanel : Panel {

        [SerializeField]
        private GameObject m_choiceTraining;
        [SerializeField]
        private GameObject m_aprroval;

        [SerializeField]
        private Text m_TrainingMsg;

        public void ShowChoiceTreningPanel() {
            OffBlacksmithPanel();
            m_choiceTraining.SetActive(true);
        }


        public void ChoiceTraining(string choice) {
            if (choice == "Strength") {
                PlayerStatisticController.Instance.strength.value += 1;
                m_TrainingMsg.text = "Zwiększono siłę + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Dexterity") {
                PlayerStatisticController.Instance.dexterity.value += 1;
                m_TrainingMsg.text = "Zwiększono zręczność + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Endurance") {
                PlayerStatisticController.Instance.endurance.value += 1;
                m_TrainingMsg.text = "Zwiększono wytrzymałość + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Intelligence") {
                PlayerStatisticController.Instance.intelligence.value += 1;
                m_TrainingMsg.text = "Zwiększono inteligencję + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Luck") {
                PlayerStatisticController.Instance.luck.value += 1;
                m_TrainingMsg.text = "Zwiększono szczęście + 1";
                m_aprroval.SetActive(true);
            }
        }



        public void OffBlacksmithPanel() {
            //m_forge.SetActive(false);
            //m_buy.SetActive(false);
        }

    }
}