namespace FernusGames.RPGSystem {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class Attribute {

        public string name;
        public UnityAction<int> onChange;

        public int value {
            set {
                PlayerPrefs.SetInt(name, value);
                onChange?.Invoke(value);
            }
            get {
                return PlayerPrefs.GetInt(name);
            }
        }

        public Attribute (int startValue, string name, UnityAction<int> onChange) {
            this.name = name;
            this.onChange = onChange;
            this.value = startValue;
        }

        public static explicit operator Attribute(int v) {
            throw new NotImplementedException();
        }
    }

}
