using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour    
{
    /*
     * 
     * 
     * 
     */

    //<access-specifier> <data-type> <variable name>
    public Rigidbody2D rigid;
    public float acceleration = 1F;
    public float maxSpeed;
    public float currentAutoClickForce;

    public static float currentSpeed;

    

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("AddAutoForce", 1, 1f);

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMonsterForce(acceleration);
        }


    }

    void AddAutoForce()
    {
        AddMonsterForce(currentAutoClickForce);
        //(float)currentAutoClickForce / 100)
    }

    void AddMonsterForce(float amount)
    {        
        Vector3 direction = new Vector3(1, 0, 0);
        rigid.AddForce(direction * amount);
    }
}
