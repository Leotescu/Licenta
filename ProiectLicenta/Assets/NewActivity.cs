using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewActivity : MonoBehaviour
{
    public Text message_text;
    public InputField title;
    public InputField deadline;
    public InputField description;
    public InputField username;
    public InputField status;
    public static int counter_tasks = 0;
    public Button submit;


    public int checkFunction()
    {
        if (DBManager.position == "Manager")
            return 1;
        return 0;
    }

    public void CallNewActivity()
    {
        if (checkFunction() == 1)
        {
            TaskfromBD.onStart = 1;
            StartCoroutine(NewActivity1());
           // UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
        else
        {
            message_text.text = "You are not manager";
        }
        
    }

    IEnumerator NewActivity1()
    {
        WWWForm form = new WWWForm();
        form.AddField("title", title.text);
        form.AddField("deadline", deadline.text);
        form.AddField("description", description.text);
        form.AddField("username", username.text);
        form.AddField("status", status.text);


#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW("http://localhost/sqlconnect/task.php", form);
        
        
        yield return www;

        if (www.text == "0")
        {
            message_text.text = "The task was added";
        }   
        else
        {
            message_text.text = "Error: " + www.text;
        }
    }

    

    public void GoToMyActivities()
    {
        TaskfromBD.onStart = 1;
        SceneManager.LoadScene(4);
    }



}
