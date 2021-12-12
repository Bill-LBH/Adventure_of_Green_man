using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnController : MonoBehaviour
{
    public void ReturnToMain()
    {
        SceneManager.LoadScene("Starting_Scenes");
    }
}
