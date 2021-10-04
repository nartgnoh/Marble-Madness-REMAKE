using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to Player
//Player Reset functionality
public class Reset : MonoBehaviour
{
    public float threshold = -50f;
    public GameObject source; //SFX
    private bool AlreadyPlayed = false;
    // Update is called once per frame

    void Update()
    {
        if (transform.position.y < threshold)
        {
            StartCoroutine(pause());
        }
    }
    // Reset on enemy collision
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Enemies")
        {
            StartCoroutine(pause());
        }
    }
    IEnumerator pause(){
        if (!AlreadyPlayed)
        {
            Instantiate(source, transform.position, Quaternion.identity);
            AlreadyPlayed = true;
        }
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
