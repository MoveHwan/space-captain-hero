using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    public float testCurExp = 0;        // 테스트용 경험치
    public float testMaxExp = 40f;      // 테스트용 경험치통
    public float testLevel = 1;         // 테스트용 레벨
    public float testKill = 0;          // 테스트용 킬수
    public float remainTime = 0;        // 테스트용 라운드 시간
    public float curHealth = 100f;         // 테스트용 체력
    public float maxHealth = 100f;      // 테스트용 전체 체력
    public bool attack = false;         // 테스트용 공격

    

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        // 테스트용 경험치 획득과 초기화
        if (testCurExp < testMaxExp){
            testCurExp = testCurExp + 0.6f * Time.fixedDeltaTime;
        }
        else{
            testCurExp = 0;
            testMaxExp = testMaxExp + testMaxExp / 2.0f;
            testLevel+=1;
        }

        // 테스트용 공격
        if (attack) {
            curHealth -= 10;
            attack = false;
        }

        switch (type)
        {
            case InfoType.Exp:
                float curExp = testCurExp; //GameManager.Instance.exp;
                float maxExp = testMaxExp; //GameManager.Instance.nextExp[GameManager.level];
                mySlider.value = curExp / maxExp;
                break;

            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", testLevel); //GameManager.Instance.level);   // 원하는 인자를 지정된 형태의 문자열로 변환
                break;                                                                                // 0:F0 -> 초기숫자0, F0:소수점 아래 자릿수 0 
            
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", testKill);    //GameManager.Instance.kill);   // 원하는 인자를 지정된 형태의 문자열로 변환
                break;
            
            case InfoType.Time:
                remainTime = remainTime - Time.deltaTime;    //GameManager.Instance.maxGameTime - GameManager.Instance.gameTime;
                
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);     // 0:D0 -> 초기숫자 0, D2:일반 자릿수 2
                break;
            
            case InfoType.Health:
                //float curHealth = GameManager.Instance.health;
                //float maxHealth = GameManager.Instance.maxHealth;

                mySlider.value = curHealth / maxHealth;

                break;
        }
    }
}
