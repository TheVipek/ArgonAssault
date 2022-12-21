using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Rigidbody rb;
    [SerializeField] int health = 3;
    
    GameObject parent;
    [Tooltip("By how much score should be increased")][SerializeField] int myWorth;
    
    ScoreBoard scoreBoard;
    void Start(){
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();
        parent = GameObject.FindGameObjectWithTag("SpawnContainer");
    }
    
    void Update(){
        
    }
    private void OnParticleCollision(GameObject other) {
        Hit();
        if(health<=0)
        {
            killEnemy();
        }
    }
    void AddRigidbody(){
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void killEnemy(){
        scoreBoard.IncreaseScore(myWorth);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        sfxPlayer.instance.playExplosion();
        Destroy(gameObject);
    }
    void Hit(){
        Debug.Log("Hit");
        health-=1;
        GameObject vfx = Instantiate(hitVFX,transform.position,Quaternion.identity);
        vfx.transform.parent = parent.transform;
    }
}
