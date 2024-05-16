using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class grapplingHook : MonoBehaviour {

    LineRenderer line;
    Rigidbody2D rb;
    BoxCollider2D box;
    PlayerMovement pm;

    [HideInInspector] public bool retracting = false;
    [SerializeField] LayerMask grappleableMask;
    [SerializeField] float maxDistance = 4f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 5000f;
    [SerializeField] AudioSource toungeSoundEffect;

    private float mouseY;
    public bool isGrapppling = false;
    public bool inWall = false;
    private bool mouseFloor = false;
    private float popHeight = 5f;
    //wall that you can't clip through
    public bool inCWall = false;


    Vector2 target;

    private void Start() {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        pm = GetComponent<PlayerMovement>();
    }


    private void Awake() {
        toungeSoundEffect.volume = PlayerPrefs.GetFloat("SFX");
    }




    private void Update() {

        mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;


        if (Input.GetMouseButtonDown(0) && !isGrapppling) {
            if(mouseY < transform.position.y) {
                mouseFloor = true;
            } else {
                mouseFloor = false;
            }
            StartGrapple();
        }

        if (retracting) {

            if (inCWall) {
                Debug.Log("In c Wall");
                retracting = false;
                pm.canMove = true;
                isGrapppling = false;
                line.enabled = false;
                box.isTrigger = false;
                rb.gravityScale = 2f;
                Invoke("NormalGravity", 1f);
            }
            if((Math.Abs(mouseY - transform.position.y) < .5f)) {
                retracting = false;
                pm.canMove = true;
                isGrapppling = false;
                line.enabled = false;
                box.isTrigger = false;
                rb.gravityScale = 2f;
                Invoke("NormalGravity", 1f);
            }


            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
            
            
            transform.position = grapplePos;
            

            line.SetPosition(0, transform.position);



            
            

                //checks how far you can be for the grapple to let go of you
            if (Vector2.Distance(transform.position, target) < .6f) {
                retracting = false;
                isGrapppling = false;
                line.enabled = false;
                if (inWall) {   
                    rb.velocity = new Vector2(-1 * rb.velocity.x, popHeight);
                    Invoke("InWall", .05f);
                } else {
                    box.isTrigger = false;
                }
                pm.canMove = true;
                rb.gravityScale = 2f;
                Invoke("NormalGravity", 1f);

            }
        }
        
    }

    private void StartGrapple() {

        

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grappleableMask);

        if(hit.collider != null) { 
            isGrapppling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());

        }
    }

    IEnumerator Grapple() {
        float t = 0;
        float time = 10;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;
        toungeSoundEffect.Play();

        for (; t < time; t += grappleShootSpeed * Time.deltaTime) {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            yield return null;
        }

        //latched onto target
        pm.canMove = false;
        line.SetPosition(1, target);
        retracting = true;
        if (mouseFloor) {
            box.isTrigger = false;  
        } else {
            box.isTrigger = true;
        }
        if (inCWall) {
            box.isTrigger = false;
        }
        rb.gravityScale = 0;
    }

    private void NormalGravity() {
        rb.gravityScale = 3;        
    }

    private void InWall() {
        box.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Terrain")) {
            inWall = true;
        }
        if (collision.gameObject.CompareTag("NonClippable")) {
            inCWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Terrain")) {
            inWall = false;
        }
        if (collision.gameObject.CompareTag("NonClippable")) {
            inCWall = false;
        }
    }
}
