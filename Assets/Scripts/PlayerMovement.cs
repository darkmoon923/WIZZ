using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject arrowPrefab;
    public GameObject FrontSight;
    private const float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed, 0.0f);

        

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);*/

        transform.position = transform.position + movement * Time.deltaTime;
        

        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
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
