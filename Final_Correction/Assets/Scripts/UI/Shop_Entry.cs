using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class Shop_Entry : MonoBehaviour
{
    [SerializeField] public GameObject Panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Panel.SetActive(true);

        }
    }
}