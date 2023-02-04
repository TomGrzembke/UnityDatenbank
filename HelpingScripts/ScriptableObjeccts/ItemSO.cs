using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public Sprite itemSprite;
    public int itemID;
}

