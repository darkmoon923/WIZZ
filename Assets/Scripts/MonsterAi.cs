using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    private Transform target;
    public int health = 3;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       if (health <= 0)
        {
            Destroy(gameObject);
            target.transform.SendMessage("MmonsterKilled");
        }
        
    }
    void HitByRay()
    {
        health -= 1;
    }
}
