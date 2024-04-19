
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{

	public enum LoadState
	{
		NewInstall,
		Updated,
		Returning
	}

	/// <summary>
	/// class that handles the Loading and saving settings
	/// </summary>
    public class SettingsManager
    {
		private const string STR_VERSION = "Version";
		private string CurrentVersion { get { return Application.version; } }

		private LoadState m_LoadState;
		public LoadState LoadState {  get { return m_LoadState; } }

		public SettingsManager()
		{
			LoadApplicationVersionData();
		}

		private void LoadApplicationVersionData()
		{
			// First Time playing
			if (!PlayerPrefs.HasKey(STR_VERSION))
			{
				m_LoadState = LoadState.NewInstall;
				PlayerPrefs.SetString(STR_VERSION, CurrentVersion);
				// load default Setting
			}
			// Same version
			else if (PlayerPrefs.GetString(STR_VERSION) == CurrentVersion)
			{
				m_LoadState = LoadState.Returning;
				// Get and set settings
				// Load setting
			}
			// New version / updated
			else
			{
				m_LoadState = LoadState.Updated;
				PlayerPrefs.SetString(STR_VERSION, CurrentVersion);
				// Load change log or something
				// Load Setting
			}
		}
	}

}
