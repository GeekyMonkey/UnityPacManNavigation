using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour {

	public float Speed = 0.05f;
	private Animator anim;
	public GameObject Sprite;

	// Use this for initialization
	void Start () {
		anim = Sprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		float yDir = 0;
		float xDir = 0;
		float rot = -1;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			yDir = 1;
			rot = 90;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			yDir = -1;
			rot = -90;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			xDir = 1;
			rot = 180;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			xDir = -1;
			rot = 0;
		}

		this.transform.Translate(xDir * Speed, 0, yDir * Speed, Space.World);
		if (rot != -1)
		{
			this.transform.rotation = Quaternion.Euler(90, rot, 0);
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log("Collision = " + coll.gameObject.tag);

		if (coll.gameObject.tag == "Ghost")
		{
			anim.SetTrigger("Death");
			Invoke("AfterDeath", 2.1f);
		}
	}

	public void AfterDeath()
	{
		this.gameObject.SetActive(false);
	}
}
