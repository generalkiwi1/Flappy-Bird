using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	[SerializeField] private KeyCode flapKey = KeyCode.Space;

	private BirdPhysics birdPhysics;
	private CollisionSensor collisionSensor;

	private void Awake()
	{
		var root = transform.root;

		birdPhysics = root.GetComponentInChildren<BirdPhysics>();
		collisionSensor = root.GetComponentInChildren<CollisionSensor>();
	}

	private void OnEnable()
	{
		//Utilisez l'opérateur += pour abonner une fonction à l'événement.
		collisionSensor.OnCollision += Die;
	}

	private void Update()
	{
		if (Input.GetKeyDown(flapKey))
			birdPhysics.Flap();
		
	}

	private void OnDisable()
	{
		//Avec l'opérateur -=, c'est l'inverse.
		collisionSensor.OnCollision -= Die;
	}

	private void Die()
	{
		Hide();
	}

	private void Hide()
	{
		transform.root.gameObject.SetActive(false);
	}
}