using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager pool;                //poolmanager 스크립트에서도 사용
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

}
