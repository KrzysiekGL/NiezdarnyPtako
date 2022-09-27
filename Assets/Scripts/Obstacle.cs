using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
		[SerializeReference]
		private GameObject _top;

		[SerializeReference]
		private GameObject _between;

		[SerializeReference]
		private GameObject _bottom;

		// Start is called before the first frame update
		void Start()
		{
				float yScale = Random.Range(2f, 6f);
				_top.transform.localPosition += new Vector3(0f, yScale/2f-1f, 0f);
				_between.transform.localScale = new Vector3(1f, yScale, 1f);
				_bottom.transform.localPosition += new Vector3(0f, -yScale/2f+1f, 0f);

				float yShift = Random.Range(-2f, 2f);
				_top.transform.localPosition += new Vector3(0f, yShift, 0f);
				_between.transform.localPosition += new Vector3(0f, yShift, 0f);
				_bottom.transform.localPosition += new Vector3(0f, yShift, 0f);

				float speed = 1f;
				GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);
		}

		// Update is called once per frame
		void Update()
		{
		}
}
