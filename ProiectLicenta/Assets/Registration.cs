using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Registration : MonoBehaviour
{
      public InputField usernameField;
      public InputField firstnameField;
      public InputField lastnameField;
      public InputField passwordField;
      public InputField positionField;
      public Button submitButton;


    public void CallRegister()
      {
          StartCoroutine(Register());
      }

      IEnumerator Register()
      {
          WWWForm form = new WWWForm();
          form.AddField("firstname", firstnameField.text);
          form.AddField("lastname", lastnameField.text);
          form.AddField("username", usernameField.text);
          form.AddField("password", passwordField.text);
          form.AddField("position", positionField.text);

#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);

          yield return www;

          if(www.text == "0")
          {
              Debug.Log("User created successfully.");
              UnityEngine.SceneManagement.SceneManager.LoadScene(0);
          }
          else
          {
              Debug.Log("User creation failed. Error #" + www.text);
          }
      }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void VerifyInputs()
      {
          submitButton.interactable = (usernameField.text.Length >= 7 &&
               firstnameField.text.Length >= 3 && lastnameField.text.Length >=3 &&  
               passwordField.text.Length >= 8 && (positionField.text == "Manager" || positionField.text == "Employee") );
      }
      
}
