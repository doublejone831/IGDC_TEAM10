using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPick : MonoBehaviour
{
    private GameObject target;

    void FixedUpdate()

    {
        if (Input.GetMouseButtonDown(0))
        {
            Shootingray();
            if (target == this.gameObject)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void Shootingray() // 오브젝트를 레이로 인식

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
