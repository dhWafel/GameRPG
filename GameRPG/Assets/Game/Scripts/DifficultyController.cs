namespace Game {
    using UnityEngine;

    public class DifficultyController : MonoSingleton<DifficultyController> {
        
        public Data.Difficulty activeDifficultyData {
            get;
            private set;
        }
         public void setDifficulty(string name) {
            activeDifficultyData = Resources.Load<Data.Difficulty>("Difficulty/" + name);
        }

        protected override void OnAwake() {
            setDifficulty(Const.defaultDifficulty);
        }
    }
}