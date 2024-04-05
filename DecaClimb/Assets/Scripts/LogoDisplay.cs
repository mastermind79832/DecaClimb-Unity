using Revity.DecaClimb.Persistant;
using System.Collections;
using UnityEngine;

namespace Revity.DecaClimb
{
    /// <summary>
    /// Class for displaying logo at the beginning
    /// </summary>
    public class LogoDisplay : MonoBehaviour
    {
		// Start is called before the first frame update
		private void Awake()
		{
            Application.targetFrameRate = 90;
		}
		void Start()
        {
            StartCoroutine(RunLogo());
        }

        IEnumerator RunLogo()
        {
            yield return new WaitForSeconds(2f);
			PersistantServiceLocator.Instance.SceneService.LoadMainMenuScene();
        }

    }
}