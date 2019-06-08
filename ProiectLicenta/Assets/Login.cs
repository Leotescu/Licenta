using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Login : MonoBehaviour
{
    
    public InputField usernameField;
    public InputField passwordField;
    public InputField positionField;

    public Button loginButton;
    public Button forgotpswButton;


    public void CallLogIn()
    {
        StartCoroutine(LogIn());
    }

    IEnumerator LogIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("position", positionField.text);
        form.AddField("password", passwordField.text);
        
#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);

        yield return www;

        if (www.text[0] == '0')
        {
            DBManager.username = usernameField.text;
            DBManager.position = positionField.text;
            DBManager.tasks_solved = int.Parse(www.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToForgotPassword()
    {
        SceneManager.LoadScene(4);
    }

    public void VerifyInputs()
    {
        loginButton.interactable = (usernameField.text.Length >= 7 &&
             passwordField.text.Length >= 8 &&
               passwordField.text.Length >= 8 && (positionField.text == "Manager" || positionField.text == "Employee"));
    }

}
