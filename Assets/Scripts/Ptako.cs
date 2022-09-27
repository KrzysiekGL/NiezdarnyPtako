using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptako : MonoBehaviour
{
		[SerializeField]
		private LayerMask _playerMask;

		private Rigidbody2D _rigidbody2D;

		private float _jumpTrhust = 5f;

		private bool _isJumpPressed;
		private bool _isGrounded;

		void Start()
		{
				// Ignore collision with obstacle's "Obstacle Layer Mask" parts
				Physics2D.IgnoreLayerCollision(7, 6, true);

				_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		}

		void Update()
		{
				if (Input.GetKeyDown(KeyCode.Space))
				{
						_isJumpPressed = true;
				}
		}

		void FixedUpdate()
		{
				if (_isJumpPressed)
				{
						_rigidbody2D.AddForce(transform.up * _jumpTrhust, ForceMode2D.Impulse);
						_isJumpPressed = false;
				}
		}
}
