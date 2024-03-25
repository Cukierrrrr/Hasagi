using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private float maxflayingtime;

    float flayingtime = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * speed;//dodanie ruchu pocisku
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag) || collision.CompareTag(targetTag))
        {
            if (collision.gameObject.TryGetComponent<EnemyDearth>(out EnemyDearth enemyDeath))
            {
                enemyDeath.damage();
            }
            else if (collision.gameObject.TryGetComponent<PlayerDeath>(out PlayerDeath playerDeath))
            {
                playerDeath.damage(2);
            }
            Destroy(gameObject);//zniszczenie pocisku po trafieniu ziemii lub wrogra
        }
    }
    private void Update()
    {
        if (flayingtime < maxflayingtime)
        {
            flayingtime += Time.deltaTime;//dodanie czsu do timera(flying time)
        }
        else
        {
            Destroy(gameObject);//usuniêcie obiektu jeœli czas lotu przekroczy maksymalny czas lotu
        }
    }

}
