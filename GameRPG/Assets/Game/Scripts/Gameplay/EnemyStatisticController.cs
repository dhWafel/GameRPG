using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using FernusGames.RPGSystem;

public class EnemyStatisticController : MonoSingleton<EnemyStatisticController>{

    [HideInInspector]
    public Game.Data.Enemy enemy;

    public AttributeMinMax enemyLife;

    [SerializeField]
    private Game.UI.TopBar m_topBarEnemyHp;
    [SerializeField]
    private Image enemyImage;


    private void Start(){
        SpawnEnemy();
    }

    private void Update() {   
        //SpawnEnemy();
    }

    private Game.Data.Enemy LoadEnemy() {
        string path = Application.dataPath + Game.Const.c_enemiesPath;
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            var m_enemyList = (List<Game.Data.Enemy>)formatter.Deserialize(stream);
            stream.Close();

            var m_enemyListOk = new List<Game.Data.Enemy>();

            if (m_enemyList != null) {
                for (int i = 0; i < m_enemyList.Count; i++) {
                    if (PlayerStatisticController.Instance.playerLevel >= (m_enemyList[i].lvl-1) && PlayerStatisticController.Instance.playerLevel <= (m_enemyList[i].lvl + 3)) {
                        m_enemyListOk.Add(m_enemyList[i]);
                    }
                }
            }
            if (m_enemyListOk.Count == 0) {
                return null;
            }
            return m_enemyListOk[UnityEngine.Random.Range(0, m_enemyListOk.Count)];
        } else {
            return null;
        }
    }

    public void SpawnEnemy() {
        enemy = LoadEnemy();
        if (enemy != null) {
            enemyLife = new AttributeMinMax(enemy.lifeMax, enemy.lifeMax, "enemyLife", (attribute) => {
                m_topBarEnemyHp.UpdateAttribute(attribute);
            });
            enemyImage.sprite = Resources.Load<Sprite>("EnemyImages/" + enemy.imageName);
            Debug.Log("exp " + PlayerStatisticController.Instance.exp.value);
        } else {
            Debug.Log("null");
        }
    }
}