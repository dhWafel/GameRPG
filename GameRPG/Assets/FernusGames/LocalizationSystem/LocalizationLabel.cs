namespace FernusGames.LocalizationSystem{
    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LocalizationLabel : MonoBehaviour{
        public string key;

        private void OnEnable(){
    LocalizationController.instance.OnLanguageChange += UpdateView;
        UpdateView();
    }

    private void OnDisable()
    {
        LocalizationController.instance.OnLanguageChange -= UpdateView;
    }

    private void UpdateView(){
            string value = LocalizationController.instance.GetValue(key);
            GetComponent<UnityEngine.UI.Text>().text = value;
    }
    }
}
