namespace FernusGames.LocalizationSystem{
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public class LocalizationController{
        private const string c_langKey = "lang";
        private static LocalizationController m_instance;
        public static LocalizationController instance {
            get {
                if (m_instance == null) {
                m_instance = new LocalizationController();
                }
                return m_instance;
            }
        }
        public UnityAction OnLanguageChange { get; set; } //event


        private Dictionary<string, string> m_language;

        public LocalizationController(){
            Reload();
        }
        public void Reload(){
            LoadLanguage(PlayerPrefs.GetString(c_langKey,"PL"));
        }
    
        public string GetValue(string key){
            return m_language[key];
        }

        public void LoadLanguage(string lang){
            PlayerPrefs.SetString(c_langKey, lang);
            m_language = new Dictionary<string, string>();
            string text = Resources.Load<TextAsset>(lang).text;
            string[] lines = text.Split('\n');
            
            for(var i = 0; i < lines.Length; i++){
                string[] data = lines[i].Split(';');
                m_language.Add(data[0], data[1]);
            }
            OnLanguageChange?.Invoke();
        }
    }
}