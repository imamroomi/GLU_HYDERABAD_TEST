using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOUR_D_LOGICS : MonoBehaviour
{
    int count = 0;
    public static bool Four_D_difficulties;
    // Start is called before the first frame update
    void Start()
    {
        Four_D_difficulties = false;
    }


    void four_D_logics()
    {
        if(AI_controller.time%60==0)
        {
            ++count;
            if (count % 2 == 0)
            {
                Four_D_difficulties = false;
            }
            else
                Four_D_difficulties = true;

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        four_D_logics();        
    }
}
