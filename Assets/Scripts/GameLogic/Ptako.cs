using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptako : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;

	private float _jumpTrhust = 5f;
	private float _rotationSmoothParameter = 15f;

	private bool _isJumpPressed;
	private bool _isGrounded;

	private bool _gameOver = false;

	void Start() {
		// Get the rigidbody2D component for this gameObject
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update() {
		// If the game is over, just skip any updates
		if (_gameOver) {
			return;
		}

		// Jump
		if (Input.GetKeyDown(KeyCode.Space)) {
			_isJumpPressed = true;
		}
	}

	void FixedUpdate() {
		// Jump only if the game is not over yet
		if (_isJumpPressed && !_gameOver) {
			_rigidbody2D.AddForce(Vector2.up * _jumpTrhust, ForceMode2D.Impulse);
			_isJumpPressed = false;
		}

		float verticalVelocity = _rigidbody2D.velocity.y;
		// Rising - rotate to the right about the Z axis
		if(verticalVelocity > 0f) {
			if (transform.localRotation.z < 45f) {
				float smoothRotate = 45f * Time.deltaTime * _rotationSmoothParameter;
				transform.localRotation = Quaternion.Euler(0, 0, smoothRotate);
			}
		}
		// Upright
		else if (verticalVelocity == 0f) {
			transform.localRotation = Quaternion.identity;
		}
		// Descanding - rotate to the left about the Z axis
		else {
			if (transform.localRotation.z > -45f) {
				float smoothRotate = -45f * Time.deltaTime * _rotationSmoothParameter;
				transform.localRotation = Quaternion.Euler(0, 0, smoothRotate);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		_gameOver = true;
		_rigidbody2D.AddForce(transform.up * 0.4f * _jumpTrhust, ForceMode2D.Impulse);
		_rigidbody2D.AddForce(transform.right * -0.2f * _jumpTrhust, ForceMode2D.Impulse);
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("Exitted a trigger");
	}
}
