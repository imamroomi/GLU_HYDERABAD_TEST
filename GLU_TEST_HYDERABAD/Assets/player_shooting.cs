using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player_shooting : MonoBehaviour
{
    public AudioClip shoot;
    public GameObject pwrups;
    int temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static player_shooting Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        powerups();
    }

   public  void shooting_bullet(string tag,GameObject ob)
    {

        AudioSource.PlayClipAtPoint(shoot, transform.position);
        Rigidbody rg;  
        
        rg = ob.GetComponent<Rigidbody>();
        rg.velocity=(transform.forward) * 120;
     
    }

    void powerups()
    {
        if(Input.GetKeyDown(KeyCode.Space) &&temp==0)
        {
            temp++;
            pwrups.transform.position = this.transform.position;
            Rigidbody rg;
            rg =pwrups.GetComponent<Rigidbody>();
            rg.velocity = (transform.forward) * 100;
        }
    }


  
}
