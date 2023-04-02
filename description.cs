using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class description : MonoBehaviour
{ //light or dark, move in one direction until wall, health indicator?, base damage *damage multiplyer
  
    
    // Start is called before the first frame update
    void Start()
    { 
        bool light; 
        double bh,bd,multiplyer,td=bd*multiplyer;
        bh=0.50 
        bd=0.20 
        multiplyer=1
        while(0<bh<100):
         if (light==0):
         bh=bh+td
         else: 
          bh=bh-td    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
