using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    KeyCode pauseButton;
    [SerializeField]
    GameObject pauseObject;
    public Animator anim;
    GameObject gameOverObj;

    private void Start()
    {
        pauseObject.SetActive(false);
        Time.timeScale = 1;
        gameOverObj = GetComponent<GameOver>().gameOverObject;
        gameOverObj.SetActive(false);
    }
    private void Update()
    {
        PauseManager(pauseButton);
    }

    void PauseManager(KeyCode key)
    {
        if (Input.GetKeyDown(key) && Time.timeScale != 0)
        {
            anim.SetBool("onExit", false);
            Time.timeScale = 0;
            pauseObject.SetActive(!pauseObject.activeSelf);
        }
        else if (Input.GetKeyDown(key) && Time.timeScale == 0)
        {
            StartCoroutine("onExitAnimation");
        }
    }

    IEnumerator onExitAnimation()
    {
        anim.SetBool("onExit", true);
        yield return new WaitForSecondsRealtime(0.85f);
            Time.timeScale = 1;
            pauseObject.SetActive(!pauseObject.activeSelf);
    }
    public void Resume()
    {
        StartCoroutine("onExitAnimation");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void HighScores()
    {
        //cos...
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
