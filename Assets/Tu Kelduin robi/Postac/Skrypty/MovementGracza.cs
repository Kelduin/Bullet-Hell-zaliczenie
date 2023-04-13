using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementGracza : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    [SerializeField] float speed = 3f;
    Animacja animate;

    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animacja>();
    }
    
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal"); //chodzi gora dol
        movementVector.y = Input.GetAxisRaw("Vertical"); //chodzi lewo prawo
        animate.horizontal = movementVector.x; //do sprawdzania horizontal movementu do animacji
        movementVector *= speed; //mozna zmieniac w editorze predkosc poruszania sie

        rgbd2d.velocity = movementVector;
    }
}
