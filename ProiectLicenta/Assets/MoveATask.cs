using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveATask : MonoBehaviour
{
    public InputField title;
    public InputField actualUser;
    public InputField newUser;
    int title_exist = 0;
    int actualUser_exist = 0;
    int task_user_exist = 0;
    int newUser_exist = 0;
    public Text message;
    int pos_task = 0;

    public int Pos_task { get => pos_task; set => pos_task = value; }

    // Start is called before the first frame update


    // Update is called once per frame
    public void UpdateTask()
    {
        if (DBManager.position == "Manager")
        {
            for (int i = 0; i < TaskfromBD.save_username.Length; i++)
            {
                if (TaskfromBD.save_title[i] == title.text)
                {
                    title_exist = 1;
                    pos_task = i;
                }
                if (TaskfromBD.save_username[i] == actualUser.text)
                {
                    actualUser_exist = 1;
                    if (TaskfromBD.save_title[i] == title.text)
                        task_user_exist = 1;
                }
                if (TaskfromBD.save_username[i] == newUser.text)
                    newUser_exist = 1;
            }

            if (title_exist == 0)
                message.text = "Task not exist in system.";
            else if (actualUser_exist == 0)
                message.text = "Actual user not exist in system.";
            else if (newUser_exist == 0)
                message.text = "New user not exist in system.";
            else if (task_user_exist == 0)
                message.text = "Actual user doesn't have this task.";
            else if (TaskfromBD.save_status[pos_task] != "Assigned")
                message.text = "Task is allready in progress.";
            else
            {
                message.text = "Task was updated.";


                for (int i = 0; i < TaskfromBD.save_username.Length; i++)
                {
                    if (TaskfromBD.save_username[i] == actualUser.text)
                    {
                        TaskfromBD.save_username[i] = newUser.text;
                        break;
                    }
                }
                StartCoroutine(TaskfromBD.MoveATask(title.text, actualUser.text, newUser.text));
            }
        }
        else
            message.text = "You are not manager.";
    }

    public void GoToMyActivities()
    {
        TaskfromBD.onStart = 1;
        SceneManager.LoadScene(4);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
