using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to Player
//Player Reset functionality
public class Reset : MonoBehaviour
{
    public float threshold = -50f;
    public GameObject source;
    // Update is called once per frame

    void Update()
    {
        if (transform.position.y < threshold)
        {
            //DontDestroyOnLoad (transform.gameObject);
            //GameObject.DontDestroyOnLoad(source);
            Instantiate(source, transform.position, Quaternion.identity); //play SFX
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
