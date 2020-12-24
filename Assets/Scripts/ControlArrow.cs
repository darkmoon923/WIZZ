using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 Velocity = new Vector2(0.0f, 0.0f);
    public GameObject Shooter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 NewPosition = CurrentPosition + Velocity * Time.deltaTime;

        Debug.DrawLine(CurrentPosition, NewPosition, Color.red);
        
        RaycastHit2D[] Hits = Physics2D.LinecastAll(CurrentPosition, NewPosition);

        foreach(RaycastHit2D hit in Hits)
        {
            GameObject other = hit.collider.gameObject;
            if(other != Shooter)
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    Debug.Log(other.name);
                    break;
                }

                if (other.CompareTag("Wall"))
                {
                    Destroy(gameObject);
                    break;
                }
            }

            
        }

        transform.position = NewPosition;
    }
}
