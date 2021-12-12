using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpwanner : MonoBehaviour
{


    public GameObject ground;
    public Material redMat;
    public Material safeMat;

    public Material FinishMat;

    public bool first = false;
    public bool last = false;


    // Start is called before the first frame update
    void Start()
    {

        GroundSpwan();

        
        GroundDestroy();

        SetDangerZone();
        
        
        
        
    }


    private void GroundSpwan()
    {
        for(int i=0 ; i<10 ; i++)
        {
            GameObject grounds = Instantiate(ground);
            grounds.transform.position = transform.position;
            grounds.transform.SetParent(transform);
            grounds.transform.rotation = Quaternion.Euler(90,i*36,0);

            if(last)
            {
                grounds.GetComponent<MeshRenderer>().material = FinishMat;
                grounds.tag = "Finish";
            }
        }
    }

    private void GroundDestroy()
    {

        int amountToDestroy = Random.Range(2,6);

        for(int i=0 ; i<amountToDestroy ; i++)
        {
            
            int index = Random.Range(0,transform.childCount);
            
            if(first)
                index = Random.Range(2,transform.childCount);


            Destroy(transform.GetChild(index).gameObject);
        }
    }

    private void SetDangerZone()
    {
        
        if(!last)
        {
            int dangerZone = Random.Range(1,4);
        
            for(int i=0; i<dangerZone ; i++)
            {
                int index = Random.Range(0,transform.childCount);

                if(first)
                    index = Random.Range(2,transform.childCount);

                GameObject dangerGround = transform.GetChild(index).gameObject;
                dangerGround.tag = "Danger";

                MeshRenderer danger = dangerGround.GetComponent<MeshRenderer>();

                if(danger.material == redMat)
                    continue;
                else
                    danger.material = redMat;

            }  
        }
    }
  
}
