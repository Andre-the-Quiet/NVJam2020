using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Animator transitionAnim;
    public Animator UI;
    public string sceneName;
    public void StartGame()
    {
        StartCoroutine(LoadScene());
        
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        UI.SetTrigger("Start");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
