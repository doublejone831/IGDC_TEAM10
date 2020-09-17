using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemData
{
    public int ItemID;
    public string ItemName;
    public string ItemFlavorText;
    public string Interaction_Text;
    public Sprite ItemImage;
    public ItemType itemType;
    public ItemData LinkedItem_F;
    public ItemData LinkedItem_P;


    public enum ItemType
    {
        Use,
        hint,
        gettable,

    }


    public ItemData(int _ItemID, string _ItemName, string _ItemFlavorText, ItemType _itemType)
    {
        ItemID = _ItemID;
        ItemName = _ItemName;
        ItemFlavorText = _ItemFlavorText;
        itemType = _itemType;
        
    }
}
