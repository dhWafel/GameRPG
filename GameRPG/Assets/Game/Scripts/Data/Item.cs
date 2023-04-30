namespace Game.Data {
    [System.Serializable]
    public class Item{

        public string name;
        public string imageName;
        public string itemDescription;
        public string type;

        public ItemAttribute[] attributes;

        public int quality;
        public int price;
        public int indexItemType;
        public int indexItemSubType;
    }
}