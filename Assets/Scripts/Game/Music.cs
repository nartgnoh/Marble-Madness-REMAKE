using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
 {
     static Music instance;
 
     void Awake()
     {
         if(instance == null)
         {    
             instance = this; // In first scene, make us the singleton.
             DontDestroyOnLoad(gameObject);
         }
         else if(instance != this)
             Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
     } 
 }