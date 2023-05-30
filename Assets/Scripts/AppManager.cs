using UnityEngine;

public class AppManager : MonoBehaviour
{
    public AppConfig appConfig;

    public void Go()
    {
        int contentLength = appConfig.content.Length;
        Debug.Log(contentLength);
        var content = Resources.Load(appConfig.content[0].textContent);
        Instantiate(content);
        Debug.Log(appConfig.content[0].textContent);
        Debug.Log(appConfig.content[1].textContent);
        //if (startId == 0)
        //{
        //    for (int i = startId; i < startId + 4; i++)
        //    {
        //        var content = Resources.Load<GameObject>(appConfig.content[startId].textContent);
        //        Instantiate(content);
        //    }
        //}
        //if ((startId >= 2) || (startId <= contentLength - 2))
        //{
        //    for (int i = startId - 2; i < startId + 2; i++)
        //    {
        //        var content = Resources.Load<GameObject>(appConfig.content[startId].textContent);
        //        Instantiate(content);
        //    }
        //}
        //else
        //{
        //    for (int i = startId - 1; i < contentLength - 1; i++)
        //    {
        //        var content = Resources.Load<GameObject>(appConfig.content[startId].textContent);
        //        Instantiate(content);
        //    }
        //}
    }
}

