using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //<access-specifier> <data-type> <variable name>
    public Rigidbody2D PlayerRigid; // Rigidboy for the Player and monster
    public float acceleration = 5F; //
    public float maxSpeed = 650; //Max autoclick speed
    public float currentAutoClickForce; //Adjust the ammout of force for debugging 
    private Vector2 direction; //Vector2 for the rigidbody movement
    public Animator Frog; //The animator for the monster
    public Animator Human; //The animator for the human
    public static float currentSpeed; 
    bool testMovement;
    public Slider screamSlider; //Slider refrence for the screams perSecondBar

    private void Start()
    {
        //On Start begin repeating the void AddAutoForce
        InvokeRepeating("AddAutoForce", 1, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Frog.speed = (PlayerRigid.velocity.x / maxSpeed) * 12;
        Human.speed = (PlayerRigid.velocity.x / maxSpeed) * 13;
        if (PlayerRigid.velocity.magnitude < 0.5f && !testMovement)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            testMovement = true;
        }
        screamSlider.value = Click.perSecondValue / maxSpeed;
    }

    void AddAutoForce()
    {
        if (Click.perSecondValue <= maxSpeed)
        {
            AddMonsterForce((currentAutoClickForce * 0.2f) * Click.perSecondValue);
        }
        else
        {
            AddMonsterForce((currentAutoClickForce * 0.2f) * maxSpeed);
        }
    }
    public void AddMonsterForce(float amount = 5f)
    {
        if (PlayerRigid.velocity.magnitude > 0.2f)
        {
            testMovement = false;
        }
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        direction = new Vector3(1 * amount, 0, 0);
        PlayerRigid.AddForce(direction);
    }
}
