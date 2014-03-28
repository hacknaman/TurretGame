using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private float dirx;
	private float diry;

	// Use this for initialization
	void Start () {

		dirx = Random.Range(-10, 10);
		diry = Random.Range(-10, 10);

		rigidbody.velocity = new Vector3( dirx  , diry , 0);

	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "WallHor") 
			diry *= -1;

		if (col.gameObject.tag == "WallVer")
			dirx *= -1;

		rigidbody.velocity = new Vector3( dirx  , diry , 0);

	}
}
