using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreen : MonoBehaviour {
	[SerializeReference] private UIDocument _uiDocument;

		void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Destroy(_uiDocument);
		}
	}
}
