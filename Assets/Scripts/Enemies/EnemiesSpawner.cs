using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public void StartCoroutine(int time, int enemiesAmount)
    {
        StartCoroutine(EnemiesSpawnTime(time, enemiesAmount));
    }
    IEnumerator EnemiesSpawnTime(int time, int enemiesAmount)
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            Debug.Log(time);
            float angleX = Random.Range(-28, 28);
            float angleY = Random.Range(-33, 33);
            Vector3 coordenates = new Vector3(angleX, angleY, 0);
            GameObject _Enemy = Instantiate(Enemy, coordenates, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
