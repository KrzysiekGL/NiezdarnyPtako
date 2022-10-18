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

		void Update()
		{
				if(Input.GetKeyDown(KeyCode.Escape))
						Application.Quit();
		}
}
