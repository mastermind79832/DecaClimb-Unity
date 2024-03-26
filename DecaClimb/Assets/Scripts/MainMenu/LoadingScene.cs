using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DecaClimb
{
    public class LoadingScene : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LogoRunning());

        }


        IEnumerator LogoRunning()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(1);
        }

    }
}