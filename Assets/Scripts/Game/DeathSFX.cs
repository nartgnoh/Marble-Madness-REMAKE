using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to Player
//Player Reset functionality
public class DeathSFX : MonoBehaviour
{
    static DeathSFX hit;
    public float threshold = -50f;
    public GameObject source;
    // Update is called once per frame

     void Awake()
     {
         if(hit == null)
         {    
             hit = this; // In first scene, make us the singleton.
             DontDestroyOnLoad(gameObject);
         }
         else if(hit != this)
             Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
     }

    void Update()
    {
        if (transform.position.y < threshold)
        {
            //DontDestroyOnLoad (transform.gameObject);
            //GameObject.DontDestroyOnLoad(source);
            Instantiate(source, transform.position, Quaternion.identity); //play SFX
        }
    }
    // Reset on enemy collision
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Enemies")
        {
            //DontDestroyOnLoad (transform.gameObject);
            //GameObject.DontDestroyOnLoad(source);
            Instantiate(source, transform.position, Quaternion.identity); //play SFX
        }
    }
}