﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class TaskfromBD : MonoBehaviour
{
    public static string[] save_title = new string[200];
    public static string[] save_deadline = new string[200];
    public static string[] save_username = new string[200];
    public static string[] save_status = new string[200];
    public static int counter_task = 0;
    public static int onStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (onStart == 0)
        {
            StartCoroutine(GetDate());
            onStart = 1;
        }
        
    }

    public static IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/select_task.php"))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string[] words = www.downloadHandler.text.Split('*');
                foreach (string word in words)
                {
                    if (word.Length > 1)
                    {
                        string[] word1 = word.Split(' ');
                        save_title[counter_task] = word1[0];
                        save_deadline[counter_task] = word1[1];
                        save_username[counter_task] = word1[2];
                        save_status[counter_task] = word1[3];
                        counter_task++;
                    }
}
            }

        }
    }

    public static IEnumerator UpdateStatusTask(string title, string status)
    {
        WWWForm form = new WWWForm();
        form.AddField("title", title);
        form.AddField("status", status);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/update_status_task.php",form))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

      public static IEnumerator DeleteStatusTask(string status)
      {
          WWWForm form = new WWWForm();
          form.AddField("status", status);

          using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/delete_task.php", form))
          {
              yield return www.Send();
              if (www.isNetworkError || www.isHttpError)
              {
                  Debug.Log(www.error);
              }
              else
              {
                  Debug.Log(www.downloadHandler.text);
              }
          }
      }

    public static IEnumerator MoveATask(string title, string actual_username, string new_username)
    {
        WWWForm form = new WWWForm();
        form.AddField("title", title);
        form.AddField("actual_username", actual_username);
        form.AddField("new_username", new_username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/move_task.php", form))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
