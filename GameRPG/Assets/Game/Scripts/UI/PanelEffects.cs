using UnityEngine;

public class PanelEffects : MonoBehaviour{

    private bool m_isLock;
    
    public void MoveButton() {
        transform.Translate(0, 5, 0);
        Debug.Log("na guziku");
    }
    public void RemoveButton() {
        transform.Translate(0, -5, 0);
        Debug.Log("za guzikiem");
    }

    public void ClickButton() {
        if (!m_isLock) {
            transform.Translate(0, -10, 0);
            m_isLock = true;
        }
    }
}