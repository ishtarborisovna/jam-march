using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void ResetClick(bool isReset)
    {
        if (isReset) 
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Load"); 
        }
    }
}
