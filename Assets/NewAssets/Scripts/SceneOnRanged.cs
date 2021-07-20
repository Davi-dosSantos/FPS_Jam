using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnRanged : MonoBehaviour
{

    public GameObject player;
    void Update()
    {
        if (player)
            if (Vector3.Distance(player.transform.position, transform.position) < 3)
            {
                SceneManager.LoadScene("WinScene");
            }
    }
    }