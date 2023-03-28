using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50;
    public float rotateSpeed = 25;
    public Rigidbody rb;
    public bool isGrounded;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Animator animator;
    public Animator berryanimator;
    public TextMeshProUGUI playerScoreText;
    float playerScore=0;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        playerScoreText.text =  playerScore.ToString()+ " Strawberrys eaten :3";
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);

        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            animator.SetTrigger("catEmote");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) {
            Debug.Log("Berry Got");
            berryanimator.SetTrigger("spriteTrigger");
            Destroy(other.gameObject);
            playerScore ++;
            playerScoreText.text =  playerScore.ToString()+ " Strawberrys eaten :3";

        }
    }
}