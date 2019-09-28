using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigid; // Rigidboy for the Player and monster
    public float acceleration = 5F; //The acceleration fo
    public float maxSpeed = 650; //Max autoclick speed
    public float currentAutoClickForce; //Adjust the ammout of force for debugging 
    private Vector2 direction; //Vector2 for the rigidbody movement
    public Animator frog; //The animator for the monster
    public Animator human; //The animator for the human
    bool testMovement; //A bool used to freeze the rigidbody when needed
    public Slider screamSlider; //Slider refrence for the screams perSecondBar

    private void Start()
    {
        //On Start begin repeating the void AddAutoForce
        InvokeRepeating("AddAutoForce", 1, 0.1f);
    }

    void Update()
    {
        //Changes the animation speed of the monster and human based on how fast the rigidboy is moving
        frog.speed = (playerRigid.velocity.x / maxSpeed) * 70;
        human.speed = (playerRigid.velocity.x / maxSpeed) * 70;
        //If the rigid body is moving below a certain speed it freezes the rigid body
        if (playerRigid.velocity.magnitude < 0.5f && !testMovement)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            testMovement = true;
        }
        //updates the slider value to max per second speed
        screamSlider.value = Click.perSecondValue / maxSpeed;
    }

    //Auto adds force to the monster and human
    void AddAutoForce()
    {
        //If the Click per second value is less than the max speed set the currentAutoClickForce * 0.2f * perSecondValue to the force added to the monster
        if (Click.perSecondValue <= maxSpeed)
        {
            AddMonsterForce((currentAutoClickForce * 0.2f) * Click.perSecondValue);
        }
        else
        //else just set the currentAutoClickForce * 0.2f * max speed to the force added
        {
            AddMonsterForce((currentAutoClickForce * 0.2f) * maxSpeed);
        }
    }

    //Adds force to the monster and player
    //If no value is inputed just add 5f
    public void AddMonsterForce(float amount = 5f)
    {
        //If the velocity of the player and moster is greater than 0.2f set movement to false
        if (playerRigid.velocity.magnitude > 0.2f)
        {
            testMovement = false;
        }
        //Remove constaints and unfreeze the player and monster
        playerRigid.constraints = RigidbodyConstraints2D.None;
        //Add force to the vector 3 direction and add that force to the rigid body
        direction = new Vector3(1 * amount, 0, 0);
        playerRigid.AddForce(direction);
    }
}
