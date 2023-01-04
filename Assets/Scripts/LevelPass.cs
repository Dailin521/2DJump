using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPass : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelPassText;
    void Start()
    {
        if (levelPassText == null)
            levelPassText = GameObject.Find("Canvas").transform.Find("levelPassText").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var currentScene = SceneManager.GetActiveScene();
        levelPassText.SetActive(true);
        StartCoroutine(Dely(2, () =>
        {
            SceneManager.LoadScene(currentScene.name);
        }));
    }
    IEnumerator Dely(float seconds, Action onFinish)
    {
        yield return new WaitForSeconds(seconds);
        onFinish?.Invoke();
    }
}
