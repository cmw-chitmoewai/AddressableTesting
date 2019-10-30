using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableScript : MonoBehaviour
{
	//GameObject myGameObject;
	public AssetReference localNo;

	private List<IResourceLocation> remoteNums;
	public AssetLabelReference number;


    // Start is called before the first frame update
    void Start()
    {
		DisplayNos();

		Addressables.LoadResourceLocationsAsync(number.labelString).Completed += LoactionLoaded;


		//Addressables.LoadAssetAsync<GameObject>("No2").Completed += OnLoadDone;

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	
	private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
	{
			// In a production environment, you should add exception handling to catch scenarios such as a null result.
			//myGameObject = obj.Result;

			//Instantiate(myGameObject);

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
