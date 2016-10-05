using UnityEngine;
using System.Collections;

// reference to scene management
using UnityEngine.SceneManagement;

public class StartBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // PUBLIC METHODS
    public void StartButton_Click()
    {
        SceneManager.LoadScene("Game");
    }
}