using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    //public Animator shootAnimator;
    public GameObject arrowPrefab;
    public GameObject FrontSight;
    public Text KillNum;
    public GameObject player;
    private const float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        GlobalData.score = 0;
        GlobalData.facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed, 0.0f);
        if (player.transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x) 
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            GlobalData.facingRight = false;
            Debug.Log("0");
        }

        if (player.transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            GlobalData.facingRight = true;
            Debug.Log("1");
        }
        animator.SetBool("attack", Input.GetButtonDown("Fire1"));

        transform.position = transform.position + movement * Time.deltaTime;
        

        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }

        if(Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene(3);
            Cursor.visible = true;
        }

    }

    private void Shooting()
    {
        float ArrowSpeed = 15.0f;
        Vector2 PlayerFacing = FrontSight.transform.position - transform.position;
        PlayerFacing.Normalize();
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        ControlArrow ArrowScript = arrow.GetComponent<ControlArrow>();
        ArrowScript.Velocity = PlayerFacing * ArrowSpeed;
        ArrowScript.Shooter = gameObject;
        arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(PlayerFacing.y, PlayerFacing.x) * Mathf.Rad2Deg);
        Destroy(arrow, 2.5f);
    }
}
