using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontSight : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject arrowPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        Cursor.visible = false;
    }
   private void Aim()
    {
        
        var Pos = Input.mousePosition;
        Pos.z = 45;
        Pos = Camera.main.ScreenToWorldPoint(Pos);
        transform.position = Pos;
        
    }
}
