using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_controller : MonoBehaviour
{

    public static float time=0;
    public GameObject[] environmentobj;
    Vector3 asteroid_spawner_point, asteroid_spawner_point2;
    Vector3 asp,asp1,asp2,asp3,asp4,asp5;
    //float time = 0;
    public GameObject plyr;
    float total_time = 1;
    //public Text clear, gmovr;
    public static bool clearr = false;
    public Text timetext;
    public static AI_controller instance;
   IEnumerator cr;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frsame update
    void Start()
    {
        //Invoke("Asteroid1", 1);
        cr = Delay();
        StartCoroutine(cr);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        time = time + Time.deltaTime;
        timetext.text = "T=> " + Mathf.Ceil(time);
        enviroment_obj_spawn();
     
         
    }


    public void AIController(int level, float duration)
    {
        total_time = duration;
        // InvokeRepeating("Asteroid1", 1, 5);

        if (level == 1)
        {
            InvokeRepeating("Asteroid1", 1, 3);
            InvokeRepeating("Asteroid2", 2, 2);
           
            InvokeRepeating("Asteroid3", 3, 3);

            InvokeRepeating("Asteroid4", 4, 1);

            InvokeRepeating("Asteroid5", 5, 1);
            if (time > 30)
            {
              asteroid_movement.asteroid_speed = 2.7f;
                InvokeRepeating("Asteroid6", 5, 1);
            }
            if (time > 60)
            {
                asteroid_movement.asteroid_speed = 2.5f;

                InvokeRepeating("Asteroid7", 5, 1);
            }
            if (time > 90 )
            {
                asteroid_movement.asteroid_speed = 2.2f;

                InvokeRepeating("Asteroid8", 5, 1);
            }
            if (time > 120)
            {
                asteroid_movement.asteroid_speed = 1.8f;

                InvokeRepeating("Asteroid9", 5, 1);
            }
        }

    }

     
        IEnumerator Delay()
        {

            yield return new WaitForSeconds(1f);
        AIController(1, 90f);
    }
       

    void Asteroid_Random_spawn_pos()
    {
        asp = plyr.transform.position + plyr.transform.forward * 25;
        asp1 = (plyr.transform.position + ((-(plyr.transform.right) * 15) + plyr.transform.forward * 17));
        asp2 = (plyr.transform.position + ((plyr.transform.right * 15) + plyr.transform.forward * 17));
        asp3 = (plyr.transform.position + ((-(plyr.transform.right) * 15) + plyr.transform.forward * 25));
        asp4 = (plyr.transform.position + (plyr.transform.right * 15) + (plyr.transform.forward) * 25);
        asp5 = (plyr.transform.position + (plyr.transform.right * 15) + (plyr.transform.forward) * 25);

        int random;
        random = UnityEngine.Random.Range(0, 6);
        if (random == 0)
        {
            asteroid_spawner_point = asp;
        }
        else if (random == 1)
        {
            asteroid_spawner_point = asp1;
        }
        else if (random == 2)
        {
            asteroid_spawner_point = asp2;
        }
        else if (random == 3)
        {
            asteroid_spawner_point = asp3;
        }
        else if (random == 4)
        {
            asteroid_spawner_point = asp4;
        }
        else if (random == 5)
        {
            asteroid_spawner_point = asp5;
        }
    }
    void Asteroid_Random_spawn_pos2()
    {

       
    }




    void enviroment_obj_spawn()
    {

        for (int a = 0; a < 5; a++)
        {
            if (!environmentobj[a].activeInHierarchy)
            {
                environmentobj[a].SetActive(true);
                environmentobj[a].transform.position = (plyr.transform.position + ((plyr.transform.right * (UnityEngine.Random.Range(-20,20)) + plyr.transform.forward * (UnityEngine.Random.Range(-80, 110)))));
            }
            if (Vector3.Distance(environmentobj[a].transform.position, plyr.transform.position) > 111) 
            {
                environmentobj[a].SetActive(false);
            }

        }
    }
    void Asteroid1()
        {

       
        Asteroid_Random_spawn_pos();

            spawner.Instance.enemies_spawn("Asteroid1", asteroid_spawner_point, this.transform.rotation,1);

        }
        void Asteroid2()
        {
        Asteroid_Random_spawn_pos();
            
            spawner.Instance.enemies_spawn("Asteroid2", asteroid_spawner_point, this.transform.rotation,1);
        }
    void Asteroid3()
    {

        Asteroid_Random_spawn_pos();
        
            spawner.Instance.enemies_spawn("Asteroid3", asteroid_spawner_point, this.transform.rotation, 1);
        }
    
        void Asteroid4()
        {
      
        Asteroid_Random_spawn_pos();

       
        spawner.Instance.enemies_spawn("Asteroid4", asteroid_spawner_point, this.transform.rotation,2);
        }

    void Asteroid5()
    {
        
     //   if (FOUR_D_LOGICS.Four_D_difficulties == true)
       // {
            Asteroid_Random_spawn_pos();
            spawner.Instance.enemies_spawn("Asteroid5", asteroid_spawner_point2, this.transform.rotation, 2);
      //  }
    }
    void Asteroid6()
    {
        if (FOUR_D_LOGICS.Four_D_difficulties == true)
        {
            Asteroid_Random_spawn_pos();

            spawner.Instance.enemies_spawn("Asteroid6", asteroid_spawner_point2, this.transform.rotation, 2);
        }
    }
    void Asteroid7()
        {
            if (FOUR_D_LOGICS.Four_D_difficulties == true)
            {
                Asteroid_Random_spawn_pos();

                spawner.Instance.enemies_spawn("Asteroid7", asteroid_spawner_point, this.transform.rotation, 1);
            }
        }
    void Asteroid8()
    {
        Asteroid_Random_spawn_pos();

        spawner.Instance.enemies_spawn("Asteroid8", asteroid_spawner_point, this.transform.rotation, 1);
    }
    void Asteroid9()
    {
        Asteroid_Random_spawn_pos();
        spawner.Instance.enemies_spawn("Asteroid9", asteroid_spawner_point, this.transform.rotation, 1);

    }




}
