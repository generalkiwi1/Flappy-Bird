using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
	[Header("Parts")] [SerializeField] private GameObject pipeUp;
	[SerializeField] private GameObject pipeDown;
	[Header("Position")] [SerializeField] private float minDistance = 1;
	[SerializeField] private float maxDistance = 3;
	[SerializeField] private float minHeight = -1;
	[SerializeField] private float maxHeight = 1;

	private BirdSensor birdSensor;

	private void Awake()
	{
		RandomizePipes();

		birdSensor = transform.root.GetComponentInChildren<BirdSensor>();
	}

	private void OnEnable()
	{
		birdSensor.OnBirdSensed += NotifyPipePassed;
	}

	private void OnDisable()
	{
		birdSensor.OnBirdSensed -= NotifyPipePassed;
	}

	private void NotifyPipePassed()
	{
		Debug.Log("Pipe passed!");
	}

	private void RandomizePipes()
	{
		RandomizePipePositions();
		RandomizePipeHeights();
	}

	private void RandomizePipePositions()
	{
		//N'oublions pas que le sprite est au centre de l'objet.
		var halfPipeHeight = pipeUp.GetComponent<SpriteRenderer>().size.y / 2f;

		//Une distance est choisie aléatoirement. Elle est divisée par 2, car l'un des tuyaux 
		//sera placé en haut de l'axe des X et l'autre en bas.
		var halfDistance = Random.Range(minDistance, maxDistance) / 2f;

		//Ceci est la distance avec l'axe.
		var pipePosition = Vector3.up * halfPipeHeight + Vector3.up * halfDistance;

		//L'objet parent décide de la hauteur de l'obstacle (voir RandomizePipeHeights).
		//Les objets enfants décident de l'espacement.
		pipeUp.transform.localPosition = pipePosition;
		pipeDown.transform.localPosition = -pipePosition;
	}

	private void RandomizePipeHeights()
	{
		var height = Random.Range(minHeight, maxHeight);
		transform.root.Translate(Vector3.up * height);
	}
}
