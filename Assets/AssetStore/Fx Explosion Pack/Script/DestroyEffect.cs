using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {


	void Start() {
		Destroy(gameObject, 1.0f);
	}
	
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	
	}
}
