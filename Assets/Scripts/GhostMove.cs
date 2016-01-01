using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {

	private NavMeshAgent agent;
	public Vector3 target;
	public GameObject Follow;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(target);
		agent.updateRotation = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		agent.SetDestination(Follow.transform.position);
	}
}
