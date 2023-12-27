using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            if (instance == null) { instance = new GameObject("SceneManager").AddComponent<SceneLoader>(); }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded -= OnGameScene;
        SceneManager.sceneLoaded += OnGameScene;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnGameScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            GameManager.Instance.isPlaying = true;
            GameManager.Instance.Init();
        }
    }

}