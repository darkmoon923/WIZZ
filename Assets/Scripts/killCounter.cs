using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text score;
    public static KillCounter Instance { get; set; }
    void Start()
    {
        Instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MonsterKilled()
    {
        GlobalData.Score += 1;
        score.text = GlobalData.Score.ToString();
    }
}
