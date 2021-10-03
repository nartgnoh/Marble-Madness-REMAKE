using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
