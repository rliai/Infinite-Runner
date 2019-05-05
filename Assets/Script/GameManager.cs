using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float distance_between; //distance between blocks
    [SerializeField]
    private float upper_bound; //highest y value of blocks
    [SerializeField]
    private float lower_bound; //lowest y value of blocks
    [SerializeField]
    private GameObject start_ui; //start UI
    [SerializeField]
    private GameObject end_ui; //end UI
    [SerializeField]
    private Text text; //score text for end UI
    [SerializeField]
    private Text runtime_score; //runtime score UI

    
    private float score; //score
    
    private string orignial_text; //text "Score: "
    public Transform last_block; //the last block
    public Transform current_block; //the block "bird" just come in

    public GameObject block_prefab; //prefab for the block
    public bool game_start; //bool to control game start
    
    private void Awake() {
        game_start = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
        orignial_text = runtime_score.text;
               
    }

    // Update is called once per frame
    void Update()
    {
        //update score UI
        runtime_score.text = orignial_text + score;
        //before game start
        if (game_start == false) {
            if (Time.timeScale != 0) {
                Time.timeScale = 0;
            }
            return;
        }
        else {
            if (Time.timeScale == 0) {
                Time.timeScale = 1;
            }
        }
        // destroy the blocks
        if (current_block != null) {
            var block_list = GameObject.FindGameObjectsWithTag("Block");
            foreach (var obj in block_list) {
                if (current_block.position.x -  obj.transform.position.x > distance_between * 2f) {
                    Destroy(obj);
                }
            }
        }
        
    }
    //get the larger one
    private float max(float a, float b) {
        if (a < b) return b;
        else return a;
    }
    //get the smaller one
    private float min(float a, float b) {
        if (a < b) return a;
        else return b;
    }

    private float get_random() {
        float upp = min(last_block.position.y + 1f, upper_bound);
        float loww = max(last_block.position.y - 1f, lower_bound);
        
       
        return Random.Range(loww, upp);
    }

    //generate new blocks
    public void AddBlock() {
        //get a random number and not letting the difference too much for adjacent blocks
        float new_y = get_random();
        Vector3 new_pos = last_block.position + new Vector3(distance_between, 0, 0);
        new_pos.y = new_y;
        GameObject new_block = Instantiate(block_prefab, new_pos, Quaternion.identity);
        last_block = new_block.transform;
    }

    //lose, show UI

    public void Lose() {
        text.text = text.text + score;
        end_ui.SetActive(true);
        game_start = false;
    }

    //add score
    public void AddScore() {
        
        score++;
    }

    //after player hitting "start" button, game start
    public void onClickStart() {
        start_ui.SetActive(false);
        game_start = true;
    }

    //after player hitting restart button, restart the game
    public void Restart() {
        SceneManager.LoadScene("Main");
    }
    //after player hitting exit button, exit the game
    public void exit() {
        Application.Quit();
    }
}
