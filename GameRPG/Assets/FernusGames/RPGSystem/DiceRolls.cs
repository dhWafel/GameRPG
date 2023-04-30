namespace FernusGames.RPGSystem{
    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DiceRolls {

        public static int ThrowDice(int k){
            return Random.Range(1,k+1);
        }
    }
}
