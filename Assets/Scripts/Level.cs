using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
		[SerializeReference]
		private GameObject obstacle;

		private float _timeElapsed = 0f;
		private float _interval = 3f;

		private Transform[] _obstaclesLocations;

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
        // Generate obstacles after the interval
        _timeElapsed += Time.deltaTime;
				if (_timeElapsed >= _interval)
				{
						_timeElapsed = 0f;
						_interval = Random.Range(3f, 4f);
						Instantiate(obstacle, gameObject.transform.position , Quaternion.identity);
				}
		}
}
