using UnityEngine;

public class SceneManager : MonoBehaviour{

    public void Start(){
        DontDestroyOnLoad(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);       
    }

}