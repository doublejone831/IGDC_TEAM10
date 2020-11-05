using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour{
    // 나중에 인벤토리 관련 사운드 추가


    private InventorySlot[] slots;// 인벤토리 슬롯

    private List<ItemData> InventoryItemList; // 가지고 있는 아이템 리스트

    public GameObject on; //
    public Transform tf; // slot들의 부모객체
    private int SelectedItem; // 아이템 선택
    private bool activated; // 인벤 활성화시 on
 


    private WaitForSeconds waittime = new WaitForSeconds(0.01f);

   
    void Start()
    {
        InventoryItemList = new List<ItemData>();//나중에 주인공 객체가 가지고 있는 아이템 리스트 불러오기로 변경
        slots = tf.GetComponentsInChildren<InventorySlot>();
        activated = false;
        
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } // 슬롯 초기화

    public void ShowItem()
    {
        RemoveSlot();
        for (int i = 0; i < InventoryItemList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddItem(InventoryItemList[i]);
        }
    } // 각 슬롯에 가지고있는 아이템 리스트의 아이템들을 대입.출력
  
    public void Selecteditem()
    {
        StopAllCoroutines();

        if (InventoryItemList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for (int i = 0; i < InventoryItemList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color;

            
        }
    }


    // Update is called once per frame
    void Update(){
 
            if (Input.GetKeyDown(KeyCode.I))
            {
                activated = !activated;
                Debug.Log("눌림");

                if (activated == true)
                {
                    
                    on.SetActive(true);
                    Debug.Log("켜짐");
       
                }
                else
                {
 
                    on.SetActive(false);
                    Debug.Log("꺼짐");
                    
                }


            }

            if (activated)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (SelectedItem < InventoryItemList.Count - 4)
                        SelectedItem += 4;
                    else
                        SelectedItem %= 4;

                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (SelectedItem > 1)
                        SelectedItem -= 4;
                    else
                        SelectedItem = InventoryItemList.Count - 4 - SelectedItem;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (SelectedItem < InventoryItemList.Count - 1)
                        SelectedItem++;
                    else
                        SelectedItem = 0;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (SelectedItem > 0)
                        SelectedItem--;
                    else
                        SelectedItem = InventoryItemList.Count - 1;

                }
                else if (Input.GetKeyDown(KeyCode.Z))
                {
                    //메시지창 출력
                }
            }//아이템 활성화시 키입력 처리
     

    }


}
