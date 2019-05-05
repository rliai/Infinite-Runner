using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    
    

    [SerializeField]
    private float speed = 2f; //vertical speed

    [SerializeField]
    private float force = 5f; //control force for jumping after player press space
    [SerializeField]
    private float lowerBound = -3.5f; //cannot be lower than this value, floor
    [SerializeField]
    private float upperBound = 3.5f; //cannot be higher than this value, ceiling

    private Rigidbody2D _rb; //its own rigidbody
    private GameManager gm;
    
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        Physics.gravity = 0.25f * Physics.gravity; //to kae the game easier, reduce the gravity value
    }

    
    void Update()
    {
        //before pressing start
        if (gm.game_start == false) {
            return;
        }
        //check if it is outside the floor/ceiling
        if (transform.position.y > upperBound || transform.position.y < lowerBound) {
            gm.Lose();
            return;
        }
        //jump  by pressing space and a speed on x axis
        float velo_y = _rb.velocity.y;
        if (Input.GetKeyDown("space")) {
            velo_y += force;
        }
        _rb.velocity = new Vector2(speed, velo_y);
    }
}
