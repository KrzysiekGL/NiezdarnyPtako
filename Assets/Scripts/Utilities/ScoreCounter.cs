using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCounter : MonoBehaviour
{
		private int _score = 0;

		private Label _scoreCounter;

		void Start()
		{
				// Find the UI score counter
				_scoreCounter = GetComponent<UIDocument>().rootVisualElement.Q<Label>("score");

				// Subscribe to the "PointScored" event
				GameObject.FindObjectOfType<Ptako>().PointScored += IncrementScoreCounter;
		}

		void IncrementScoreCounter(object sender, EventArgs e)
		{
				// Inrement the score and update the UI element with the score count
				_score += 1;
				_scoreCounter.text = _score.ToString();
		}
}
