using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoing;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject tornado;
    [SerializeField] private Animator Ranimator;
    [SerializeField] private Animator Qanimator;
    [SerializeField] private float Firerate;
    [SerializeField] private float tornadoFirerate;
    AudioMenager audioMenager;
    float cooldown = 0;
    float tornadoCooldown = 0;
    private void Awake()
    {
        audioMenager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMenager>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && cooldown == 0)
        {
            Instantiate(bullet, shootingPoing.position, transform.rotation);
            cooldown = Firerate;
            Qanimator.Play("LoadingQ");
        }
        if (Input.GetKey(KeyCode.R) && tornadoCooldown == 0)
        {
            Instantiate(tornado, shootingPoing.position, transform.rotation);
            tornadoCooldown = tornadoFirerate;
            audioMenager.TornadoSound();
            Ranimator.Play("LoadingR");
        }
        if (cooldown > 0) 
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                cooldown = 0f;
                Qanimator.Play("Q");
            }
        }
        if (tornadoCooldown > 0)
        {
            tornadoCooldown -= Time.deltaTime;
            if (tornadoCooldown <= 0f)
            {
                tornadoCooldown = 0f;
                Ranimator.Play("R");
            }
        }
    }
}
