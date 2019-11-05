using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAudio : MonoBehaviour
{
	public AudioSource audio;

	public AssetReference localNo;


	public void Start()
	{
		DisplayNos();
	}
	public void DisplayNos()
	{
		//localNo.InstantiateAsync(Vector3.zero, Quaternion.identity);
		var haha = localNo.LoadAssetAsync<AudioClip>();

		localNo.InstantiateAsync(Vector3.zero, Quaternion.identity);

		//audio.clip = haha.Result;


		Debug.Log("loadSuccess");
	}
}
