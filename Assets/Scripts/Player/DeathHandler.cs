using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath();
    }

    private void PlayerDeath()
    {
        if (GetComponent<PlayerHealth>().GetHealth() <= 0)
        {
            GameOverCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
