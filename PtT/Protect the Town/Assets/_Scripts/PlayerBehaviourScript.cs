using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public GameController gameController;
    public GameObject enemy;
    public GameObject gem;
    private Rigidbody2D rBody;


    [Header("Sounds")]
    public AudioSource bump;
    public AudioSource coin;
    public AudioSource pwrup;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //// HORIZONTAL MOVEMENT
       
        Vector2 movement = new Vector2(moveHorizontal * speed, rBody.velocity.y);
        rBody.velocity = movement;
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag=="Enemy")
        {
            this.coin.Play();
            this.gameController.ScoreValue += 1;
        }

        if (other.gameObject.tag=="gem")
        {
            this.pwrup.Play();
            this.gameController.MissesValue += 1;
        }
        if (other.gameObject.tag=="bomb")
        {
            this.bump.Play();
            this.gameController.MissesValue -= 1;
        }
        
    }
}