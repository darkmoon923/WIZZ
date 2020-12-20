using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Timer = 0;
        if (Input.GetButtonDown("Fire1"))
        {
            arrow.GetComponent<Collider2D>().enabled = false;
            Timer += Time.deltaTime;
            while (Timer == 0.1) 
            {
                arrow.GetComponent<Collider2D>().enabled = true;
                Timer = 0;
            }
        }
    }
}
