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

        if (timer > spawnData[level].spawnTime)                         // ������ ���� ��ȯ
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);                                    // PoolManager���� ������ ������ ���� �ҷ��ͼ� enemy�� ����
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;      // �������� ��������Ʈ�� �������� ��ȯ
        enemy.GetComponent<Enemy>().Init(spawnData[level]);                                     // ������ ���� ��ȯ
    }
}

[System.Serializable]               // ����ȭ�� ���� ����Ƽ�� �������� �ٷ� �޾ƿ� �� �ְ� ��
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
