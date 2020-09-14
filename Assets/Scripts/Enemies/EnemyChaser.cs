using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    public float Speed;

    public override void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        transform.LookAt(target, Vector3.up);
    }
}
