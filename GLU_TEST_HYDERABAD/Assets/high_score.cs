using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class high_score : MonoBehaviour
{
    float highscore_Val = 0;
    public Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore.fontSize = 25;
        highscore_Val = PlayerPrefs.GetFloat("highscore", highscore_Val);
        highscore.text = "H-SCORE- " + PlayerPrefs.GetFloat("highscore", highscore_Val).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
