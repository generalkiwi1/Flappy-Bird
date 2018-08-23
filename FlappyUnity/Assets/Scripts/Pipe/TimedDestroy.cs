using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour {

	[SerializeField] private float destroyDelayInSeconds = 12f;

	private void OnEnable()
	{
		StartCoroutine(DestroyPrefabsRoutine());
	}

	private void OnDisable()
	{
		//Cette fonction arrête les coroutines.
		StopAllCoroutines();
	}

	private IEnumerator DestroyPrefabsRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(destroyDelayInSeconds);
			Destroy(transform.root.gameObject);
		}
	}


}
