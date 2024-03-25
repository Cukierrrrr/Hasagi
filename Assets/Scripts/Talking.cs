using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Talking : MonoBehaviour
{
    [SerializeField] private AudioMenager audioMenager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite E1;
    [SerializeField] private Sprite E2;
    [SerializeField] private Sprite E3;
    [SerializeField] private Sprite E4;
    [SerializeField] private Sprite E5;
    [SerializeField] private Sprite E6;
    [SerializeField] private Sprite E7;
    [SerializeField] private Sprite E8;
    [SerializeField] private Sprite E9;
    [SerializeField] private Sprite E10;
    [SerializeField] private Sprite E11;
    [SerializeField] private Sprite E12;
    [SerializeField] private Sprite E13;
    [SerializeField] private Sprite E14;
    [SerializeField] private Sprite E15;

    bool beforeDialog = true;
    float timer = 0;
    int currentSprite = 0;
    bool isInRangeOfTalking = false;
    List<Sprite> sprites;

    private void Awake()
    {
        sprites = new List<Sprite>() { E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, E11, E12, E13, E14, E15 };
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(isInRangeOfTalking && timer >=0.05f && currentSprite < 14 && beforeDialog)//pojawianie siê chmurki jeœli gracz jest w zasiêgu
        {
            timer = 0;
            currentSprite++;
            spriteRenderer.sprite = sprites[currentSprite];
        }
        else if (!isInRangeOfTalking && timer >= 0.05f && currentSprite > 0 || !beforeDialog && timer >= 0.05f && currentSprite > 0)//chowanie siê chmurki jeœli gracz jest poza zasiêgiem lub zaczo³ dialog
        {
            timer = 0;
            currentSprite--;
            spriteRenderer.sprite = sprites[currentSprite];
        }
        if (Input.GetKeyDown(KeyCode.E) && beforeDialog && isInRangeOfTalking)
        {
            audioMenager.Dialog();
            beforeDialog = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRangeOfTalking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {    
        if (collision.CompareTag("Player"))
        {
            isInRangeOfTalking = false;
        }
    }
}
