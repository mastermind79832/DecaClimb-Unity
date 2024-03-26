using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DecaClimb
{
    public class PersistantSettingManager : MonoBehaviour
    {
		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.Android)
				{
					Application.Quit();
					return;
				}
				
				EditorApplication.ExitPlaymode();

			}
		}
	}
}
