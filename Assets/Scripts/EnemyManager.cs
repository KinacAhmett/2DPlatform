using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{

    public float health;
    public float damage;
    bool colliderBusy = false;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            slider.maxValue = health;
            slider.minValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !colliderBusy) 
        {
            colliderBusy = true;
            collision.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if(collision.tag == "Bullet") 
        {
            GetDamage(collision.GetComponent<BlulletManager>().bulletDamage);
            Destroy(collision.gameObject);
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            colliderBusy = false;
        }   
    }

public void GetDamage(float damage) 
    {
        if(health - damage >= 0) 
        {
            health -= damage;

        }
        else 
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();

    }

    void AmIDead() 
    {
        if(health <= 0) 
        {
            Destroy(gameObject);
        }
    }

}
