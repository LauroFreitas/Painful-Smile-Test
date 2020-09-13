using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SpawnEnemies(int spawnTime);
public class EnemiesSpawner : MonoBehaviour
{
    private int respawnTime;
    public static SpawnEnemies spawnEnemies;
    public GameObject Enemy;
    public int enemiesValue = 10;

    public void InstantiateEnemies(int spawnTime)
    {
        StartCoroutine(EnemiesSpawnTime(respawnTime, enemiesValue));
    }
    public void StopInstantiate()
    {
        spawnEnemies -= InstantiateEnemies;
        Debug.Log(spawnEnemies);
    }
    public void RestartInstantiate()
    {
        respawnTime = int.Parse(UIValues._valueEnemyTime);
        spawnEnemies += InstantiateEnemies;
        spawnEnemies.Invoke(respawnTime);//Invoka na primeira vez
    }
    IEnumerator EnemiesSpawnTime(int time, int enemiesAmount)
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            float angleX = Random.Range(-28, 28);
            float angleY = Random.Range(-33, 33);
            Vector3 coordenates = new Vector3(angleX, angleY, 0);
            GameObject _Enemy = Instantiate(Enemy, coordenates, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
