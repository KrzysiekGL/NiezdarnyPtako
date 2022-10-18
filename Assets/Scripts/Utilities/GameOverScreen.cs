using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverScreen : MonoBehaviour
{
		private UIDocument _doc;

		void Awake()
		{
				_doc = GetComponent<UIDocument>();
				_doc.rootVisualElement.style.display = DisplayStyle.None;
				// Subscribe to Ptako's GameEnded and GameReset events
				Ptako ptako = FindObjectOfType<Ptako>();
				ptako.GameEnded += GameOver;
				ptako.GameReset += GameRestart;
		}

		void GameOver(object sender, EventArgs e)
		{
				_doc.rootVisualElement.style.display = DisplayStyle.Flex;
		}

		void GameRestart(object sender, EventArgs e)
		{
				_doc.rootVisualElement.style.display = DisplayStyle.None;
		}
}
