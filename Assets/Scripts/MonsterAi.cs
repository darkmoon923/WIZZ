using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAi : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator monsterAnimator;
    private float speed = 4.0f;
    private Transform target;
    public int Health { get; set; } = 3;
    public bool HasDied { get; set; } = false;
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
        if (Health <= 0 && !HasDied)
        {
            HasDied = true;
            StartCoroutine(PlayDeathAnimationThenDestory());
            KillCounter.Instance.MonsterKilled();
        }
        speed = GlobalData.Score / 10 + 2;
    }

    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player") && !HasDied)
        {
            SceneManager.LoadScene(3);
            Cursor.visible = true;
        }
    }

    private IEnumerator PlayDeathAnimationThenDestory()
    {
        Animator monsterAnimator = GetComponent<Animator>();
        monsterAnimator.Play("slimeDie", -1, 0);
        while (!(monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("slimeDie") && monsterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f))
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
