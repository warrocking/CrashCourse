using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header ("1라운드")] 
    [SerializeField] GameObject[] enemise1;
    [SerializeField] GameObject[] boss1;
    [SerializeField] private float[] arrPoxX1;

    [Header("2라운드")]
    [SerializeField] GameObject[] enemise2;
    [SerializeField] GameObject[] boss2;
    [SerializeField] private float[] arrPoxX2;

    [Header("3라운드")]
    [SerializeField] GameObject[] enemise3;
    [SerializeField] GameObject[] boss3;
    [SerializeField] private float[] arrPoxX3;

    [Space (20f)]

    
    [SerializeField] float moveSpeed;//5f
    [SerializeField] float spawnInterval = 1.5f;

    public int routineNum=0;

    //void Start()
    //{
    //    if (routineNum == 0)
    //    {
    //        StartEnemyRoutine();
    //    }
    //    else if(routineNum==1)
    //    {
    //
    //    }
    //    else
    //    {
    //
    //    }
    //    
    //}
    //
    //void StartEnemyRoutine()
    //{
    //    StartCoroutine("EnemyRoutine");
    //}
    //
    //public void StopEnemyRoutine()
    //{
    //    StopCoroutine("EnemyRoutine");
    //}
    //
    //IEnumerator EnemyRoutine()
    //{
    //    yield return new WaitForSeconds(3f);
    //
    //    
    //
    //    int enemyIndex = 0;
    //    int spawnCount = 0;
    //
    //    
    //
    //    while(true)
    //    {
    //        foreach (float posX in arrPoxX1)
    //        {
    //            int index = Random.Range(0, enemise1.Length);
    //            //SpawnEnemy(posX, index);
    //            SpawnEnemy(posX, enemyIndex, moveSpeed);
    //
    //        }
    //        spawnCount+=1;
    //        if(spawnCount %10==0)
    //        {
    //            enemyIndex++;
    //            moveSpeed += 2;
    //        }
    //        if(enemyIndex>= enemise1.Length)
    //        {
    //            SpawnBoss();
    //            enemyIndex = 0;
    //            moveSpeed = 5f;
    //        }
    //
    //
    //        yield return new WaitForSeconds(spawnInterval);
    //    }
    //
    //    
    //}
    //void SpawnEnemy(float posX, int index, float moveSpeed)
    //{
    //    Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
    //
    //    if(Random.Range(0,5)==0)//20%의 확률로 index 추가
    //    {
    //        index += 1;
    //    }
    //
    //    if(index>= enemise1.Length)
    //    {
    //        index = enemise1.Length-1;
    //    }
    //
    //
    //
    //
    //    GameObject enemyObject = Instantiate(enemise1[index], spawnPos, Quaternion.identity);
    //    Enemy enemy = enemyObject.GetComponent<Enemy>();
    //    enemy.SetMoveSpeed(moveSpeed);
    //}
    void Start()
    {
        if (routineNum == 0)
        {
            StartEnemyRoutine(enemise1, boss1, arrPoxX1);
        }
        else if (routineNum == 1)
        {
            StartEnemyRoutine(enemise2, boss2, arrPoxX2);
        }
        else if (routineNum == 2)
        {
            StartEnemyRoutine(enemise3, boss3, arrPoxX3);
        }
        else
        {
            routineNum = 0;
            return;
        }
    }

    void StartEnemyRoutine(GameObject[] enemies, GameObject[] bosses, float[] spawnPositions)
    {
        StartCoroutine(EnemyRoutine(enemies, bosses, spawnPositions));
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine(GameObject[] enemies, GameObject[] bosses, float[] spawnPositions)
    {
        yield return new WaitForSeconds(3f);

        int enemyIndex = 0;
        int spawnCount = 0;

        while (true)
        {
            foreach (float posX in spawnPositions)
            {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, index, enemyIndex, moveSpeed, enemies);

            }
            spawnCount += 1;
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;
            }
            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss(bosses);
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, int enemyIndex, float moveSpeed, GameObject[] enemies)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0, 5) == 0)
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }
    void SpawnBoss(GameObject[] bosses)
    {
        int index = Random.Range(0, bosses.Length);
        Vector3 spawnPos = transform.position;
        Instantiate(bosses[index], spawnPos, Quaternion.identity);
    }
}
