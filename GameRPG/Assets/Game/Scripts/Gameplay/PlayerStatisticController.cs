using UnityEngine;
using UnityEngine.UI;
using FernusGames.RPGSystem;

public class PlayerStatisticController : MonoSingleton<PlayerStatisticController>{

    [SerializeField]
    private Game.UI.StatisticPanel m_statistic;

    [SerializeField]
    private Game.UI.TopBar m_topBarHp;
    [SerializeField]
    private Game.UI.TopBar m_topBarHpFight;
    [SerializeField]
    private Game.UI.TopBar m_topBarMp;
    [SerializeField]
    private Game.UI.TopBar m_topBarMpFight;
    [SerializeField]
    private Game.UI.TopBar m_topBarExp;

    [SerializeField]
    private GameObject m_promotion;
    [SerializeField]
    private GameObject m_empty;
    [SerializeField]
    private Button m_statisticButton;
    [SerializeField]
    private Button m_skillsButton;

    public AttributeMinMax life;
    public AttributeMinMax mana;
    public AttributeMinMax exp;
 
    public Attribute strength;
    public Attribute defense;
    public Attribute dexterity;
    public Attribute endurance;
    public Attribute intelligence;
    public Attribute luck;
    public Attribute gold;

    public bool isReady;

    public int playerLevel {
        set {
            PlayerPrefs.SetInt(Game.Const.playerLevelKey, value);
            UpdateStatisticPanel();
        }
        get {
            return PlayerPrefs.GetInt(Game.Const.playerLevelKey, Game.Const.defaultPlayerLv);
        }
    }

    public int playerAp {
        set {
            PlayerPrefs.SetInt(Game.Const.playerApKey, value);
            UpdateStatisticPanel();
        }
        get {
            return PlayerPrefs.GetInt(Game.Const.playerApKey, Game.Const.defaultPlayerAp);
        }
    }

    public int playerSp {
        set {
            PlayerPrefs.SetInt(Game.Const.playerSpKey, value);
            UpdateStatisticPanel();
        }
        get {
            return PlayerPrefs.GetInt(Game.Const.playerSpKey, Game.Const.defaultPlayerSp);
        }
    }


    private void Start(){

        life = new AttributeMinMax(Game.Const.startHp,Game.Const.startHpMax, Game.Const.startHpKey, (attribute) => {
            m_topBarHp.UpdateAttribute(attribute);
            m_topBarHpFight.UpdateAttribute(attribute);
            UpdateStatisticPanel();
        });
        mana = new AttributeMinMax(Game.Const.startMp, Game.Const.startMpMax, Game.Const.startMpKey, (attribute) => {
            m_topBarMp.UpdateAttribute(attribute);
            m_topBarMpFight.UpdateAttribute(attribute);
            UpdateStatisticPanel();
        });
        exp = new AttributeMinMax(Game.Const.startExp, Game.Const.startExpMax, Game.Const.startExpKey, (attribute) => {
            m_topBarExp.UpdateAttribute(attribute);
            if (attribute.value >= attribute.valueMax) { LevelUp(); }
            UpdateStatisticPanel();
        });

        strength = new Attribute (Game.Const.defaultStrength, Game.Const.strengthKey, (v) => { UpdateStatisticPanel(); });
        defense = new Attribute(Game.Const.defaultDefense, Game.Const.defenseKey, (v) => { UpdateStatisticPanel(); });
        dexterity = new Attribute(Game.Const.defaultDexterity, Game.Const.dexterityKey, (v) => { UpdateStatisticPanel(); });
        endurance = new Attribute(Game.Const.defaultEndurance, Game.Const.enduranceKey, (v) => { UpdateStatisticPanel(); });
        intelligence = new Attribute(Game.Const.defaultIntelligence, Game.Const.intelligenceKey, (v) => { UpdateStatisticPanel(); });
        luck = new Attribute(Game.Const.defaultLuck, Game.Const.luckKey, (v) => { UpdateStatisticPanel(); });
        gold = new Attribute(Game.Const.defaultGold, Game.Const.goldKey, (v) => { UpdateStatisticPanel(); });
        playerLevel = 1;
        playerAp = 0;
        playerSp = 0;

        isReady = true;
        UpdateStatisticPanel();
    }

    private void UpdateStatisticPanel() {
        m_statistic.UpdateStatistic(this);
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.U)) {
            LevelUp();
        }

        if (playerAp > 0) {
            m_promotion.SetActive(true);
            m_empty.SetActive(false);
            m_statisticButton.image.color = Color.green;
        } else {
            m_promotion.SetActive(false);
            m_empty.SetActive(true);
            m_statisticButton.image.color = Color.white;
        }

        if(playerSp > 0) {
            m_skillsButton.image.color = Color.green;
        } else {
            m_skillsButton.image.color = Color.white;
        }
    }

    public void LevelUp() {
        playerLevel++;
        playerAp += Game.Const.lvUpAp;
        playerSp += Game.Const.lvUpSp;
        exp.value -= Game.Const.lvUpExp;
    }

    public void DistributionOfAttributPoints(int a) {
        if (playerAp > 0) {
            if (a == 1) {
                strength.value++;
            }
            if (a == 2) {
                defense.value++;
            }
            if (a == 3) {
                dexterity.value++;
            }
            if (a == 4) {
                endurance.value++;
                life.valueMax += Game.Const.distributionOfPointLife;
            }
            if (a == 5) {
                intelligence.value++;
                mana.valueMax += Game.Const.distributionOfPointMana;
            }
            if (a == 6) {
                luck.value++;
            }
            playerAp--;
        } else {
            Debug.Log("brak AP");
        }
    }

    public void DistributionOfSkillPoints() {

    }

}