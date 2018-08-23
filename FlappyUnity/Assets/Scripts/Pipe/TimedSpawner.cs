using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

	[SerializeField] private GameObject prefab;
	[SerializeField] private float spawnDelayInSeconds = 3f;

	private void OnEnable()
	{
		StartCoroutine(SampleCoroutine());
	}
	private void OnDisable()
	{
		//Cette fonction arrête les coroutines.
		StopAllCoroutines();
	}

	private IEnumerator SampleCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnDelayInSeconds);
			SpawnPipe();
		}
	}

	private void SpawnPipe()
	{
		Instantiate(prefab, transform.position, Quaternion.identity);


	}

}
