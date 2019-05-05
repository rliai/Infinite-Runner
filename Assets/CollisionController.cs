using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }
    //lose when hitting the blocks
    private void OnCollisionEnter2D(Collision2D other) {
        if (gm.game_start == false) return;
        if (other.transform.tag != "Player") return;
        gm.Lose();
    }
}
