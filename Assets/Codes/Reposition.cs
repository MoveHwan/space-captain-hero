using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))      // �ݶ��̴� �±� Area �ƴ� �� ����
            return;

        
        Vector3 playerPos = GameManager.Instance.player.transform.position;     // �÷��̾� ��ġ
        Vector3 myPos = transform.position;                                     // Ÿ�ϸ� ��ġ
        float diffX = Mathf.Abs(playerPos.x - myPos.x);                         // �÷��̾�� Ÿ�ϸʰ��� x��Ÿ�
        float diffY = Mathf.Abs(playerPos.y - myPos.y);                         // �÷��̾�� Ÿ�ϸʰ��� y��Ÿ�
                                                                                // Mathf : �������� ���� Ŭ����, Mathf.Abs() : ���밪 �Լ�

        Vector3 playerDir = GameManager.Instance.player.inputVec;               // �÷��̾ �̵��� ����
        float dirX = playerDir.x < 0 ? -1 : 1;                                  // x�� ���� ���ǹ� ��� �ʱ�ȭ 
        float dirY = playerDir.y < 0 ? -1 : 1;                                  // y�� ���� ���ǹ� ��� �ʱ�ȭ 

        switch (transform.tag){                                                 
            case "Ground":
                if (diffX > diffY) {                                            // Ÿ�ϸ��� �������� �����̱� ���� ���ǹ�
                    transform.Translate(Vector3.right * dirX * 48);             // ��ġ �̵� ������ �������� dirX �������� 48ĭ
                }                                                               // dirX (��ǥ �̵��� ���� �� X�� ���� �����ϰ�� ����)
                
                else if (diffX < diffY){                                        // Ÿ�ϸ��� �������� �����̱� ���� ���ǹ�
                    transform.Translate(Vector3.up * dirY * 48);                // ��ġ �̵� ���� �������� dirY �������� 48ĭ
                }                                                               // dirY (��ǥ �̵��� ���� �� Y�� ���� �Ʒ��ϰ�� ����)

                break;
            case "Enemy":                                                       // �� ���ġ
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }

    }
}
