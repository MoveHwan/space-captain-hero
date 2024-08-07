using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;


    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(GameManager.Instance.player.transform.position);          //필드 오브젝트 좌표를 카메라기준 좌표로 전환
    }
}
