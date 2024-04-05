using Revity.DecaClimb.Persistant;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class BallFollowScript : MonoBehaviour
    {

        public Transform player = null;

        private float playerLoc;

        // Start is called before the first frame update
        void Start()
        {
            transform.GetComponent<Camera>().backgroundColor = PersistantServiceLocator.Instance.DataHandler.BackgroundColor.GetColorRandom() ;
            playerLoc = player.position.y;

        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
                return;

            float updatePlayerLoc = player.position.y;

            if (updatePlayerLoc != playerLoc)
            {
                float NewCameraLoc = updatePlayerLoc - playerLoc;

                transform.position = new Vector3(transform.position.x, transform.position.y + NewCameraLoc, transform.position.z);
                playerLoc = updatePlayerLoc;
            }
        }
    }
}