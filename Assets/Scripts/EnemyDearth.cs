using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDearth : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private string bulletTag = "bullet";
    [SerializeField] private string spikeTag = "Spike";
    [SerializeField] private int maxHealth;
    [SerializeField] private float throwPower = 15f;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Sprite health2of3;
    [SerializeField] private Sprite health1of3;
    [SerializeField] private Sprite health1of2;

    private int health;
    private bool toranaded = false;
    private float timer = 0;
    private float timer2 = 0;
    private Animator aniamtor;
    private SpriteRenderer healthBarGraphic;
    bool dead = false;
    private void Start()
    {
        health = maxHealth;
        aniamtor = gameObject.GetComponent<Animator>();
        healthBarGraphic = healthBar.GetComponent<SpriteRenderer>();
}
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                toranaded = false;
            }
        }
        if (maxHealth == 3 && health == 2)
        {
            healthBarGraphic.sprite = health2of3;
        }
        else if (maxHealth == 3 && health == 1)
        {
            healthBarGraphic.sprite = health1of3;
        }
        else if (maxHealth == 2 && health == 1)
        {
            healthBarGraphic.sprite = health1of2;
        }
        if (health <= 0 && !dead)//odegranie animacji �mierci po tym jak hp jest mniejsze od 1
        {
            aniamtor.Play("Smoke");
            dead = true;
            Destroy(healthBar);
        }
        if (dead)
        {
            timer2 += Time.deltaTime;
            if(timer2 >= 0.58)
            {
                Destroy(gameObject);//usuni�cie przeciwnika po odegraniu animacji �mierci
            }
        }
    }
    public void damage()
    {
        health--;
    }
    public void tornadoDamage()
    {
        toranaded = true;
        timer = 2;//ustawienie timera maj�cego za zadanie wielokrotnego wykonania efektu tornada za jednym razem
        damage();//zadanie obra�e�
        if(health > 0) { 
        rigidbody.AddForce(new Vector2(0, throwPower), ForceMode2D.Impulse);//podrzucenie wroga
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(spikeTag))//usuni�cie przeciwnika po dotkni�ciu kolc�w
        {
            Destroy(gameObject);
        }
    }
    public bool isTornaded()
    {
        return toranaded;
    }
    public bool isDead()
    {
        return dead;
    }
}
