using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisonSensorEventHandler();

public class CollisionSensor : MonoBehaviour
{
	public event CollisonSensorEventHandler OnCollision;

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Collision détectée!");
		NotifyCollisionSensed();
	}

	private void NotifyCollisionSensed()
	{
		if (OnCollision != null) OnCollision();
	}
}