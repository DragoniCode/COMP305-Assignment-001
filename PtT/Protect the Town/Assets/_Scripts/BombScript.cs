using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
    //Bombs remove life points when player connects with it
    //    (they self destroy themselves after a time)
    private float _speed;
  
    private Transform _transform;
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
        Destroy(this.gameObject, 2f);
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

        newPosition.y -= this.Speed;

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
        this.Speed = 0.1f;
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

