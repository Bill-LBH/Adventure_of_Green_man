using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Portal: MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}