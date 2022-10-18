using UnityEngine;

public class Parallax : MonoBehaviour
{
		private float _lenght;
		private float _startPos;
		private float _time = 0f;
		[SerializeField] private float _parallex;

		void Start()
		{
				_lenght = GetComponent<SpriteRenderer>().bounds.size.x;
				_startPos = transform.position.x;
		}

		void Update()
		{
				_time += Time.deltaTime;
				float distance = _time * _parallex;

				transform.position = new Vector3(_startPos - distance, transform.position.y, transform.position.z);

				if (distance > _startPos + _lenght)
				{
						_time = 0f;
				}
		}
}
