using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // PRIVATE 
    private int _missesValue;
    private int _scoreValue;
    private AudioSource _endGameSound;
    //Public

    public int enemyNumber = 3;
    public int enemyCount = 0;
    //Properties
    public int MissesValue
    {
        get
        {
            return this._missesValue;
        }

        set
        {
            this._missesValue = value;
            if (this._missesValue <= 0)
            {
                this._endGame();
            }
            else {
                this.Misses.text = "Lives: " + this._missesValue + "/5";
            }
        }
    }
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            if (this._scoreValue >= 100)
            {
                this._endGame();
            }
            else
            {
                this.Score.text = "Score: " + this._scoreValue + "/100";
            }
        }
    }


    [Header("UI Objects")]
    public Text Misses;
    public Text Score;
    public Text GameOver;
    public Text FinalScore;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemy;
    public GameObject gem;
    public GameObject bomb;
    //Methods
    // methods used to spawn objects
    public void Spawn()
    {
        Instantiate(this.enemy);
    }
    public void Lifepack()
        {
        Instantiate(this.gem);
}
    public void Incoming()
    {
        Instantiate(this.bomb);
    }
    public void RestartButton_Click()
    {
        
        SceneManager.LoadScene("Game");
    }
   
    // Use this for initialization
    void Start()
    {
        //reactivate/reset objects
        this.MissesValue = 5;
        this.ScoreValue = 0;
        this.enemy.SetActive(true);
        this.gem.SetActive(true);
        this.bomb.SetActive(true);
        this.GameOver.gameObject.SetActive(false);
        this.FinalScore.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

        this._endGameSound = this.GetComponent<AudioSource>();
        // Instatiates enemies at begining of game and repeats every set second(the last arg)
        
        InvokeRepeating("Spawn", 0.01f, 1f);
        InvokeRepeating("Incoming",5f, 10f);
        InvokeRepeating("Lifepack",30f, 30f);
        //if (enemyCount > enemyNumber)
        //{
        //    enemyCount = 0;
        //}
        //}
    }
	
	// Update is called once per frame
	void Update () {
      
        
    }
    private void _endGame()
    {
        this.GameOver.gameObject.SetActive(true);
        Debug.Log(this.ScoreValue);
        this.FinalScore.text = "Final Score: " + this.ScoreValue;
        this.FinalScore.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.Score.gameObject.SetActive(false);
        this.Misses.gameObject.SetActive(false);
        this.player.SetActive(false);
        this.enemy.SetActive(false);
        this.gem.SetActive(false);
        this.bomb.SetActive(false);
        this._endGameSound.Play();
    }
}
