using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
		[SerializeField]
		private int TargetFrameRate = 30;

		void Start()
		{
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = TargetFrameRate;
    }
}
