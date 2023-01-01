using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //bruger unitys inputsystem 

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement; // det input fra brugeren når de trykker på WASD som man ønsker at gemme 
    private Rigidbody2D myBody; // Det rigidbody som man ønsker at rykke rundt på

    [SerializeField] private int speed = 5; //vores karakters hastighed, som er i et[SerializeField] så hastigheden også kan ændres i Unity  
    private Animator myAnimator; //variable for vores Animator som kan bruge i vores kode 

    private void Awake() // kører en enkelt gang når man starter programmet 
    {
        myBody = GetComponent<Rigidbody2D>(); //sætter myBody til rigidbody på vores gameobject
        myAnimator = GetComponent<Animator>(); //Animator som sidder på vores gameobject 
    }
    private void OnMovement(InputValue value) //funktion som holder øje med vores input systyms value 
    {
        movement = value.Get<Vector2>(); //movement bliver sat til vector2 fra det Input Action når brugeren trykker WASD 

        if (movement.x != 0 || movement.y != 0) //value.vector2 bliver sat til [0,0] når der ikke bliver trykket på WASD
                                                //karakteren kigger alt op når man er færdig med at trykke på WASD 
        {                                       //vi kan derfor ændrer vores animation men kun hvis mindst en af x eller y ikke er = 0
            myAnimator.SetFloat("x", movement.x); // x i animatoren til movement.x dette kommer fra Unity input  
            myAnimator.SetFloat("y", movement.y); // y i animatoren til movement.y dette kommer fra Unity input 

            myAnimator.SetBool("isWalking", true); // når movement.x eller y ikke er = 0 betyder at vi går  
        }
        else
        {
            myAnimator.SetBool("isWalking", false); // ellers går vi ikke og sætter den til false 
        }
    }

    private void FixedUpdate() //FixedUpdate er mere effiktiv end update til even based ting i vores tilfælde flyttning  
    {
        myBody.velocity = movement * speed; // velocity af vores Rigidbody = hastigheden som vi har sat 
    }
}