using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class CoinSpwanScript : MonoBehaviour
    {

        public GameObject coin;

        // Start is called before the first frame update
        void Start()
        {

            int coinAmount = Random.Range(1, 4);
            // int amount = 0 ;
            // if(coinAmount % 2 == 0)
            //     amount = 2;

            for (int i = 0; i < coinAmount; i++)
            {

                Quaternion rotaion = Quaternion.Euler(0, Random.Range(0, 360), 0);

                Instantiate(coin, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);

            }

        }

    }
}