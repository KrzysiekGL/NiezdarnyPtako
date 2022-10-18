using System;
using UnityEngine;

public class Level : MonoBehaviour
{
		[SerializeReference]
		private Obstacle obstacle;

		private float _timeElapsed = 0f;
		private float _interval = 0f;

		private bool _isGameRunning = false;

		void Start()
		{
				// Subscribe to the Ptako's GameReset event
				GameObject.FindObjectOfType<Ptako>().GameReset += RestartTheLevel;
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
								_interval = UnityEngine.Random.Range(3f, 4f);
								Obstacle obstacleClone = Instantiate<Obstacle>(obstacle, transform.position, Quaternion.identity, transform);
						}
				}
		}

		void RestartTheLevel(object sender, EventArgs e)
		{
				foreach (Transform child in transform)
						Destroy(child.gameObject);
				_interval = 0f;
				_isGameRunning = false;
		}
}
