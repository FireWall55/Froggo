using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;
    private LineRenderer lr;
    public bool canMove = true;
    grapplingHook gh;



    [SerializeField] LayerMask grappleableMask;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] float maxRayDistance;
    private float dirX = 0f;
    private float moveSpeed = 10f;
    private enum MovementState { idle, running, jumping, falling }

    private void Awake() {
        jumpSoundEffect.volume = PlayerPrefs.GetFloat("SFX");
    }

    // Start is called before the first frame update
    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gh = GetComponent<grapplingHook>();
        lr = GetComponent<LineRenderer>();
        if (PlayerPrefs.GetInt("tounge") == 1) {
            lr.startWidth = 1f;
            lr.endWidth = 1f;
        }
        if (PlayerPrefs.GetInt("speed") == 1) {
            moveSpeed = 25;
        }
    }
    private void FixedUpdate() {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && !(rigidBody.velocity.y > .01) && !(rigidBody.velocity.y < -.01)) {

            jumpSoundEffect.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }


    // Update is called once per frame
    private void Update() {

        dirX = Input.GetAxis("Horizontal");


        //in you click jump #1 jump and check if you can jump again
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && !(rigidBody.velocity.y > .01) && !(rigidBody.velocity.y < -.01) && canMove) {

            jumpSoundEffect.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }



        if (!gh.retracting && canMove) {

            rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);
        } else {

            rigidBody.velocity = Vector2.zero;
        }



        UpdateAnimationState();


        if (Input.GetKeyDown(KeyCode.R)) {
            RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.R) && (Input.GetKey(KeyCode.LeftControl))) {
            StartOver();
        }

    }

    private void UpdateAnimationState() {

        MovementState state;


        if (dirX > 0f) {

            state = MovementState.running;
            sprite.flipX = false;

        } else if (dirX < 0f) {

            state = MovementState.running;
            sprite.flipX = true;

        } else {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > .1f) {
            state = MovementState.jumping;
        } else if (rigidBody.velocity.y < -.1f) {
            state = MovementState.falling;
        }


        animator.SetInteger("state", (int)state);
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartOver() {
        PlayerPrefs.SetInt("melons", 0);
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }


    

}



    
