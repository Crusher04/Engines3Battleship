using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class MainMenu : MonoBehaviour
{
 
    public void RestartLevel ()
    {

        SceneManager.LoadScene("Scene1");

    }

    public void Quit ()
    {
  
        UnityEngine.Application.Quit();

    }

}
