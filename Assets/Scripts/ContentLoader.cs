using System.Collections;
using UnityEngine;

public class ContentLoader 
{
   public IEnumerator LoadtObjectAsync(string path)
    {
        var operation = Resources.LoadAsync<GameObject>(path);
        
        while (!operation.isDone)
        {
            yield return new WaitForSeconds(2);
        }
    }
}
