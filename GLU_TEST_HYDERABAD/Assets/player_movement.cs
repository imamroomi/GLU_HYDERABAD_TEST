using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public class player_movement : MonoBehaviour
{

    UnityEngine.Quaternion cr;

    float turningAngleY=0;
    float turningAngleX = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //cr.eu
        cr = UnityEngine.Quaternion.Euler(0, 0, 0);
    }



    void movefrward()
    {

        //   transform.position +=  Vector3.forward;
        // this.transform.position += (transform.forward*Time.deltaTime)*10f;
        this.transform.position += this.transform.forward ;
        }
    
    void turning()
    {

        if (Input.GetKey(KeyCode.UpArrow)&&turningAngleX<35)
        {
            turningAngleX = turningAngleX + 1;
            cr = UnityEngine.Quaternion.Euler(turningAngleX, turningAngleY, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow)&&turningAngleX>-35)
        {
            turningAngleX = turningAngleX - 1;
            cr = UnityEngine.Quaternion.Euler(turningAngleX, turningAngleY, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            turningAngleY = turningAngleY - 5;
            cr = UnityEngine.Quaternion.Euler(turningAngleX, turningAngleY, 0);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            turningAngleY = turningAngleY + 5;
            cr = UnityEngine.Quaternion.Euler(turningAngleX, turningAngleY, 0);

        }
        transform.rotation = UnityEngine.Quaternion.Slerp(this.transform.rotation, cr, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        turning();
        movefrward();
    }
}
