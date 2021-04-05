using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class killCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text KillNum;
    public int Number;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void MmonsterKilled()
    {
        Number += 1;
        KillNum.text = Number.ToString();
    }
}
