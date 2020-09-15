using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
   public float Speed;
    public override void Update()
    {
        Speed = 3;
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        transform.LookAt(target, Vector3.up);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(60);
            StartCoroutine(DeathAnimation2());
           
        }
    }
}
