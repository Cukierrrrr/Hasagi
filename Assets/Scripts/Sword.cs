using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private EnemyAtack AtackInformation;
    private PlayerDeath Killer;
    private bool atack =  false;

    private void Awake()
    {
        AtackInformation = transform.parent.gameObject.GetComponent<EnemyAtack>();
        Killer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) && atack == true && !transform.parent.gameObject.GetComponent<EnemyDearth>().isDead())//zadanie obra�e� je�li gracz dotknie miecza i jeszcze ich nie otrzyma�
        {
            Killer.damage(3);
            atack = false;//zablokowanie opcji wielokrotnego otrzymania obra�e� przez gracza
        }
    }
    public void StartAtack()
    {
        atack = true;
    }
    public void StopAtack()
    {
        atack = false;
    }
}
