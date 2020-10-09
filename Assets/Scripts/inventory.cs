using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour{
    // 나중에 인벤토리 관련 사운드 추가


    private InventorySlot[] slots;// 인벤토리 슬롯

    private List<ItemData> InventoryItemList; // 가지고 있는 아이템 리스트

    public GameObject on; //인벤토리 활성화 비활성화
    public GameObject go;
    public Transform tf; // slot들의 부모객체
    private int SelectedItem; // 아이템 선택
    private bool activated; // 인벤 활성화시 on
    private bool ItemActivated; // 아이템 활성화 체크
    private bool StopKeyInput; // 키입력제한 (사용 여부 화면 출력시)
    private bool PreventExec; // 중복 실행 제한

    private WaitForSeconds Waiting = new WaitForSeconds(0.01f);

   
    void Start()
    {
        InventoryItemList = new List<ItemData>();//나중에 주인공 객체가 가지고 있는 아이템 리스트 불러오기로 변경
        slots = tf.GetComponentsInChildren<InventorySlot>();
        
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
 


    // Update is called once per frame
    void Update(){
        if (!StopKeyInput)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                activated = !activated;

                if (activated)
                {
                    //오디오
                    on.SetActive(true);
                    go.SetActive(true);
                    ItemActivated = false;
                }
                else
                {
                    go.SetActive(false);
                    ItemActivated = false;
                }
            }
        }

    }
}
