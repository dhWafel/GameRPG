namespace Game.UI {
    using UnityEngine;

    public class ControlPanel : MonoSingleton<ControlPanel> {

        private TavernPanel tavernPanel;

        public Panel[] panels;
        private Panel m_visiblePanel;
        public Panel visiblePanel {
            get {
                return m_visiblePanel;
            }
            set {
                if (m_visiblePanel != null) m_visiblePanel.gameObject.SetActive(false);
                m_visiblePanel = value;
                if (m_visiblePanel != null) m_visiblePanel.gameObject.SetActive(true);
            }
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.P)) {
                TogglePanel(Const.playerPanel);
            }
            if (Input.GetKeyDown(KeyCode.I)) {
                    TogglePanel(Const.inventoryPanel); 
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                    TogglePanel(Const.questPanel);
            }
            if (Input.GetKeyDown(KeyCode.L)) {
                    TogglePanel(Const.skillPanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                    TogglePanel(Const.menuPanel);
            }


            if (Input.GetKeyDown(KeyCode.C)) {
                ControlPanel.Instance.ShowPanel("Castle1");
            }
        }

        private void TogglePanel(string panelName) {
            if(visiblePanel !=null && visiblePanel.name == panelName) {
                ClosePanel();
            } else {
                ShowPanel(panelName);
            }
        }

        public void ShowPanel(string panelName) {
            foreach (Panel panel in panels) {
                if (panel.name == panelName) {
                    visiblePanel = panel;
                    break;
                }
            }
        }

        public void EntranceToTheCity(int a) {
            ShowPanel(Const.cityPanels[a]);
        }

        public void ClosePanel() {
            //tavernPanel.OffPanelText();
            if (visiblePanel != null) {
                if (visiblePanel.backPanel != "") {
                    ShowPanel(visiblePanel.backPanel);
                } else {
                    visiblePanel = null;
                }
            }
        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}