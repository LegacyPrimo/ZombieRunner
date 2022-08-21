using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float currentHealth;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void CheckHealth(float damageTaken) 
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.ShowGameOverCanvas();
        }
    }
}
