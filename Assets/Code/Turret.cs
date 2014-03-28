using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private float spacekeytimer; // Timer for spaceKey
	public float range;

	// Use this for initialization
	void Start () {
		spacekeytimer = 0.0f;
		range = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (transform.position, transform.up*range, Color.blue, 0.02f);

		if(spacekeytimer < 0.2f ) spacekeytimer += Time.deltaTime ;

		RaycastHit[] hits;
		hits = Physics.SphereCastAll (transform.position, range + 2.0f, transform.forward, range + 2.0f);

		foreach(RaycastHit hit in hits)
		{
			float ZAngle = -Mathf.Atan2(hit.transform.position.x - transform.position.x, hit.transform.position.y - transform.position.y) * (180 / Mathf.PI);

			if(ZAngle < 0.0f )
				ZAngle += 360.0f; 

			// Red Turrent constraint
			if(name == "TurrentR")
				ZAngle = Mathf.Clamp(ZAngle, 90, 270);

			float ZAngleNew = transform.eulerAngles.z;

			if(ZAngleNew < 0.0f )
				ZAngleNew += 360.0f; 

			// Smoothly rotating towards the enemy
			if(ZAngleNew <  ZAngle)
				ZAngleNew += Time.deltaTime * 100.0f;
			else
				ZAngleNew -= Time.deltaTime * 100.0f;;

			if(ZAngleNew > 180.0f )
				ZAngleNew -= 360.0f; 
		
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ZAngleNew);

			// if Enemy exits the line of sight change it's color to yellow
			if (hit.transform.gameObject.tag == "Enemy")	hit.transform.gameObject.renderer.material.color = Color.yellow;
			
			RaycastHit hitball;
			
			if (Physics.Raycast (transform.position, transform.up, out hitball, range)) {
				if (hitball.transform.gameObject.tag == "Enemy") hitball.transform.gameObject.renderer.material.color = Color.red;
				
				if (Input.GetKey (KeyCode.Space) && spacekeytimer > 0.2f) {
					
					spacekeytimer = 0.0f;
					if (hitball.transform.gameObject.tag == "Enemy")
						Destroy (hitball.transform.gameObject);
				}
			}

		}


	}
}
