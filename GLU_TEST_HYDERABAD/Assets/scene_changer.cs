using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_changer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
    }




   public void loadScenegame()
    {
        collision_detecting.lives = 2;
        SceneManager.LoadScene("game");

    }


    public void loadscene_menu()
    {
        SceneManager.LoadScene("menu");
    }
}

