using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullets;
    Transform frontalShoot;
    Transform sideShoot;
    Transform sideShoot2;
    Transform sideShoot3;
    public Enemy a;
    private void Awake()
    {
        frontalShoot = transform.GetChild(0).transform.GetChild(0).transform;
        sideShoot    = transform.GetChild(0).transform.GetChild(1).transform;
        sideShoot2   = transform.GetChild(0).transform.GetChild(2).transform;
        sideShoot3   = transform.GetChild(0).transform.GetChild(3).transform;
    }
    private void Update()
    {
        Shoting();
    }
    public void Shoting() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject frontalShoot_ = Instantiate(bullets, frontalShoot.position, frontalShoot.rotation);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject sideShoot_  = Instantiate(bullets, sideShoot.position, sideShoot.rotation);
            GameObject sideShoot2_ = Instantiate(bullets, sideShoot2.position, sideShoot2.rotation);
            GameObject sideShoot3_ = Instantiate(bullets, sideShoot3.position, sideShoot3.rotation);
        }
    }
}
