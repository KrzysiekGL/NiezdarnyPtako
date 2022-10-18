using System;
using UnityEngine;

public class Ptako : MonoBehaviour
{
		private Rigidbody2D _rigidbody2D;

		private const float _jumpTrhust = 5f;
		private const float _rotationSmoothParameter = 15f;

		private bool _isJumpPressed;
		private bool _isGrounded;

		private bool _isGameOver = false;

		// Publisher Subscriber (pub/sub) system
		// Inform all interested participatns, that the point was scored
		public event EventHandler PointScored = delegate { };
		// ---||---, that the game ended
		public event EventHandler GameEnded = delegate { };
		// ---||---, that the game was reset
		public event EventHandler GameReset = delegate { };

		void Start()
		{
				// Get the rigidbody2D component for this gameObject and exclude it from physics calculations
				_rigidbody2D = GetComponent<Rigidbody2D>();
				_rigidbody2D.isKinematic = true;

				// Subscribe to both GameEnded and GameReset for internal use
				GameEnded += GameOver;
				GameReset += RestartPtako;
		}

		void Update()
		{
				// Restart the game
				if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
				{
						GameReset.Invoke(this, new EventArgs());
				}

				// Jump
				if (Input.GetKeyDown(KeyCode.Space) && !_isGameOver)
				{
						_isJumpPressed = true;
				}
		}

		void FixedUpdate()
		{
				// Jump only if the game is not over yet
				if (_isJumpPressed && !_isGameOver)
				{
						// If Ptako is still excluded from physics calculations, include it to them
						if (_rigidbody2D.isKinematic)
								_rigidbody2D.isKinematic = false;
						_rigidbody2D.AddForce(Vector2.up * _jumpTrhust, ForceMode2D.Impulse);
						_isJumpPressed = false;
				}

				float verticalVelocity = _rigidbody2D.velocity.y;
				// Rising - rotate to the right about the Z axis
				if (verticalVelocity > 0f)
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
				_rigidbody2D.AddForce(transform.up * 0.4f * _jumpTrhust, ForceMode2D.Impulse);
				_rigidbody2D.AddForce(transform.right * -0.2f * _jumpTrhust, ForceMode2D.Impulse);
				GameEnded.Invoke(this, new EventArgs());
		}

		void OnTriggerExit2D(Collider2D other)
		{
				if (!_isGameOver && other.name == "Between")
						PointScored.Invoke(this, new EventArgs());
		}

		void GameOver(object sender, EventArgs e)
		{
				_isGameOver = true;
		}

		void RestartPtako(object sender, EventArgs e)
		{
				// Reset all parameters and exclude from physics calculations
				transform.localRotation = Quaternion.identity;
				_rigidbody2D.isKinematic = true;
				_rigidbody2D.velocity = new Vector2(0, 0);
				transform.position = new Vector3(0, 0, 0);
				_isGameOver = false;
		}
}
