using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    //Reference ot the game manager.
    public GameManager gameManager;

    public enum GameState
    {
        MainMenu_State,
        Gameplay_State,
        Options_State,
        Pause_State
    }

    public GameState currentState { get; private set; }

    //Stores last state as a string.
    [SerializeField] private string currentStateDebug;
    //Store last value as a string.
    [SerializeField] private string lastStateDebug;

    //Start method that calls te main menu at the start of the game.
    private void Start()
    {

        ChangeStateToMainMenu();
    }

    //The change state method 
    public void ChangeState(GameState newState)
    {
        lastStateDebug = currentState.ToString();

        currentState = newState;

        HandleStateChange(newState);

        currentStateDebug = currentState.ToString();
    }

    //Method that changes the game state back to the main menu.
    public void ChangeStateToMainMenu()
    {
        ChangeState(GameState.MainMenu_State);

    }

    //The method for changing the state of the game to the gameplay.
    public void ChangeStateToGameplay()
    {
        ChangeState(GameState.Gameplay_State);
    }
    //Method for changing the state to the pause menu.
    public void ChangeStateToPause()
    {
        ChangeState(GameState.Pause_State);
    }
    //ethod for changing the state to the options menu.
    public void ChangeStateToOptions()
    {
        ChangeState(GameState.Options_State);
    }

    //Update method for changing game states.
    private void Update()
    {

        //If and else if statements for changing the states of the game.
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Gameplay_State)
        {
            Debug.Log("Changed to Pause");

            ChangeStateToPause();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Pause_State)
        {
            Debug.Log("Changed to Gameplay");
            ChangeStateToGameplay();
        }

    }

    //Method for handling all the state changes.
    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                {
                    Debug.Log("Main Menu State");
                    Time.timeScale = 0.0f;
                    gameManager.uIManager.MainMenuUI();
                    break;
                }
            case GameState.Gameplay_State:
                {
                    Debug.Log("In Gameplay State");
                    Time.timeScale = 1.0f;
                    gameManager.uIManager.GameplayUI();
                    break;
                }
            case GameState.Pause_State:
                {
                    Debug.Log("In Paused State");
                    Time.timeScale = 0.0f;
                    gameManager.uIManager.PausedUI();
                    break;
                }
            case GameState.Options_State:
                {
                    Debug.Log("In Options State");
                    Time.timeScale = 0.0f;
                    gameManager.uIManager.OptionsUI();
                    break;
                }

        }
    }

    //Method for quitting the application.
    public void Quit()
    {
        Application.Quit();
    }
}
