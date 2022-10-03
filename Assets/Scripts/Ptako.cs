using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptako : MonoBehaviour
{
		[SerializeField]
		private LayerMask _playerMask;

		private Rigidbody2D _rigidbody2D;

		private float _jumpTrhust = 5f;
		private float _rotationSmoothParameter = 15f;

		private bool _isJumpPressed;
		private bool _isGrounded;

		private bool _gameOver = false;

		void Start()
		{
				// Ignore collision with obstacle's "Obstacle Layer Mask" parts
				Physics2D.IgnoreLayerCollision(7, 6, true);

				_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
				if (_gameOver)
				{
						return;
				}

				if (Input.GetKeyDown(KeyCode.Space))
				{
						_isJumpPressed = true;
				}
		}

		void FixedUpdate()
		{
				if (_isJumpPressed && !_gameOver)
				{
						_rigidbody2D.AddForce(Vector2.up * _jumpTrhust, ForceMode2D.Impulse);
						_isJumpPressed = false;
				}

				float verticalVelocity = _rigidbody2D.velocity.y;
				// Rising - rotate to the right about the Z axis
				if(verticalVelocity > 0f)
				{
						if (transform.localRotation.z < 45f)
						{
								float smoothRotate = 45f * Time.deltaTime * _rotationSmoothParameter;
								transform.localRotation = Quaternion.Euler(0, 0, smoothRotate);
						}
				}
				// Upright
				else if (verticalVelocity == 0f)
				{
						transform.localRotation = Quaternion.identity;
				}
				// Descanding - rotate to the left about the Z axis
				else
				{
						if (transform.localRotation.z > -45f)
						{
								float smoothRotate = -45f * Time.deltaTime * _rotationSmoothParameter;
								transform.localRotation = Quaternion.Euler(0, 0, smoothRotate);
						}
				}
		}

		void OnCollisionEnter2D(Collision2D col)
		{
				_gameOver = true;
				_rigidbody2D.AddForce(transform.up * 0.4f * _jumpTrhust, ForceMode2D.Impulse);
				_rigidbody2D.AddForce(transform.right * -0.2f * _jumpTrhust, ForceMode2D.Impulse);
		}
}
