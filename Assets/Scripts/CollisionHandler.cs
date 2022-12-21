using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float crashDelay;
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player Ship bumped into GameObject : " + collision.gameObject.name);
        GetComponent<PlayerController>().enabled = false;
        Invoke("reloadScene",1);

    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Ship passed by GameObject : " + other.gameObject.name);
        CrashSentence(crashDelay);
    }

    private void CrashSentence(float crashDelay)
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<BoxCollider>().enabled=false;
        deathSequence();   
        Invoke("reloadScene",crashDelay);
    }
    private void reloadScene(){
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);

    }
    
    public void deathSequence(){
        GameObject playerDeathObject = GetComponent<PlayerController>().deathObject;
        playerDeathObject.GetComponent<ParticleSystem>().Play();
        //ParticleSystem.EmissionModule particleEmission = playerDeathObject.GetComponent<ParticleSystem>().emission;
        //particleEmission.enabled =true;
    }
}
