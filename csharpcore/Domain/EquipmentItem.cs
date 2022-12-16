using GildedRose;

namespace ClassLibrary1;

public class EquipmentItem : Item
{
    private int Attack { get; }
    private int Defense { get; }

    public EquipmentItem(string name, int sellIn, float quality, float price, int attack, int defense, bool isConjured = false) :
        base(name, sellIn, quality, price, isConjured)
    {
        Attack = attack;
        Defense = defense;
    }
}