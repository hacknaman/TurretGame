using UnityEngine;
using System.Collections;

public class TurretPlay : MonoBehaviour {

	// Use this for initialization

	private float spacekeytimer; // Timer for spaceKey
	public float range;

	void Start () {

		spacekeytimer = 0.0f;
		range = 5.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (transform.position, transform.up*range, Color.red, 0.2f);

		//Angle to rotate
		float ZAngle = -Mathf.Atan2( -Screen.width/2 + Input.mousePosition.x + transform.position.x, -Screen.height/2 +Input.mousePosition.y + transform.position.y - Screen.height/11.0f) * (180 / Mathf.PI);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ZAngle);

		// Timer condition for SpaceKey
		if(spacekeytimer < 0.2f ) 
			spacekeytimer += Time.deltaTime ;


		RaycastHit[] hits;
		hits = Physics.SphereCastAll (transform.position, range + 2.0f, transform.forward, range + 2.0f);

		foreach(RaycastHit hit in hits)
		{
			// if Enemy exits the line of sight change it's color to yellow
			if (hit.transform.gameObject.tag == "Enemy")	hit.transform.gameObject.renderer.material.color = Color.yellow;

			RaycastHit hitball;

			if (Physics.Raycast (transform.position, transform.up, out hitball, range)) {
				// When Enemy is in the line of sight
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
