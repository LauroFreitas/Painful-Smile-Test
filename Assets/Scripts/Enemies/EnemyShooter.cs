using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    public float Speed;
    public GameObject bullets;
    Transform frontalShoot;

    public override void Start()
    {
        frontalShoot =  transform.GetChild(0).transform;
        base.Start();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
           StartCoroutine(Shooting());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           StopCoroutine(Shooting());
        }
    }
    IEnumerator Shooting() 
    {
        for (int i = 0; i < 999999999; i++)
        {
            yield return new WaitForSeconds(0.7f);
            GameObject frontalShoot_ = Instantiate(bullets, frontalShoot.position, frontalShoot.rotation);
        }
    }
}
