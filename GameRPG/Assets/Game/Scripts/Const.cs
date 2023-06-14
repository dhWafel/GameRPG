namespace Game {
    using UnityEngine;

    public class Const {

        public const string defaultDifficulty = "Easy";

        public const string c_enemiesPath = "/File/enemies.fun";
        public const string c_itemsPath = "/File/items.txt";
        public const string c_questsPath = "/File/quests.csv";
        public const string c_ingredientsPath = "/File/ingredients.csv";
        public const string c_recipesPath = "/File/recipes.csv";

        public const float playerSpeed = 6.0f;

        public const int startHp = 100;
        public const int startHpMax = 100;
        public const int startMp = 50;
        public const int startMpMax = 50;
        public const int startExp = 0;
        public const int startExpMax = 1000;

        public const int defaultPlayerLv = 1;
        public const int defaultPlayerAp = 1;
        public const int defaultPlayerSp = 1;

        public const int defaultStrength = 1;
        public const int defaultDefense = 1;
        public const int defaultDexterity = 1;
        public const int defaultEndurance = 1;
        public const int defaultIntelligence = 1;
        public const int defaultLuck = 1;
        public const int defaultGold = 100;

        public const int lvUpAp = 5;
        public const int lvUpSp = 1;
        public const int lvUpExp = 1000;
        public const int distributionOfPointLife = 50;
        public const int distributionOfPointMana = 10;

        public const string playerLevelKey = "playerLevel";
        public const string playerApKey = "playerAp";
        public const string playerSpKey = "playerSp";

        public const string startHpKey = "life";
        public const string startMpKey = "mana";
        public const string startExpKey = "exp";

        public const string strengthKey = "strength";
        public const string defenseKey = "defense";
        public const string dexterityKey = "dexterity";
        public const string enduranceKey = "endurance";
        public const string intelligenceKey = "intelligence";
        public const string luckKey = "luck";
        public const string goldKey = "gold";

        public const string playerPanel = "Player";
        public const string inventoryPanel = "Inventory";
        public const string questPanel = "Quest";
        public const string skillPanel = "Skills";
        public const string menuPanel = "Menu";

        public static readonly string[] cityPanels = {
            "Tavern",
            "Blacksmith",
            "Armorer",
            "Alchemist",
            "Shop",
            "TrainingGround",
            "MageTower",
            "Stable"
        };
    }
}

