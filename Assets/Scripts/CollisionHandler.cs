using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("This is Start point");
                break;
            case "Finish":
                Debug.Log("This is Finish point");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                Debug.Log("You hit the obstacle/ground");
                StartCrashSequence();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // retrieves the build index of the currently active scene and stores it in the variable currentSceneIndex
        SceneManager.LoadScene(currentSceneIndex); // reloads the current scene using its build index
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // retrieves the build index of the currently active scene and stores it in the variable currentSceneIndex
        int nextSceneIndex = currentSceneIndex + 1; // calculates the build index of the next scene by adding 1 to the current scene's build index
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // checks if the next scene index is equal to the total number of scenes in the build settings, indicating it's out of bounds
        {
            nextSceneIndex = 0; // resets the next scene index to 0 if the current index is out of bounds, looping back to the first scene
        }
        SceneManager.LoadScene(nextSceneIndex); // loads the next scene using its build index
    }

    void StartSuccessSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
}