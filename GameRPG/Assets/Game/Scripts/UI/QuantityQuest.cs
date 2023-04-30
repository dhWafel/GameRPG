namespace Game.UI {
    using UnityEngine;
    using UnityEngine.UI;

    public class QuantityQuest : MonoBehaviour {

        [SerializeField]
        private Text m_questQuantity;


        public void EventQuest() {
            m_questQuantity.text = "Zadania " + QuestController.Instance.quests.Count.ToString();
        }

        private void OnEnable() {
            QuestController.Instance.onQuestChange+=EventQuest;
        }

        private void OnDisable() {
            QuestController.Instance.onQuestChange-=EventQuest;
        }
    }
}

