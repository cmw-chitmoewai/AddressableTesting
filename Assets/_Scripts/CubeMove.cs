using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

	public void Update()
	{
		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(moveX * Time.deltaTime * 5, moveY * Time.deltaTime * 5, 0));
	}
}
