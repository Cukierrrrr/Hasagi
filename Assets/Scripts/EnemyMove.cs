using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer playerGraphics;
    [SerializeField] private EnemySeen enemySeenLeft;
    [SerializeField] private EnemySeen enemySeenRight;
    [SerializeField] private EnemySeen Range;//tutaj przypisujemy Range++

    private Vector3 direction;
    BoxCollider2D visionLeft;
    BoxCollider2D visionRight;

    private void Awake()
    {
        visionRight = enemySeenRight.GetComponent<BoxCollider2D>();
        visionLeft = enemySeenLeft.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (enemySeenLeft.IsSeen())// obrucenie przeciwnika w lewo jeœli gracz jest po lewej
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = new Vector3(-1, 0, 0);
            visionLeft.offset = new Vector2(4, 0);
            visionRight.offset = new Vector2(-4, 0);
        }
        if (enemySeenRight.IsSeen())// obrucenie przeciwnika w prawo jeœli gracz jest po prawej
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = new Vector3(1, 0, 0);
            visionLeft.offset = new Vector2(-4, 0);
            visionRight.offset = new Vector2(4, 0);
        }
    }

    private void FixedUpdate()
    {
        if (!Range.IsSeen()&& !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !gameObject.GetComponent<EnemyDearth>().isDead())// ruszanie siê przeciwnika jeœli  zobaczy gracza
        {
            Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y);
        }
    }
}
