using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class MainMenuScript : MonoBehaviour
{



    [SerializeField]

    public PlaceObjectCube script2;





    private void Awake()
    {

        script2 = GetComponent<PlaceObjectCube>();
    }

    public int rotate;

    public void RestartLevel ()
    {

        SceneManager.LoadScene("Scene1");

    }

    public void Quit ()
    {
  
        UnityEngine.Application.Quit();

    }


   
    public void Rotate ()
    {

        script2.Rotate();
       

    }

}
