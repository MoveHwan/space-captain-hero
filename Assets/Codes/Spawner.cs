using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;
    int level;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10f), spawnData.Length - 1);

        if (timer > spawnData[level].spawnTime)                         // 레벨에 따른 소환
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);                                    // PoolManager에서 정의한 몹들의 값을 불러와서 enemy에 저장
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;      // 마구찍은 스폰포인트중 랜덤으로 소환
        enemy.GetComponent<Enemy>().Init(spawnData[level]);                                     // 레벨에 따른 소환
    }
}

[System.Serializable]               // 직렬화를 통해 유니티에 변수들을 바로 받아올 수 있게 함
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
