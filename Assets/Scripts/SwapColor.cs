using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapColor : MonoBehaviour {
	private Animator _animator;

	void Start() {
		_animator = gameObject.GetComponent<Animator>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.C)) {
			_animator.SetTrigger("SwapNext");
		}
	}
}
