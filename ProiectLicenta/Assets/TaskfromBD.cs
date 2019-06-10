using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDate());
    }

    IEnumerator GetDate()
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
               // Debug.Log(www.downloadHandler.text);
                string[] words = www.downloadHandler.text.Split('*');
                Debug.Log(words);
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
}
