using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoMultipleManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI imageTrackedText;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    [SerializeField]
    private MapUserWay mapUserWay;
	
	[SerializeField] AssetReference classData;
	[SerializeField] AssetReference pictureData;

    private ARTrackedImageManager trackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    	
	private static GameObject activeObj;
	
    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectsToPlace)
        {
            var newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
            newARObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private static bool IsInList(string name, List<ARTrackedImage> imgs)
    {
        foreach (var img in imgs)
        {
            if (img.referenceImage.name == name &&
                img.trackingState == TrackingState.Tracking)
            {
                return true;
            }
        }

        return false;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
		
        foreach (var arObject in arObjects)
        {
            if (IsInList(arObject.Key, eventArgs.added) ||
                IsInList(arObject.Key, eventArgs.updated))
            {
                continue;
            }
			
            arObject.Value.SetActive(false);
			
			if(arObject.Key == activeObj?.name)
			{
				activeObj = null;
			}
        }

			
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage, true);
        }
		
		if(activeObj != null)
		{
			return;
		}

        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage, false);
        }
    }

	private void UpdateARImage(ARTrackedImage trackedImage, bool isUpdated)
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
			if(activeObj==null)
			{
				imageTrackedText.text = trackedImage.referenceImage.name;
				mapUserWay.ShowLastPosition(imageTrackedText.text);
				AppManager appManager;
				if (imageTrackedText.text.StartsWith("it"))
				{
					appManager = arObjects[imageTrackedText.text].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<AppManager>();
				}
				else
				{
					appManager = arObjects[imageTrackedText.text].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<AppManager>();
				}
				
				LoadResources(imageTrackedText.text, appManager);
				
				arObjects[trackedImage.referenceImage.name].SetActive(true);
				activeObj = arObjects[trackedImage.referenceImage.name];
			}
            
			if(arObjects[trackedImage.referenceImage.name].activeSelf)
			{
				AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
			}
        }
    }
	
	private async void LoadResources(string className, AppManager appManager)
    {
		AsyncOperationHandle<AppConfig> handle = (className.StartsWith("it")?classData:pictureData).LoadAssetAsync<AppConfig>();
		
        await handle.Task;
		
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            AppConfig data = handle.Result;
            
			appManager.LoadResources(className, data);
			
            Addressables.Release(handle);
			
        }
    }
	

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.transform.position = newPosition;
            goARObject.transform.localScale = scaleFactor;
        }
    }
}