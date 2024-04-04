using System.Collections;
using UnityEngine;

namespace Revity.DecaClimb
{
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
            PersistantSceneService.Instance.LoadMainMenuScene();
        }

    }
}