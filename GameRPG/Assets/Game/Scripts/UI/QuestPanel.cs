namespace Game.UI {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class QuestPanel : Panel {
        [SerializeField]
        private Text m_questTxt;
        [SerializeField]
        private GameObject m_questTxtParent;
        [SerializeField]
        private Text m_questDescription;

        private List<Text> m_questListTxt;

        private void Start() {
            m_questListTxt = new List<Text>();
        }

        private void ClearTxt() {
            for (int i = 0; i < m_questListTxt.Count; i++) {
                Destroy(m_questListTxt[i].gameObject);
            }
            m_questListTxt = new List<Text>();
        }

        public void ShowQuestList(bool isActive, bool isDone) {
            ClearTxt();
            for (int i = 0; i < QuestController.Instance.questList.Count; i++) {
                if ((QuestController.Instance.questList[i].questIsActive == isActive) && (QuestController.Instance.questList[i].questIsDone == isDone)) {
                    var newTxt = Instantiate(m_questTxt, m_questTxtParent.transform);
                    newTxt.text = QuestController.Instance.questList[i].questName;
                    m_questListTxt.Add(newTxt);
                    int j = i;
                    newTxt.GetComponent<Button>().onClick.AddListener(() => { m_questDescription.text = QuestController.Instance.questList[j].questDiscription; });
                }
            }
        }

        public void ShowQuestListActive() {
            ShowQuestList(true, false);
        }

        public void ShowQuestListDone() {
            ShowQuestList(false, true);
        }

        public void ShowQuestListAll() {
            //ShowQuestList(true, true);
            ShowQuestList(false, true);
            ShowQuestList(true, false);
        }
    }
}