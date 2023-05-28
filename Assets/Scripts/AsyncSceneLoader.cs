using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AsyncSceneLoader : MonoBehaviour
{
    private AsyncOperation level;

    public void Start()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    public void LoadScene()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    public void OpenScene()
    {
        level.allowSceneActivation = true;
    } 

    private IEnumerator LoadLevelCoroutine()
    {
        level = SceneManager.LoadSceneAsync(1);

        while (!level.isDone)
        {
            yield return new WaitForSeconds(3f);
        }
        
        Debug.Log("Scene was loaded");
    }  
}
