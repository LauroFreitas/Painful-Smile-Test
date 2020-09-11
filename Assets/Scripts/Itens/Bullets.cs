using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    public float speed;
    public float timer;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Rigidbody = transform.GetComponent<Rigidbody2D>();
        m_Rigidbody.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject, timer);
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Enemmy")
        {
            var enemy = other.gameObject.GetComponentInParent<EnemyFollowing>();

            if (enemy != null)
            {
                enemy.gameObject.SetActive(false);
            }

            Destroy(gameObject);

            ScoreManager points;
            points = GameObject.Find("Points").GetComponent<ScoreManager>();

            points.Points = 10;

            Debug.Log("Atingiu " + other.gameObject.name);
        }

        if (other.gameObject.tag == "Player")
        {
            var playerheal = other.gameObject.GetComponentInParent<PlayerVida>();
            if (playerheal != null)
            {
                playerheal.gameObject.SetActive(false);
            }

            ScoreManager points;
            points = GameObject.Find("Points").GetComponent<ScoreManager>();

            points.Points = 10;


        }

        gameObject.GetComponent<Collider>().enabled = false;
        */
    }


}