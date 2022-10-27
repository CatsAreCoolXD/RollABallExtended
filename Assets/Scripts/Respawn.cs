using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    Rigidbody rb;
    public Vector3 respawnPos1;
    public Text liveText;
    public Text winText;
    public bool gameOver;

    private Vector3 respawnPos;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = respawnPos1;
        liveText.text = "Lives: 3";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -20f) {
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.position = respawnPos;
            lives -= 1;
            
        }
    }
    void Update() {
        if (!gameOver){
            if (lives != 0) {
                liveText.text = "Lives: " + lives;
            } else {
                liveText.text = "Lives: 0";
                winText.text = "Game Over!";
            }
        }
    }
}
