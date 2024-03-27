using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DecaClimb
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
            SceneManager.LoadScene(1);
        }

    }
}