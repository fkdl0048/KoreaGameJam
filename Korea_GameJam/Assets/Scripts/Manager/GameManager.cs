using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    
    // Test
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCamera.transform.rotation = Quaternion.Euler(0, -30, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mainCamera.transform.rotation = Quaternion.Euler(0, 30, 0);
        }
    }
}
