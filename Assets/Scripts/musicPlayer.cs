using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
   private void Awake() {
       musicPlayersChecker();
   }
   void musicPlayersChecker(){
        int musicPlayers = FindObjectsOfType<musicPlayer>().Length;
        if(musicPlayers >1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
   }
}
