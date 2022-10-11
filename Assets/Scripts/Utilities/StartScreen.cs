using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreen : MonoBehaviour
{
		private UIDocument _doc;

		void Awake()
		{
				_doc = GetComponent<UIDocument>();
		}

		void Update()
		{
				if (Input.GetKeyDown(KeyCode.Space))
				{
						Destroy(_doc);
				}
		}
}
