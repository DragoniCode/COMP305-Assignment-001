using UnityEngine;
using System.Collections;

public class RoadBehaviourScript : MonoBehaviour
{
    // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++
    private float _speed;
    private Transform _transform;

    // PUBLIC PROPERTIES
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
    void Start()
    {
        this._transform = this.GetComponent<Transform>();

        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (this._transform.position.y <= -9f)
        {
            this._reset();
        }
    }

    /**
	 * this method resets the game object to the original position
	 */
    private void _reset()
    {
        this._speed = 0.1f;
        this._transform.position = new Vector2(0f, -1f);
    }
}
