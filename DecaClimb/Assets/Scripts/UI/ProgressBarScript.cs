using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Revity.DecaClimb
{
    public class ProgressBarScript : MonoBehaviour
    {

        private static float delta = 0;

        private RectTransform rt;

        public static void StartProgress()
        {
            //float totalPillar = (PillarSpwan.lastpillar / 4) - 1;

            // Debug.Log(totalPillar);

            //delta = 970 / totalPillar;

            // Debug.Log(delta);
        }


        public void progressionBarUpdate(float pos)
        {

            // if(pos == 0)
            // {
            //     transform.position =new Vector2(transform.position.x,460);
            //     return;
            // }


            // float finalPos = PillarSpwan.lastpillar;
            // float playerPos = ((pos / finalPos) * 970) + 460;  // end(1430) - start(460) = 970

            float newpos = transform.position.y + delta;
            // Debug.Log(transform.position);
            // Debug.Log(delta);
            // Debug.Log(newpos);

            transform.position = new Vector2(transform.position.x, newpos);// + delta, 0);
        }
    }
}
