using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour
{
		// Destroy any Obstacle type object when collision occures
		void OnTriggerEnter2D(Collider2D collider2D)
		{
				GameObject gameObject = collider2D.transform.parent.gameObject;
				if (gameObject.layer == 6)
				{
						Destroy(gameObject);
				}
		}
}
