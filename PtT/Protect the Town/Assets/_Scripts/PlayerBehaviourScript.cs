using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    // public float jumpForce = 10.0f;
    public GameController gameController;
    public GameObject enemy;
    public GameObject gem;
    private Rigidbody2D rBody;
    private Animator anim;
    private SpriteRenderer spriteRend;

    //private PlayerSoundManager pSoundMan;

    //public bool isJumping = false;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //spriteRend = GetComponent<SpriteRenderer>();
        //pSoundMan = GetComponent<PlayerSoundManager>();
    }

    void Update()
    {
        //float movementJump = Input.GetAxis("Jump");

        //if (movementJump > 0.9f && !isJumping)
        //{
        //    rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //    isJumping = true;

        //    pSoundMan.PlayJumpAudio();
        //}

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //// HORIZONTAL MOVEMENT
        //if (moveHorizontal != 0.0f)
        //{
        //    if (moveHorizontal < 0.0f)
        //    {
        //        spriteRend.flipX = true;
        //    }
        //    else
        //    {
        //        spriteRend.flipX = false;
        //    }

        //    anim.SetBool("isWalking", true);
        //}
        //else
        //{
        //    anim.SetBool("isWalking", false);
        //}

        Vector2 movement = new Vector2(moveHorizontal * speed, rBody.velocity.y);
        rBody.velocity = movement;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag=="Enemy")
        {
            this.gameController.ScoreValue += 1;
        }

        if (other.gameObject.tag=="gem")
        {
            this.gameController.MissesValue += 1;
        }
        if (other.gameObject.tag=="bomb")
        {
            this.gameController.MissesValue -= 1;
        }
        //void OnCollisionEnter2D(Collision2D other)
        //{
        //    if (other.gameObject.tag == "Ground")
        //    {
        //        StartCoroutine(JumpDelay());
        //    }
        //}

        //IEnumerator JumpDelay()
        //{
        //    yield return new WaitForSeconds(0.05f);
        //    isJumping = false;
        //}
    }
}