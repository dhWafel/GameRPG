namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;
    public class TavernPanel : Panel {

        [SerializeField]
        private GameObject m_quest;
        [SerializeField]
        private GameObject m_room;


        public Text questMessageTxt;
        public Text questDiscriptionTxt;
        public Text executionTxt;

        private string gossip;
        private string execution;
        private string questDiscription;
        private string questMessage;
        private string questYes;
        private string questNo;

        private int rand;

        public void WritteGossipTxt() {
            int a = Random.Range(1, 11);
            OffTavernPanels();
            if (a == 1) {
                gossip = "Pączki u piekarza Franka są najlepsze na świecie.";
            }
            if (a == 2) {
                gossip = "Córka młynarza zakochała się w księciu Teosiu.";
            }
            if (a == 3) {
                gossip = "Kowal Ben nosi różowe stringi.";
            }
            if (a == 4) {
                gossip = "Plotka4";
            }
            if (a == 5) {
                gossip = "Plotka5";
            }
            if (a == 6) {
                gossip = "Plotka6";
            }
            if (a == 7) {
                gossip = "Plotka7";
            }
            if (a == 8) {
                gossip = "Plotka8";
            }
            if (a == 9) {
                gossip = "Plotka9";
            }
            if (a == 10) {
                gossip = "Plotka10";
            }
            executionTxt.text = gossip;
        }

        public void WritteQuest() {
            VisibleQuest();
            rand = Random.Range(0, QuestController.Instance.questList.Count);
            questDiscription = QuestController.Instance.questList[rand].questDiscription;
            questDiscriptionTxt.text = questDiscription;
            questMessage = "Chcesz się podjąć tego zadania?";

            questMessageTxt.text = questMessage;
        }

        public void WritteRoom(int g) {
            VisibleRoom();
            if (PlayerStatisticController.Instance.gold.value >= 0) {
                if (g == 1) {
                    if (PlayerStatisticController.Instance.gold.value >= 5) {
                        PlayerStatisticController.Instance.gold.value -= 5;
                    } else { Debug.Log("brak kasy"); }
                }
                if (g == 2) {
                    if (PlayerStatisticController.Instance.gold.value >= 20) {
                        PlayerStatisticController.Instance.gold.value -= 20;
                    } else { Debug.Log("brak kasy"); }
                }
                if (g == 3) {
                    if (PlayerStatisticController.Instance.gold.value >= 100) {
                        PlayerStatisticController.Instance.gold.value -= 100;
                    } else { Debug.Log("brak kasy"); }
                }
                if (g == 4) {
                    if (PlayerStatisticController.Instance.gold.value >= 200) {
                        PlayerStatisticController.Instance.gold.value -= 200;
                    } else { Debug.Log("brak kasy"); }
                }
                if (g == 5) {
                    if (PlayerStatisticController.Instance.gold.value >= 500) {
                        PlayerStatisticController.Instance.gold.value -= 500;
                    } else { Debug.Log("brak kasy"); }
                }
            }
        }

        public void AcceptedQuest() {
            Debug.Log("tak");
            QuestController.Instance.questList[rand].questIsActive = true;
            //QuestController.Instance.m_questList[rand].questIsDone = false;
            //QuestController.Instance.m_questList[rand].questIsAll = true;
        }
        public void NoAcceptedQuest() {
            Debug.Log("Nie");
            //QuestController.Instance.m_questList[rand].questIsActive = false;
            QuestController.Instance.questList[rand].questIsDone = true;
            //QuestController.Instance.m_questList[rand].questIsAll = true;
        }

        private void VisibleQuest() {
            OffTavernPanels();
            executionTxt.gameObject.SetActive(false);
            m_quest.SetActive(true);
        }

        private void VisibleRoom() {
            OffTavernPanels();
            executionTxt.gameObject.SetActive(false);
            m_room.SetActive(true);
        }

        private void OffTavernPanels() {
            executionTxt.gameObject.SetActive(true);
            m_quest.SetActive(false);
            m_room.SetActive(false);
        }
    }
}