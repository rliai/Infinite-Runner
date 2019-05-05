using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private GameManager gm;
    private AudioSource aud;
    private void Start() {
        gm = GameObject.FindObjectOfType<GameManager>();
        aud = GetComponent<AudioSource>();
    }
    //when the "bird" moves in to the blank space between blocks (generate new blocks off-screen)
    private void OnTriggerEnter2D(Collider2D other) {
        if (gm.game_start == false) return;
    
        if (other.tag != "Player") return;
        
        gm.current_block = transform.parent;
        gm.AddBlock();
    }
    //when the "bird" moves out of the blank space between blocks (add score)
    private void OnTriggerExit2D(Collider2D other) {
        if (gm.game_start == false) return;
        if (other.tag != "Player") return;
        aud.Play();
        gm.AddScore();
    }
}
