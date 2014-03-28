using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Enemie;
	private GameObject tempEnemie;
	// Use this for initialization
	void Start () {
		tempEnemie = Instantiate(Enemie, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		//Check if the Enemy is Dead
		if (tempEnemie == null) 
		{
			tempEnemie = Instantiate(Enemie, transform.position, transform.rotation) as GameObject;
		}
	
	}
}
