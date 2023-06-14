using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FernusGames.RPGSystem;

public class FightController : MonoBehaviour{

    [SerializeField]
    private Animator m_attack;
    [SerializeField]
    private Animator m_playerDead;

    private bool IsPlayerMove;
    private bool lockUpdate;
    public bool isFight;
    public int damage;

    [SerializeField]
    private Image blockImage;

    private void Start() {
        IsPlayerMove = true;
    }

    public void NormalAttack(int a) {
        if (EnemyStatisticController.Instance.enemy == null) {
            return;
        }
        m_attack.SetTrigger("IsAttack");
        int attackPlayer= (2 * DiceRolls.ThrowDice(4)) + (PlayerStatisticController.Instance.strength.value * DiceRolls.ThrowDice(6));
        int deffEnemy = EnemyStatisticController.Instance.enemy.armor/15;
        damage = a * (attackPlayer - deffEnemy);

             if (a == 1) {
                 EnemyStatisticController.Instance.enemyLife.value -= damage;
             }
             if (a == 2) {
                 EnemyStatisticController.Instance.enemyLife.value -= damage;
             }
             if (a == 3) {
                 EnemyStatisticController.Instance.enemyLife.value -= damage;
             }
             if (a == 4) {
                 EnemyStatisticController.Instance.enemyLife.value -= damage;
             }
 
         Debug.Log("damage: " + damage);
        IsPlayerMove = false;
    }

    public void MagicAttack(int a) {

        if (PlayerStatisticController.Instance.mana.value >= 5) {
            int damage = (PlayerStatisticController.Instance.intelligence.value * a * Random.Range(1, 20));
            if (a == 1) {
                StartCoroutine(WaitForTime(1, () => {
                    EnemyStatisticController.Instance.enemyLife.value -= damage;
                    PlayerStatisticController.Instance.mana.value -= 5;
                }));
                EnemyStatisticController.Instance.enemyLife.value -= damage;
            }
            if (a == 2) {
                StartCoroutine(WaitForTime(1, () => {
                    EnemyStatisticController.Instance.enemyLife.value -= damage;
                    PlayerStatisticController.Instance.mana.value -= 5;
                }));
                EnemyStatisticController.Instance.enemyLife.value -= damage;
            }
            if (a == 3) {
                EnemyStatisticController.Instance.enemyLife.value -= damage;
                PlayerStatisticController.Instance.mana.value -= 15;
            }
            if (a == 4) {
                EnemyStatisticController.Instance.enemyLife.value -= damage;
                PlayerStatisticController.Instance.mana.value -= 20;
            }
            if (a == 5) {
                EnemyStatisticController.Instance.enemyLife.value -= 2 * damage;
                PlayerStatisticController.Instance.mana.value -= 25;
            }
            if (a == 6) {
                EnemyStatisticController.Instance.enemyLife.value -= 3 * damage;
                PlayerStatisticController.Instance.mana.value -= 30;
            }
        }
        IsPlayerMove = false;
    }

    public void DrinkPotion(int a) {
        if (a == 1) {
            PlayerStatisticController.Instance.life.value += 10;
        }
        if (a == 2) {
            PlayerStatisticController.Instance.life.value += 60;
        }
        if (a == 3) {
            PlayerStatisticController.Instance.life.value += 100;
        }
        if (a == 4) {
            PlayerStatisticController.Instance.life.value += 300;
        }
        if (a == 5) {
            PlayerStatisticController.Instance.life.value += 500;
        }
        if (a == 6) {
            PlayerStatisticController.Instance.mana.value += 70;
        }
        if (a == 7) {
            PlayerStatisticController.Instance.mana.value += 120;
        }
        if (a == 8) {
            PlayerStatisticController.Instance.mana.value += 200;
        }
        if (a == 9) {
            PlayerStatisticController.Instance.mana.value += 300;
        }
        if (a == 10) {
            PlayerStatisticController.Instance.mana.value += 500;
        }
        IsPlayerMove = false;
    }

    private void Update() {
        if (!lockUpdate && isFight) {
            CheckIfEnemyIsDead();
            CheckIfPlayerIsDead();
            PlayerTurn();
        }
    }

    public void CheckIfEnemyIsDead() {
        if (EnemyStatisticController.Instance.enemy != null && EnemyStatisticController.Instance.enemyLife.value == 0) {
            blockImage.gameObject.SetActive(true);
            GetExp();
            GetGold();
            GetIngredients();
            lockUpdate = true;
            StartCoroutine(WaitForTime(10, () => {
                //EnemyStatisticController.Instance.SpawnEnemy();
                blockImage.gameObject.SetActive(false);  
                lockUpdate = false;
            }));
            EnemyStatisticController.Instance.enemy = null;  
        }
    }

    public void CheckIfPlayerIsDead() {
        if(PlayerStatisticController.Instance.life.value == 0) {
            m_playerDead.SetTrigger("IsDead");
        }
    }

    public void GetExp() {
        float a = Game.DifficultyController.Instance.activeDifficultyData.expMultiplier;
        Debug.Log(a);
        if (EnemyStatisticController.Instance.enemy.lvl > 8) {
            PlayerStatisticController.Instance.exp.value += 500;
        }
        if (EnemyStatisticController.Instance.enemy.lvl > 5) {
            PlayerStatisticController.Instance.exp.value += 300;
        }
        if (EnemyStatisticController.Instance.enemy.lvl > 3) {
            PlayerStatisticController.Instance.exp.value += 200;
        }
        if (EnemyStatisticController.Instance.enemy.lvl >= 1) {
            PlayerStatisticController.Instance.exp.value  += (int)(100*a);
        }
    }

    public void GetGold() {
        if (EnemyStatisticController.Instance.enemy.lvl == 10) {
            PlayerStatisticController.Instance.gold.value += 370;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 9) {
            PlayerStatisticController.Instance.gold.value += 300;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 8) {
            PlayerStatisticController.Instance.gold.value += 250;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 7) {
            PlayerStatisticController.Instance.gold.value += 200;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 6) {
            PlayerStatisticController.Instance.gold.value += 170;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 5) {
            PlayerStatisticController.Instance.gold.value += 130;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 4) {
            PlayerStatisticController.Instance.gold.value += 80;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 3) {
            PlayerStatisticController.Instance.gold.value += 50;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 2) {
            PlayerStatisticController.Instance.gold.value += 30;
        }
        if (EnemyStatisticController.Instance.enemy.lvl == 1) {
            PlayerStatisticController.Instance.gold.value += 10;
        }

    }

    public void GetIngredients() {
        if(EnemyStatisticController.Instance.enemy.imageName.Equals("Mouse")){
            IngredientsController.Instance.ingredientsList[9].ingredientQuantity++;
            Debug.Log("mysz");
        }
        if (EnemyStatisticController.Instance.enemy.imageName.Equals("WhiteMouse")) {
            IngredientsController.Instance.ingredientsList[9].ingredientQuantity++;
            Debug.Log("biała mysz");
        }
        if (EnemyStatisticController.Instance.enemy.imageName.Equals("Rabbit")) {
            Debug.Log("królik");
        }
        if (EnemyStatisticController.Instance.enemy.imageName.Equals("Boar")) {
            IngredientsController.Instance.ingredientsList[10].ingredientQuantity++;
            Debug.Log("dzik");
        }
    }

    public void EnemyTurn() {
        if (EnemyStatisticController.Instance.enemy != null) {
            int attackEnemy = EnemyStatisticController.Instance.enemy.atak;
            int deffPlayer = PlayerStatisticController.Instance.defense.value;
            int damage = attackEnemy - deffPlayer;
            StartCoroutine(WaitForTime(5, () => {
                PlayerStatisticController.Instance.life.value -= damage;
            }));
            IsPlayerMove = true;
        }
    }

    public void PlayerTurn() {
        StartCoroutine(WaitForClick());
    }

    public IEnumerator WaitForTime(int t, UnityAction onFinish) {
        yield return new WaitForSeconds(t);
        onFinish?.Invoke();
    }

    public IEnumerator WaitForClick() {
        while(IsPlayerMove){
            yield return null;
        }
        EnemyTurn();
    }
}