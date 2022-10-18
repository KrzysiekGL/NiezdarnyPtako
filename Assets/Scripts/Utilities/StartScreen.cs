using System;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreen : MonoBehaviour
{
		private UIDocument _doc;

		void Awake()
		{
				_doc = GetComponent<UIDocument>();
				// Subscribe to the Ptako's GameReset event
				GameObject.FindObjectOfType<Ptako>().GameReset += RestartTheGame;
		}

		void Update()
		{
				if (Input.GetKeyDown(KeyCode.Space) && _doc.rootVisualElement.style.display != DisplayStyle.None)
				{
						_doc.rootVisualElement.style.display = DisplayStyle.None;
				}
		}

		void RestartTheGame(object sender, EventArgs e)
		{
				_doc.rootVisualElement.style.display = DisplayStyle.Flex;
		}
}
