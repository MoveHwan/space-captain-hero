using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    public float testCurExp = 0;        // �׽�Ʈ�� ����ġ
    public float testMaxExp = 40f;      // �׽�Ʈ�� ����ġ��
    public float testLevel = 1;         // �׽�Ʈ�� ����
    public float testKill = 0;          // �׽�Ʈ�� ų��
    public float remainTime = 0;        // �׽�Ʈ�� ���� �ð�
    public float curHealth = 100f;         // �׽�Ʈ�� ü��
    public float maxHealth = 100f;      // �׽�Ʈ�� ��ü ü��
    public bool attack = false;         // �׽�Ʈ�� ����

    

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        // �׽�Ʈ�� ����ġ ȹ��� �ʱ�ȭ
        if (testCurExp < testMaxExp){
            testCurExp = testCurExp + 0.6f * Time.fixedDeltaTime;
        }
        else{
            testCurExp = 0;
            testMaxExp = testMaxExp + testMaxExp / 2.0f;
            testLevel+=1;
        }

        // �׽�Ʈ�� ����
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
                myText.text = string.Format("Lv.{0:F0}", testLevel); //GameManager.Instance.level);   // ���ϴ� ���ڸ� ������ ������ ���ڿ��� ��ȯ
                break;                                                                                // 0:F0 -> �ʱ����0, F0:�Ҽ��� �Ʒ� �ڸ��� 0 
            
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", testKill);    //GameManager.Instance.kill);   // ���ϴ� ���ڸ� ������ ������ ���ڿ��� ��ȯ
                break;
            
            case InfoType.Time:
                remainTime = remainTime - Time.deltaTime;    //GameManager.Instance.maxGameTime - GameManager.Instance.gameTime;
                
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);     // 0:D0 -> �ʱ���� 0, D2:�Ϲ� �ڸ��� 2
                break;
            
            case InfoType.Health:
                //float curHealth = GameManager.Instance.health;
                //float maxHealth = GameManager.Instance.maxHealth;

                mySlider.value = curHealth / maxHealth;

                break;
        }
    }
}
