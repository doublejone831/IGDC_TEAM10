using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCScene : MonoBehaviour
{
    public GameObject Player;
    public GameObject spawn_Point;
    public bool isSpawn = true;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        spawn_Point = GameObject.FindGameObjectWithTag("Respawn");
        Player.transform.position = spawn_Point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
}
