namespace FernusGames.RPGSystem {

    using UnityEngine;
    using UnityEngine.Events;

    public class AttributeMinMax {

        private const string c_max = "max";

        public string name;
        public UnityAction<AttributeMinMax> onChange;

        public int value {
            set {
                value = Mathf.Clamp(value, 0, valueMax);
                PlayerPrefs.SetInt(name, value);
                onChange?.Invoke(this);
            }
            get {
                return PlayerPrefs.GetInt(name);
            }
        }

        public int valueMax {
            set {
                PlayerPrefs.SetInt(name + c_max, value);
                onChange?.Invoke(this);
            }
            get {
                return PlayerPrefs.GetInt(name + c_max);
            }
        }

        public float normalizedValue {
            get {
                return (float)value / (float)valueMax;
            }
        }

        public AttributeMinMax(int value, int valueMax, string name, UnityAction<AttributeMinMax> onChange) {
            this.name = name;
            this.onChange = onChange;
            this.valueMax = valueMax;
            this.value = value;
        }      
    }
}
