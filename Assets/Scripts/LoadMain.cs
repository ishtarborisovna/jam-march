using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

}
