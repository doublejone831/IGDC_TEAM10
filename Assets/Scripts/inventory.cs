using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour{
    // 나중에 인벤토리 관련 사운드 추가


    private InventorySlot[] slots;// 인벤토리 슬롯

    private List<ItemData> InventoryItemList; // 가지고 있는 아이템 리스트

    public GameObject on; //인벤토리 활성화 비활성화
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
                }
            }
        }
    }
}
