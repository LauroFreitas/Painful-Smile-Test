using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject EnemyChoser;
    public GameObject EnemyShooter;
    public void StartCoroutine(int time, int enemiesAmount)
    {
        StartCoroutine(EnemiesSpawnTime(time, enemiesAmount));
    }
    IEnumerator EnemiesSpawnTime(int time, int enemiesAmount)
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            int a = Random.Range(0,2);
            if (a == 1) 
            {
                
                    float angleX = Random.Range(-28, 28);
                    float angleY = Random.Range(-33, 33);
                    Vector3 coordenates = new Vector3(angleX, angleY, 0);
                    GameObject _Enemy = Instantiate(EnemyChoser, coordenates, Quaternion.identity);

                     angleX = Random.Range(-28, 28);
                     angleY = Random.Range(-33, 33);
                     coordenates = new Vector3(angleX, angleY, 0);
                     _Enemy = Instantiate(EnemyChoser, coordenates, Quaternion.identity);

                    yield return new WaitForSeconds(time);
            }
            else 
            {
                    float angleX = Random.Range(-28, 28);
                    float angleY = Random.Range(-33, 33);
                    Vector3 coordenates = new Vector3(angleX, angleY, 0);
                    GameObject _Enemy = Instantiate(EnemyShooter, coordenates, Quaternion.identity);

                    angleX = Random.Range(-28, 28);
                    angleY = Random.Range(-33, 33);
                    coordenates = new Vector3(angleX, angleY, 0);
                   _Enemy = Instantiate(EnemyShooter, coordenates, Quaternion.identity);

                    yield return new WaitForSeconds(time);
            }
        }
    }
}
