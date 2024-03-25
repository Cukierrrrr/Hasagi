using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAtack: MonoBehaviour
{
    [SerializeField] private EnemySeen Range;//tutaj przypisujemy Range
    [SerializeField] private Animator animator;

    string currentAnimation = "MeleeEnemyStanding";
    float animationTime = 1.4f / 1.5f;
    float cooldown = 0f;
    int swordphase = 0;

    Sword sword;
    BoxCollider2D swordColider;
    Transform swordTransform;

    private void Awake()
    {
        sword = gameObject.transform.GetChild(5).gameObject.GetComponent<Sword>();
        swordColider = gameObject.transform.GetChild(5).gameObject.GetComponent<BoxCollider2D>();
        swordTransform = gameObject.transform.GetChild(5).gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (cooldown == 0 && Range.IsSeen() && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !gameObject.GetComponent<EnemyDearth>().isDead())//rozpoczêcie ataku jeœli gracz jest w zasiêgu
        {
            cooldown = animationTime;
            currentAnimation = "MeleeEnemyAtack";
            animator.Play(currentAnimation);
        }
        else if (cooldown <= 0.8 / 1.5 && swordphase == 0)//zmiana pozycji colidera miecza w zalerznoœci od klatki animacji
        {
            swordColider.offset = new Vector2(0.17f, 0.02f);
            swordColider.size = new Vector2(0.075f, 0.5f);
            swordTransform.Rotate(new Vector3(0, 0, -10));
            swordphase = 1;
            sword.StartAtack();//Od tego momentu jeœli gracz dotknie miecza otrzyma obra¿enia
        }
        else if (cooldown <= 0.75 / 1.5 && swordphase == 1)
        {
            swordColider.offset = new Vector2(0.2f, 0.05f);
            swordTransform.Rotate(new Vector3(0, 0, -7));
            swordphase = 2;
        }
        else if (cooldown <= 0.683 / 1.5 && swordphase == 2)
        {
            swordColider.offset = new Vector2(0.24f, 0.06f);
            swordTransform.Rotate(new Vector3(0, 0, -8));
            swordphase = 3;
        }
        else if (cooldown <= 0.616 / 1.5 && swordphase == 3)
        {
            swordColider.offset = new Vector2(0.31f, 0.14f);
            swordTransform.Rotate(new Vector3(0, 0, -18));
            swordphase = 4;
        }
        else if (cooldown <= 0.55 / 1.5 && swordphase == 4)
        {
            swordColider.offset = new Vector2(0.34f, 0.2f);
            swordTransform.Rotate(new Vector3(0, 0, -13));
            swordphase = 5;
        }
        else if (cooldown <= 0.483 / 1.5 && swordphase == 5)
        {
            swordColider.offset = new Vector2(0.31f, 0.14f);
            swordTransform.Rotate(new Vector3(0, 0, 13));
            swordphase = 6;
        }
        else if (cooldown <= 0.416 / 1.5 && swordphase == 6)
        {
            swordColider.offset = new Vector2(0.24f, 0.06f);
            swordTransform.Rotate(new Vector3(0, 0, 18));
            swordphase = 7;
        }
        else if (cooldown <= 0.35 / 1.5 && swordphase == 7)
        {
            swordColider.offset = new Vector2(0.24f, 0.06f);
            swordTransform.Rotate(new Vector3(0, 0, 8));
            swordphase = 8;
        }
        else if (cooldown <= 0.283 / 1.5 && swordphase == 8)
        {
            swordColider.offset = new Vector2(0.2f, 0.05f);
            swordTransform.Rotate(new Vector3(0, 0, 7));
            swordphase = 9;
        }
        else if (cooldown <= 0.216 / 1.5 && swordphase == 9)
        {
            swordColider.offset = new Vector2(0.17f, 0.02f);
            swordTransform.Rotate(new Vector3(0, 0, 10));
            swordphase = 10;
            sword.StopAtack();//od tego momentu jeœli gracz dotknie  miecza nie otrzyma obra¿eñ
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f && !gameObject.GetComponent<EnemyDearth>().isDead())//powrót do stanu sprzed ataku
            {
                cooldown = 0f;
                currentAnimation = "MeleeEnemyStanding";
                animator.Play(currentAnimation);
                swordphase = 0;
                swordColider.offset = new Vector2(0.12f, -0.05f);
                swordColider.size = new Vector2(0.075f, 0.42f);
            }
        }
    }
}
