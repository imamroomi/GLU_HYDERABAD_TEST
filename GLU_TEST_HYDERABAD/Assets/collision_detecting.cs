using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_detecting : MonoBehaviour
{

    
    public GameObject gameovr_button, menu_button;
   
    public static int lives = 2;
    public GameObject plyr;
    float highscore_Val;
    public static float score=0;
    // Start is called before the first frame update
    void Start()
    {
        highscore_Val = PlayerPrefs.GetFloat("highscore", highscore_Val);
    }
    private void OnTriggerEnter(Collider other)
    {
        IEnumerator coroutine=Delay(other.gameObject); ;
        
        if (other.tag.Equals("player"))
        {

            Debug.LogWarning("COLLIs");
            other.gameObject.SetActive(false);

            if (lives > 0)
            {
                StartCoroutine(coroutine);
            }
            else
            {
                gameovr();
            }
        }
        else if (other.tag.Equals("bullet")|| other.tag.Equals("pwrup") )
        {
            score = score + 5;
            this.gameObject.SetActive(false);
        }
        
    }
    // Update is called once per frame
    IEnumerator Delay(GameObject go)
    {

        yield return new WaitForSeconds(2f);
        go.transform.position =go.transform.position + new Vector3(0, 200, 200);
        go.SetActive(true);
        lives--;
    }

    void gameovr()
    {
        if (score > highscore_Val)
        {

            PlayerPrefs.SetFloat("highscore", collision_detecting.score);
        }
        gameovr_button.SetActive(true);
        menu_button.SetActive(true);
        score = 0;
        AI_controller.time = 0;
    }
    void Update()
    {
    }
}
