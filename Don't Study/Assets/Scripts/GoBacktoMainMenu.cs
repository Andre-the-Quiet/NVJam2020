using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBacktoMainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public void GoBack()
    {
        StartCoroutine(LoadScene());

    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    
}
