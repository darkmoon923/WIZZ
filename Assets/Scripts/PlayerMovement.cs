using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject arrowPrefab;
    public GameObject FrontSight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*5, Input.GetAxis("Vertical")*5, 0.0f);

        

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
        Vector2 PlayerFacing = FrontSight.transform.position - transform.position;
        PlayerFacing.Normalize();
        Debug.Log("Fire1");
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = PlayerFacing * 20;
        arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(PlayerFacing.y, PlayerFacing.x) * Mathf.Rad2Deg);
        Destroy(arrow, 2.5f);
    }
}
