using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour    
{
    public Rigidbody2D menuRigid; //The Invisable GameObjects's rigidbody
    public float acceleration = 40f; //How fast the GameObject will be moving
    private Vector3 direction; //Vector 3 movement infomation of the object

    private void Start()
    {
        //Sets the information for movement speed then applys it to the menu creating the movement effect
        direction = new Vector2(acceleration, 0);
        menuRigid.AddForce(direction);
    }

}
