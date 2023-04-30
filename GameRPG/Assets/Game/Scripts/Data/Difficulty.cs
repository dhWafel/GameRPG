namespace Game.Data {
    using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Difficulty", order = 1)]
    public class Difficulty : ScriptableObject {
        public float expMultiplier;
        public float damageMultiplier;
    }
}
