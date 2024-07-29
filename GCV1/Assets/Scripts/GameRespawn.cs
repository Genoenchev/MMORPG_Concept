using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Health health;
    public GameObject player;
    public GameObject respawn;
    [field: SerializeField] public InputReader InputReader { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool checker = false;
        if (InputReader != null)
        {
            checker = InputReader.IsMenuOpen;
        }
        if (checker) //when true
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        player.transform.position = respawn.transform.position;
        health.health = 100;
    }
}
