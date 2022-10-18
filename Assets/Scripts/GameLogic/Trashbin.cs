using UnityEngine;

public class Trashbin : MonoBehaviour
{
		// Destroy any Obstacle type object when collision occures
		void OnTriggerEnter2D(Collider2D collider2D)
		{
				DestroyAGameObjectFromCollider2D(collider2D);
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
				DestroyAGameObjectFromCollider2D(collision.collider);
		}

		void DestroyAGameObjectFromCollider2D(Collider2D collider2D)
		{
				GameObject gameObject = collider2D.transform.parent.gameObject;
				Destroy(gameObject);
		}
}
