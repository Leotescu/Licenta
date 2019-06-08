using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text employeeLogged;
    public Button logout;

    private void Start()
    {
        if(DBManager.LoggedIn)
        {
            employeeLogged.text = DBManager.username + ": " + DBManager.position; 
        }

    }

    public void LogOut()
    {
        DBManager.LogOut();
        employeeLogged.text = "No user logged in";
    }

    public void NotLogin()
    {
        if (DBManager.LoggedIn == false)
        {
            employeeLogged.text = "Please, log in, before this action";
        }
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);

    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogIn()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToMyActivities()
    {
        SceneManager.LoadScene(5);
    }
}
