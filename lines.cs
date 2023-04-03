using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     Vector3 ps =GameObject.FindGameObjectWithTag("Skeleton").transform.position;
     Vector3 pss=GameObject.FindGameObjectWithTag("Player").transform.position; 
        LineRenderer = gameObject.AddComponent(LineRenderer);
        for(i=0,i=len(LineRenderer),i++):
            if (i==ps(i)):
              ps=ps+1 
           elif(ps=pss): 
             battle()
           
        else(){ 
            rotate(90)
        }
            
             
    
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
