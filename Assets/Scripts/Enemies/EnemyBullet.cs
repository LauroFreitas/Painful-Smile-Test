using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    public float speed;
    public float timer;
    private void Awake()
    {
        m_Rigidbody = transform.GetComponent<Rigidbody2D>();
        m_Rigidbody.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject, timer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }
}