
using UnityEngine;

namespace DecaClimb
{
    public class SettingsManager : MonoBehaviour
    {
		private const string STR_VERSION = "Version";
		private float CurrentVersion { get { return float.Parse(Application.version); } }

		public void LoadSetting()
		{
			LoadApplicationVersionData();
			PersistantDataHandler.Instance.OnSettingsLoaded();
		}

		private void LoadApplicationVersionData()
		{
			// First Time playing
			if (!PlayerPrefs.HasKey(STR_VERSION))
			{
				PlayerPrefs.SetFloat(STR_VERSION, CurrentVersion);
				PersistantDataHandler.Instance.OnNewInstall();
			}
			// New version / updated
			else if (PlayerPrefs.GetFloat(STR_VERSION) < CurrentVersion)
			{
				PlayerPrefs.SetFloat(STR_VERSION, CurrentVersion);
				PersistantDataHandler.Instance.OnVersionUpdated();
				// show change log or something
			}
			else
			{
				// Get and set settings
				PersistantDataHandler.Instance.OnSettingsLoaded();
			}
		}
	}

}
