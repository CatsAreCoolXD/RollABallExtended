using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ik heb "Count: " veranderd naar "Score: "

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public float groundDistance;
    public float jumpForce;
    public LayerMask GroundMask;
    public LayerMask LavaMask;
    public Respawn lives;
    public bool gameOver;

    private Rigidbody rb;
    private int count;
    private bool isGrounded;
    private bool isOnLava;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if (winText.text == "") {
			rb.AddForce (movement * speed);
		}
    }
    void Update(){
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, GroundMask);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        isOnLava = Physics.CheckSphere(transform.position, groundDistance, LavaMask);
        if (isOnLava){
            transform.position = new Vector3(0f, 0f, 0f);
            rb.velocity = new Vector3(0f, 0f, 0f);
            lives.lives -= 1;
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }
    }

    void SetCountText () {
        countText.text = "Score: " + count.ToString ();
        if (count >= 9) {
            winText.text = "You Win!";
            lives.gameOver = true;
        }
    }
}
