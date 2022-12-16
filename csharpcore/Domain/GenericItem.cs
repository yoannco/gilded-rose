namespace ClassLibrary1
{
    public class GenericItem : EquipmentItem
    {
        public GenericItem(string name, int sellIn, float quality, float price, int attack, int defense, bool isConjured = false) : base(name, sellIn, quality, price, attack, defense, isConjured)
        {
        }
    }
}