using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {
    //Privates
    private float _speed;
    private Transform _transform;
    // Publics
   

    public float Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }
    // Use this for initialization
    
    void Start () {
        this._transform = this.GetComponent<Transform>();

        this._reset();
    }
	
	// Update is called once per frame
	void Update () {
        this._move();
        this._checkBounds();
    }
    /**
	 * this method moves the game object down the screen by _speed px every frame
	 */
    private void _move()
    {
        Vector2 newPosition = this._transform.position;

        newPosition.y -= this._speed;

        this._transform.position = newPosition;
    }

    /**
	 * this method checks to see if the game object meets the top-border of the screen
	 */
    private void _checkBounds()
    {
        if (this._transform.position.y <= -4f)
        {
            this._reset();
        }
    }

    /**
	 * this method resets the game object to the original position
     and further radomizes along the y axis
	 */
    private void _reset()
    {
        this._speed = 0.1f;
        this._transform.position = new Vector2(Random.Range(-3.25f, 3.25f), 5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            Destroy(this.gameObject, 0.01f);        
        }
        
    }
    }

