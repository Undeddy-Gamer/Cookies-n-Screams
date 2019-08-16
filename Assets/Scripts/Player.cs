using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour    
{

    //<access-specifier> <data-type> <variable name>
    public Rigidbody2D PlayerRigid;
    public float acceleration = 5F;
    public float maxSpeed;
    public float currentAutoClickForce; //Needs to be added Click.perSecondValue;
    private Vector3 direction;
    public Animator Frog; 
    public Animator Human;
    public static float currentSpeed;
    bool Test;

    private void Start()
    {
        InvokeRepeating("AddAutoForce", 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Frog.speed = (PlayerRigid.velocity.x / maxSpeed) * 9;
        Human.speed = (PlayerRigid.velocity.x / maxSpeed) * 9;
        //Debug.Log(PlayerRigid.velocity.x);
        if (PlayerRigid.velocity.magnitude < 0.5f && !Test)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            Test = true;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    AddMonsterForce(acceleration);
        //}
    }

    void AddAutoForce()
    {
        AddMonsterForce(currentAutoClickForce);
        //(float)currentAutoClickForce / 100)
    }

    public void AddMonsterForce(float amount = 5f)
    {
        if (PlayerRigid.velocity.magnitude > 0.2f)
        {
            Test = false;
        }
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        direction = new Vector3(1 * amount, 0, 0);
        PlayerRigid.AddForce(direction);
    }
}
