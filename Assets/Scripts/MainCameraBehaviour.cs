using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBehaviour : MonoBehaviour
{
    public GameObject mainCamera;
    protected GameObject[] pauseObjects;
    public Vector3 initialPosition = new Vector3(0, 2, -15);
    protected Quaternion initialRotation = Quaternion.identity;

    protected Vector3 translationPosIncrement = new Vector3(1, 1, 1);
    protected Vector3 translationRotIncrement = new Vector3(2, 2, 2);

    protected bool shouldAdjustCamera = false;
    protected bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        // start the collision with 'SPACE' key:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldAdjustCamera = true;

            if (shouldAdjustCamera)
            {
                // move camera along a cool path: 
                //mainCamera.transform.Translate(translationPosIncrement);
                //mainCamera.transform.Rotate(translationRotIncrement);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        // reset to initial state with 'R' key:
        if (Input.GetKeyDown(KeyCode.R))
        {
            shouldAdjustCamera = false;
            Reset();
        }

        // quit application on escape:
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }

    /// <summary>
    /// Reset the game to the initial state
    /// </summary>
    protected virtual void Reset()
    {
        mainCamera.transform.position = initialPosition;
        mainCamera.transform.rotation = initialRotation;
        isPaused = false;
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(isPaused);
        }
    }

    /// <summary>
    /// stop time in the game for physics objects
    /// </summary>
    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(isPaused);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
