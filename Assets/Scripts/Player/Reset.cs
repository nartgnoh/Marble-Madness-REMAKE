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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Instantiate(source, transform.position, Quaternion.identity); //play SFX
        }
    }
    // Reset on enemy collision
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Instantiate(source, transform.position, Quaternion.identity); //play SFX
        }
    }
}
