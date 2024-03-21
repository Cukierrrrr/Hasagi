using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private string spikeTag = "Spike";
    [SerializeField] private int health = 6;
    [SerializeField] private AudioMenager audioMenager;
    [SerializeField] private Sprite health1of1;
    [SerializeField] private Sprite health5of6;
    [SerializeField] private Sprite health2of3;
    [SerializeField] private Sprite health1of2;
    [SerializeField] private Sprite health1of3;
    [SerializeField] private Sprite health1of6;
    [SerializeField] private Sprite health0of1;
    private bool death = false;
    private SpriteRenderer healthBar;
    public float time = 0;
    private void Awake()
    {
        audioMenager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMenager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<SpriteRenderer>();
    }
    public void damage(int amount)
    {
        health -= amount;
        if (health == 0)
        {
            healthBar.sprite = health0of1;
            audioMenager.PlayerDearthSound();
            death = true;
        }
        else if (health == 6)
        {
            healthBar.sprite = health1of1;
        }
        else if (health == 5)
        {
            healthBar.sprite = health5of6;
        }
        else if (health == 4)
        {
            healthBar.sprite = health2of3;
        }
        else if (health == 3)
        {
            healthBar.sprite = health1of2;
        }
        else if (health == 2)
        {
            healthBar.sprite = health1of3;
        }
        else if (health == 1)
        {
            healthBar.sprite = health1of6;
        }
    }
    private void Update()
    {
        if (death)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public bool isPlayerDead()
    {
        return death;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(spikeTag))
        {
            health = 0;
            if (!death)
            {
                audioMenager.PlayerDearthSound();
            }
            death = true;
        }
    }
}
