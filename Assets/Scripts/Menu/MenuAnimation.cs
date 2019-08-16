using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour    
{
    public Rigidbody2D MenuRigid;
    public float acceleration = 50f;
    private Vector3 direction;

    private void Start()
    {
        direction = new Vector2(1 * acceleration, 0);
        MenuRigid.AddForce(direction);
    }

}
