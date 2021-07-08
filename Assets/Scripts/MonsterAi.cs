using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAi : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator monsterAnimator;
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
        if(gameObject.transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (gameObject.transform.position.x < target.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (health <= 0)
        {
            //monsterAnimator.Play("slimeDie", -1, 0);+
           // monsterAnimator = gameObject.GetComponentInChildren<Animator>();
            Destroy(gameObject);
            target.transform.SendMessage("MmonsterKilled");
        }
    }

    void HitByRay()
    {
        health -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(3);
        Cursor.visible = true;
    }
}
