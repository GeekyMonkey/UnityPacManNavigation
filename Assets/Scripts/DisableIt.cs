using UnityEngine;
using System.Collections;

public class DisableIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Destroy(this.gameObject);

		Renderer[] rs = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in rs) {
			r.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
