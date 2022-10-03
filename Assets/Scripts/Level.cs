using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
		[SerializeReference]
		private Obstacle obstacle;

		private float _timeElapsed = 0f;
		private float _interval = 3f;

		private Transform _levelTransform;

		private bool _isGameRunning = false;

		void Start()
		{
				_levelTransform = GetComponent<Transform>();
		}

		void Update()
		{
			// Press space to start the game
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_isGameRunning = true;
			}

			if (_isGameRunning)
			{
				// Generate obstacles after the interval
				_timeElapsed += Time.deltaTime;
				if (_timeElapsed >= _interval)
				{
					_timeElapsed = 0f;
					_interval = Random.Range(3f, 4f);
					Obstacle obstacleClone = Instantiate<Obstacle>(obstacle, _levelTransform.position, Quaternion.identity, _levelTransform.parent);
					obstacleClone.transform.parent = _levelTransform;
				}
			}
		}
}
