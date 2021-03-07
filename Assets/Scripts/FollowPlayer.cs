using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    private Transform PlayerPosition;
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, speed * Time.deltaTime);
    }
}
