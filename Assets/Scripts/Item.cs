using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;

    public int SellItem (int rarity)
    {
        int profict = price * rarity;
        return profict;
    }
}
