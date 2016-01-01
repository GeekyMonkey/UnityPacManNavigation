using UnityEngine;
using System.Collections;
using Pathfinding;

public class GhostAStar : MonoBehaviour {

	Seeker seeker;
	CharacterController cc;
	public GameObject targetObject;
	public int pathIndex = -1;
	private Path path;
	public float Speed = 1;
	float NodeDistance = .1f;
	public float WakeSeconds = 1f;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		cc = GetComponent<CharacterController>();

		Invoke("FindPath", WakeSeconds);
	}

	void FindPath()
	{
		AstarPath.active.Scan();
		seeker.StartPath(transform.position, targetObject.transform.position, OnPath);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (pathIndex > -1 && path != null && pathIndex < path.vectorPath.Count)
		{
			Vector3 dir;
			Vector3 targetPoint;

			targetPoint = path.vectorPath[pathIndex];
			dir = (targetPoint - transform.position);
			cc.SimpleMove(Vector3.Normalize(dir) * Speed);

			if (dir.magnitude < NodeDistance)
			{
				// Debug.Log("Got to point " + pathIndex);
				pathIndex++;
				FindPath();
			}
		}
	}

	public void OnPath(Path p)
	{
		path = p;

		for (var i = 0; i < path.vectorPath.Count; i++)
		{
			pathIndex = i;
			var targetPoint = path.vectorPath[i];
			var dir = (targetPoint - transform.position);
			if (dir.magnitude > NodeDistance)
			{
				break;
			}
		}
		// Debug.Log("Reset path index " + pathIndex);

	}
}
