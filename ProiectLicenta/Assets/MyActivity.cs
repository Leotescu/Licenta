using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MyActivity : MonoBehaviour
{
    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;
    public InputField username;
    public InputField number_task_of_view;
    int not_tasks = 0;
    int not_username = 0;
    int not_task_for_username = 0;
    public Text message;
   
    public List<ExampleItemView> views = new List<ExampleItemView>();

    public void check_inputs()
    {
        int valid_username = 0;
        if(username.text =="")
        {
            if (int.Parse(number_task_of_view.text) > TaskfromBD.counter_task)
            {
                not_tasks = 1;
            }
            else
                not_tasks = 0;
        }
        else
        {
            for(int i = 0; i < TaskfromBD.counter_task; i++)
            {
                if (TaskfromBD.save_username[i] == username.text)
                    valid_username = 1;
            }
            if(valid_username == 0)
            {
                not_username = 1;
            }
            else
            {
                not_username = 0;
            }
            int nr_tasks_username = 0;
            for(int i = 0; i < TaskfromBD.counter_task; i++)
            {
                if(TaskfromBD.save_username[i] == username.text)
                {
                    nr_tasks_username++;
                }
            }

            if (int.Parse(number_task_of_view.text) > nr_tasks_username)
            {
                not_task_for_username = 1;
            }
            else
                not_task_for_username = 0;
        }

    }

    public void verify_inputs()
    {
        check_inputs();
        message.text = "     List of Tasks";
        if (not_tasks == 0 && not_username == 0 && not_task_for_username == 0)
        {
            UpdateItems();
        }
        else if(not_tasks == 1 && not_username == 1)
        {
            message.text = "     Incorect inputs";
            not_tasks = 0;
            not_username = 0;
        }
        else if(not_tasks == 1)
        {
            message.text = "    Incorect nr of task";
            not_tasks = 0;
        }
        else if (not_username == 1)
        {
            message.text = "Not tasks assigned/Incorect username";
            not_username = 0;
        }
        else if(not_task_for_username == 1)
        {
            message.text = "Too many tasks for " + username.text;
            not_task_for_username = 0;
        }
    }
    
    public void UpdateItems()
    {
            TaskfromBD.onStart = 1;
            int newCount;
            int.TryParse(countText.text, out newCount);
            StartCoroutine(FetchItemModels(newCount, results => OnReceivedNewModels(results)));
    }

    private void OnReceivedNewModels(ExampleItemModel[] models)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        views.Clear();

        int i = 0;
        foreach(var model in models)
        {
            GameObject instance = Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializeItemView(instance, model);
            views.Add(view);
            ++i;

            instance.transform.Find("take").GetComponent<Button>().onClick.AddListener(() =>
            {
                instance.transform.Find("status").GetComponent<Text>().text = "InProgress";
                StartCoroutine(TaskfromBD.UpdateStatusTask("InProgress"));
            });
        }
    }

    ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model)
    {
        ExampleItemView view = new ExampleItemView(viewGameObject.transform);

            view.title.text = model.title;
            view.deadline.text = model.deadline;
            view.username.text = model.username;
            view.status.text = model.status;
     
        return view;
    }

    IEnumerator FetchItemModels(int count, System.Action<ExampleItemModel[]> onDone)
    {
        yield return new WaitForSeconds(0.1f);
        var result = new ExampleItemModel[count];
        var result1 = new ExampleItemModel[count];
      
        if (username.text == "")
        {
          
                int i;
                for (i = 0; i < count; i++)
                {
                    result[i] = new ExampleItemModel();

                    result[i].title = TaskfromBD.save_title[i];
                    result[i].deadline = TaskfromBD.save_deadline[i];
                    result[i].username = TaskfromBD.save_username[i];
                    result[i].status = TaskfromBD.save_status[i];
               }
        }
        else
        {
            
                int nr_task_one_user = 0;
                int k = 0;
                while (nr_task_one_user < count)
                {
                    if (username.text == TaskfromBD.save_username[k])
                    {
                        result1[nr_task_one_user] = new ExampleItemModel();

                        result1[nr_task_one_user].title = TaskfromBD.save_title[k];
                        result1[nr_task_one_user].deadline = TaskfromBD.save_deadline[k];
                        result1[nr_task_one_user].username = TaskfromBD.save_username[k];
                        result1[nr_task_one_user].status = TaskfromBD.save_status[k];
                        nr_task_one_user++;
                    }
                    k++;
                }
        }
        if (username.text == "")
        {
            onDone(result);

        }
        else
        {
            onDone(result1);
        }      
    }

    public class ExampleItemView
    {
        public Text title;
        public Text deadline;
        public Text username;
        public Text status;

        public ExampleItemView(Transform rootView)
        {
            title = rootView.Find("title").GetComponent<Text>();
            deadline = rootView.Find("deadline").GetComponent<Text>();
            username = rootView.Find("username").GetComponent<Text>();
            status = rootView.Find("status").GetComponent<Text>();
        }


    }

    public class ExampleItemModel
    {
        public string title;
        public string deadline;
        public string username;
        public string status;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToNewActivity()
    {
        SceneManager.LoadScene(5);
    }

}
