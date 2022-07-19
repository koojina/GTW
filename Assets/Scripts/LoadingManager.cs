using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public string sceneName = "System";
    private AsyncOperation operation;

    public static LoadingManager instance;

    public float timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(LoadCoroutine());
    }

 void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator LoadCoroutine()
    {
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        //  operation.allowSceneActivation = false;


        while (!operation.isDone)
        {
            yield return null;

            if (operation.progress >= 0.9f)
            {
                if(timer>=6.0f)
                {
                    operation.allowSceneActivation = true;
                }
            }
        }

      //  gameObject.SetActive(false);
    }

}