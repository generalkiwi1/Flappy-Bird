using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var position = transform.position;
		Debug.Log("Ma position initiale est : " + position);
	}

	private TranslateMover translateMover;
	void Awake()
	{
		translateMover = GetComponent<TranslateMover>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/* Exemple de Translation à chaque frame
		var translation = Time.deltaTime * Vector3.right;
		transform.Translate(translation);
		*/
		if (Input.GetKeyDown(KeyCode.W))
			translateMover.Move(Vector3.up);
		if (Input.GetKeyDown(KeyCode.A))
			translateMover.Move(Vector3.left);
		if (Input.GetKeyDown(KeyCode.S))
			translateMover.Move(Vector3.down);
		if (Input.GetKeyDown(KeyCode.D))
			translateMover.Move(Vector3.right);

	}
}
