using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class asteroid_movement : MonoBehaviour
{
    public GameObject plyr;
    public static asteroid_movement instance;
    IEnumerator coroutine;
    public static float  asteroid_speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        instance = this;
    }

 

    public void asteroid_move(string tag, float speed, GameObject bl, Vector3 pos, Quaternion rot)
    {
     
        if (tag == "Asteroid1"|| tag == "Asteroid2"|| tag == "Asteroid3"||tag=="Asteroid6")
        {
            
          //  coroutine = asteroid_moving(pos, plyr.transform.position, asteroid_speed, bl);
          //  StartCoroutine(coroutine);
            //rg.AddForce((plyr.transform.position.x-pos.x)*10, 0, -speed*40);

        }
     
        else
        {
           
            Vector3 tr;
            float x, y, z;
            x = Random.Range(plyr.transform.position.x - 4, plyr.transform.position.x + 4);
            y = Random.Range(plyr.transform.position.y - 4, plyr.transform.position.y + 4);
            z = Random.Range(plyr.transform.position.z - 4, plyr.transform.position.z + 4);
            // y = plyr.transform.position.y ;
            // z = plyr.transform.position.z;
         tr= new  Vector3(x, y, z);
            coroutine = asteroid_moving2(pos, tr,asteroid_speed, bl);
            StartCoroutine(coroutine);

        }


    }

    IEnumerator asteroid_moving(Vector3 source, Vector3 target, float overTime, GameObject bl)
    {
        Rigidbody rg;
        rg = bl.GetComponent<Rigidbody>();
       
        target = target - new Vector3(0, 0, 3);
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            bl.transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        bl.transform.position = target;
        rg.velocity =- plyr.transform.forward * 10;
    }
    IEnumerator asteroid_moving2(Vector3 source, Vector3 tar, float overTime, GameObject bl)
    {

        Rigidbody rg;
        rg = bl.GetComponent<Rigidbody>();

        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            
            bl.transform.position = Vector3.Lerp(source, tar, (Time.time - startTime) / overTime);
            yield return null;
        }
      //  bl.transform.position = tar;
        rg.velocity = -(plyr.transform.forward * 10);
      //  StopCoroutine(coroutine);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
