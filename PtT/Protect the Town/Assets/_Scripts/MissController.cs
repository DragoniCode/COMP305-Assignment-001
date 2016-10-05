using UnityEngine;
using System.Collections;

public class MissController : MonoBehaviour {
    public GameController gameController;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            this.gameController.MissesValue -= 1;
        }
    }
}
