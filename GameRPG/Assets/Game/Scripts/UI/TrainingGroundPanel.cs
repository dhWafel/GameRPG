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
                m_TrainingMsg.text = "Zwiêkszono si³ê + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Dexterity") {
                PlayerStatisticController.Instance.dexterity.value += 1;
                m_TrainingMsg.text = "Zwiêkszono zrêcznoœæ + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Endurance") {
                PlayerStatisticController.Instance.endurance.value += 1;
                m_TrainingMsg.text = "Zwiêkszono wytrzyma³oœæ + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Intelligence") {
                PlayerStatisticController.Instance.intelligence.value += 1;
                m_TrainingMsg.text = "Zwiêkszono inteligencjê + 1";
                m_aprroval.SetActive(true);
            }
            if (choice == "Luck") {
                PlayerStatisticController.Instance.luck.value += 1;
                m_TrainingMsg.text = "Zwiêkszono szczêœcie + 1";
                m_aprroval.SetActive(true);
            }
        }



        public void OffBlacksmithPanel() {
            //m_forge.SetActive(false);
            //m_buy.SetActive(false);
        }

    }
}