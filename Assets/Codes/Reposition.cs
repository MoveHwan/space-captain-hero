using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))      // 콜라이더 태그 Area 아닐 시 리턴
            return;

        
        Vector3 playerPos = GameManager.Instance.player.transform.position;     // 플레이어 위치
        Vector3 myPos = transform.position;                                     // 타일맵 위치
        float diffX = Mathf.Abs(playerPos.x - myPos.x);                         // 플레이어와 타일맵과의 x축거리
        float diffY = Mathf.Abs(playerPos.y - myPos.y);                         // 플레이어와 타일맵과의 y축거리
                                                                                // Mathf : 여러가지 수학 클래스, Mathf.Abs() : 절대값 함수

        Vector3 playerDir = GameManager.Instance.player.inputVec;               // 플레이어가 이동한 방향
        float dirX = playerDir.x < 0 ? -1 : 1;                                  // x축 방향 조건문 방식 초기화 
        float dirY = playerDir.y < 0 ? -1 : 1;                                  // y축 방향 조건문 방식 초기화 

        switch (transform.tag){                                                 
            case "Ground":
                if (diffX > diffY) {                                            // 타일맵을 수평으로 움직이기 위한 조건문
                    transform.Translate(Vector3.right * dirX * 48);             // 위치 이동 오른쪽 기준으로 dirX 방향으로 48칸
                }                                                               // dirX (좌표 이동이 음수 즉 X축 기준 왼쪽일경우 음수)
                
                else if (diffX < diffY){                                        // 타일맵을 수직으로 움직이기 위한 조건문
                    transform.Translate(Vector3.up * dirY * 48);                // 위치 이동 위쪽 기준으로 dirY 방향으로 48칸
                }                                                               // dirY (좌표 이동이 음수 즉 Y축 기준 아래일경우 음수)

                break;
            case "Enemy":

                break;
        }

    }
}
