using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyActivity : MonoBehaviour
{
    

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToNewActivity()
    {
        SceneManager.LoadScene(6);
    }

}
