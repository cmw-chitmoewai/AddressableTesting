using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class AddressableScript : MonoBehaviour
{


	//GameObject myGameObject;
	public AssetReference localNo;

	private List<IResourceLocation> remoteNums;
	public AssetLabelReference number;


	private List<IResourceLocation> remoteUI;
	public AssetLabelReference UiPrefab;

    // Start is called before the first frame update
    void Start()
    {
		DisplayNos();

		Addressables.LoadResourceLocationsAsync(number.labelString).Completed += LoactionLoaded;

		Addressables.LoadResourceLocationsAsync(UiPrefab.labelString).Completed += UiLocationLoaded;

		//Debug.Log(UiPrefab.ToString());

		//Addressables.LoadAssetsAsync<GameObject>(new string[] { UiPrefab.ToString() }, OnSetUpDone, Addressables.MergeMode.Union).Completed += OnLoadDone;

	}

	private void OnSetUpDone(GameObject obj)
	{

	}

	private void OnLoadDone(AsyncOperationHandle<IList<GameObject>> obj)
	{
		List<GameObject> objs = new List<GameObject>(obj.Result);

		foreach (GameObject item in objs)
		{
			Addressables.InstantiateAsync(item, Vector3.zero, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
	public void DisplayNos()
	{
		localNo.InstantiateAsync(Vector3.zero, Quaternion.identity);
		Debug.Log(number.labelString);
	}

	private void LoactionLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
	{
		remoteNums = new List<IResourceLocation>(obj.Result);

		if(remoteNums.Count > 0)
		{
			Debug.Log("Load Asset Successful."); 
		}

		//Addressables.InstantiateAsync(remoteNums[0], Vector3.zero, Quaternion.identity);

		StartCoroutine(SpawnNumbers());
	}

	private void UiLocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
	{
		remoteUI = new List<IResourceLocation>(obj.Result);

		foreach (var item in remoteUI)
		{
			Addressables.InstantiateAsync(item, Vector3.zero, Quaternion.identity);
		}


		Debug.Log("Instantiate success");
	}

	private IEnumerator SpawnNumbers()
	{
		yield return new WaitForSeconds(1f);
		float xOff = -4.0f;

		for(int i = 0; i< remoteNums.Count; i++)
		{
			Vector3 spawnPosition = new Vector3(xOff, 3, 0);

			Addressables.InstantiateAsync(remoteNums[i], spawnPosition, Quaternion.identity);

			xOff = xOff + 3.5f;

			yield return new WaitForSeconds(1f);
		}
	}

}
