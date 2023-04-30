namespace Game.Gameplay{
    using UnityEngine;

    public class MapObject : MonoBehaviour {

        [SerializeField]
        private MapObjectType m_type;

        private void OnTriggerEnter2D(Collider2D collision) {

            if (collision.tag.Equals("Player")) {
                switch (m_type) {
                    case MapObjectType.Castle:
                        UI.ControlPanel.Instance.ShowPanel("Castle1");
                        break;

                    case MapObjectType.Enemy:
                        UI.ControlPanel.Instance.ShowPanel("Fight");
                        break;

                    case MapObjectType.Gate1:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                        break;

                    case MapObjectType.Gate2:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                        break;
                    case MapObjectType.Lumberjack:
                        UI.ControlPanel.Instance.ShowPanel("Lumberjack's Cottage");
                        break;
                    case MapObjectType.Quarry:
                        UI.ControlPanel.Instance.ShowPanel("Querry");
                        break;
                    case MapObjectType.Sawmill:
                        UI.ControlPanel.Instance.ShowPanel("Sawmill");
                        break;
                }
            }
        }
    }
}
