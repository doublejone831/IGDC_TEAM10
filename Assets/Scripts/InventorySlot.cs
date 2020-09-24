using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour{
    // DB매니저 에서 불러올 예정
    public Image Item_Icon;
    public Text Item_FlaverText;
    public Text Item_name;
    public void AddItem(ItemData _item){
        Item_FlaverText.text = _item.ItemFlavorText;
        Item_name.text = _item.ItemName;
        Item_Icon.sprite = _item.ItemImage;
    }
    
    public void OnMouseOver()
    {
        
    }
    public void RemoveItem(){
        Item_FlaverText.text = " ";
        Item_name.text = " ";
        Item_Icon.sprite = null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
