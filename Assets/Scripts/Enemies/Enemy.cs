using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public Slider hudLife;
    public int maxHealth = 100;
    public int currentHealth;
    public Sprite deteriorationStage1;
    public Sprite deteriorationStage2;
    public Sprite deteriorationStage3;


   [SerializeField] public Transform target { get; private set;}
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    public float offset;
    virtual public void Start()
    {
        target = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }
    virtual public void TakeDamage(int damege) 
    {
        currentHealth -= damege;
        SetHealth(currentHealth);
    }
    virtual public void SetMaxHealth(int health) 
    {
        hudLife.maxValue = health;
        hudLife.value = health;
    }
   virtual public void LateUpdate()
    {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
    virtual public void Update()
    {
        Death();
        Deterioration();
    }
    virtual public void Deterioration() 
    {
        if (currentHealth <= 60 && currentHealth > 40)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage1;
        }

        if (currentHealth <= 20 && currentHealth > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage2;
        }
    }

    virtual public void Death() 
    {
        if(currentHealth <= 0) 
        {
            StartCoroutine(DeathAnimation());
        }
    }
    virtual public void SetHealth(int health) 
    {
        hudLife.value = health;
    }
   virtual public IEnumerator DeathAnimation() 
   {
        var MetaEvents = this.gameObject.GetComponent<MetaEventSet>();
        
        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[0].ID == 1)
        {
            MetaEvents.metaEvents[0].Event.Invoke();
        }
            
        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[1].ID == 1)
        {
            MetaEvents.metaEvents[1].Event.Invoke();
        }
            
        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[2].ID == 1)
        {
            MetaEvents.metaEvents[2].Event.Invoke();
        }
      
        this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage3;
        this.gameObject.SetActive(false);
        target.GetComponent<UiPoints>().AddPoints(1);
   }

    virtual public IEnumerator DeathAnimation2()
    {
        var MetaEvents = this.gameObject.GetComponent<MetaEventSet>();

        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[0].ID == 1)
        {
            MetaEvents.metaEvents[0].Event.Invoke();
        }

        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[1].ID == 1)
        {
            MetaEvents.metaEvents[1].Event.Invoke();
        }

        yield return new WaitForSeconds(0.3f);

        if (MetaEvents.metaEvents[2].ID == 1)
        {
            MetaEvents.metaEvents[2].Event.Invoke();
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage3;
        this.gameObject.SetActive(false);
    }
}
