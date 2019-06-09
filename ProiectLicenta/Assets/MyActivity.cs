using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MyActivity : MonoBehaviour
{
    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    List<ExampleItemView> views = new List<ExampleItemView>();

    public void UpdateItems()
    {
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
        
        for(int i = 0; i< count; i++)
        {
            result[i] = new ExampleItemModel();

            result[i].title = TaskfromBD.save_title[i];
            result[i].deadline = TaskfromBD.save_deadline[i];
            result[i].username = TaskfromBD.save_username[i];
            result[i].status = "Assigned";
        }

        onDone(result);
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
