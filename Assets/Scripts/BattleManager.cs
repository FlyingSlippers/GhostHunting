using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject battlePanel;
    public GameObject enemyPanel;

    public Camera mainCamera;
    public Camera battleCamera;

    public PlayerMovement playerMovement;

    void Start()
    {
        battlePanel.SetActive(false);
        enemyPanel.SetActive(false);

        mainCamera.enabled = true;
        battleCamera.enabled = false;
    }

    public void StartBattle()
    {
        battlePanel.SetActive(true);

        mainCamera.enabled = false;
        battleCamera.enabled = true;

        playerMovement.enabled = false;
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
    }

    public void Surrender()
    {
        battlePanel.SetActive(false);
        enemyPanel.SetActive(true);
    }

    public void EndBattle()
    {
        enemyPanel.SetActive(false);

        mainCamera.enabled = true;
        battleCamera.enabled = false;

        playerMovement.enabled = true;
         Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    }
}