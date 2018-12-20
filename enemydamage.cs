using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
   // Animator anim;
    int attackdir;
    public GameObject shell;
    bool canAttack;
    float aTimer = 0f;
    public float thrustPower;
    // Use this for initialization
    void Start()
    {
       // anim = GetComponent<Animator>();
        attackdir = Random.Range(0, 3);
        canAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        aTimer += Time.deltaTime;
        if (aTimer >= 2f)
        {
            aTimer = 0f;
            canAttack = true;
        }
        Attack();
    }

    void Attack()
    {
        if (canAttack == false)
        {
            Debug.Log("Not Shooting");
            return;
        }
       // attackdir = anim.GetInteger("movedirection");
//        if (attackdir == 0)
//        {
//            GameObject newprojectile = Instantiate(shell, transform.position, transform.rotation);
//            newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrustPower);
//        }
        if (attackdir == 0)
        {
            GameObject newprojectile = Instantiate(shell, transform.position, transform.rotation);
            newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower);
        }
//        if (attackdir == 2)
//        {
//            GameObject newprojectile = Instantiate(shell, transform.position, transform.rotation);
//            newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrustPower);
//        }
        if (attackdir == 1)
        {
            GameObject newprojectile = Instantiate(shell, transform.position, transform.rotation);
            newprojectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrustPower);
        }
        canAttack = false;
    }
}
