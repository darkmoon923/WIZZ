using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Finalscore;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Finalscore.text = GlobalData.Score.ToString();
    }
}

