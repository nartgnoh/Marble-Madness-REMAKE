using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//just to test out
public class LevelEnd : MonoBehaviour
{
    //end screen Canvas
    public GameObject levelEndScreen;
    //quad marker
    public GameObject endMarker;


    // Start is called before the first frame update
    void Start()
    {
        //set active false at start
        levelEndScreen.SetActive(false);
    }

    //enters end marker
    void OnCollisionEnter(Collision collision)
    {
        //if collision with player, canvas shows
        if (collision.gameObject.tag == "Player")
        {
            levelEndScreen.SetActive(true);
        }
    }
    
}
