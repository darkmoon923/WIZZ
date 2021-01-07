using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Hole : MonoBehaviour
{
    public GameObject MonsterPrefab;
    private Stopwatch stopwatch;
    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatch.Elapsed.Seconds >= 5)
        {
            Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
            stopwatch.Reset();
            stopwatch.Start();
        }
        
        
        
    }
}


