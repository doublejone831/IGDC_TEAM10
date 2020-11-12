using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto1DoorClick : MonoBehaviour
{
    GameObject player;
   
   
    private GameObject target;
    public bool DoorTrigger = false; //DoorLocation에 캐릭터가 올라가면 true반환

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //플레이어 찾기
    }
        

    void FixedUpdate()
    {
        if (player.transform.position.x>=10&&player.transform.position.x<15)
        {
            DoorTrigger = true;
        }
        else
        {
            DoorTrigger = false;
        }
        if(DoorTrigger == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CastRay(); //마우스로 오브젝트 인식하고 타겟을 정하는 함수
                if (target == this.gameObject)
                {
                    SceneManager.LoadScene("Tutorial2");
                    DoorTrigger = false;
                }
                
            }
        }
        
    }

    void CastRay() // 오브젝트를 레이로 인식

    {
        target = null; 

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //2차원벡터 pos의 좌표값은 마우스의 좌표

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f); //좌표값만 주고 의미가 없는 방향과 거리는 주지 않음



        if (hit.collider != null)
        { 
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            Debug.Log(hit.collider.name);
        }

    }


}
