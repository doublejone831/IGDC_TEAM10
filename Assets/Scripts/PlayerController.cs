using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody2D player;
    SpriteRenderer spriteRenderer;
    public float maxSpeed;
    public float ymax;
    Animator anim;

    public AudioClip audioMove;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;

    public PlayerData playerData;
    [ContextMenu("Into Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From File to game")]

    void LoadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }

    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "ITEM":
                audioSource.clip = audioItem;
                break;
            case "DIE":
                audioSource.clip = audioDie;
                break;
            case "FINISH":
                audioSource.clip = audioFinish;
                break;
            case "MOVE":
                audioSource.clip = audioMove;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonUp("Horizontal")) //Stop
        {
            player.velocity = new Vector2(player.velocity.normalized.x * 0.5f, player.velocity.y);
            PlaySound("MOVE");
            audioSource.Play();
        }
        if (Input.GetButtonUp("Vertical")) //Stop
        {
            player.velocity = new Vector2(player.velocity.normalized.x, player.velocity.y * 0.5f);
            PlaySound("MOVE");
            audioSource.Play();
        }

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }



    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(player.velocity.x) < 0.3f)//Parameter change
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        if (Mathf.Abs(player.velocity.y) >= 0.3f)
        {
            anim.SetBool("isWalking", true);
        }

        float rmove = Input.GetAxisRaw("Horizontal");
        float umove = Input.GetAxisRaw("Vertical");

        player.AddForce(Vector2.right * rmove, ForceMode2D.Impulse);
        player.AddForce(Vector2.up * umove, ForceMode2D.Impulse);

        if (player.velocity.x > maxSpeed)
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        else if (player.velocity.x < maxSpeed * (-1))
            player.velocity = new Vector2(maxSpeed * (-1), player.velocity.y);

        if (player.velocity.y > ymax)
        {
            player.velocity = new Vector2(player.velocity.x, ymax);
        }
        else if (player.velocity.y < ymax * (-1))
        {
            player.velocity = new Vector2(player.velocity.x, ymax * (-1));
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public string itemcode;
}