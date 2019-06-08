using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhenPressRegister : MonoBehaviour
{
    public void GoToSuccessfulRegister()
    {
        SceneManager.LoadScene(3);
    }
}
