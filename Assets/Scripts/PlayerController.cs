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

    public PlayerData playerData;
    [ContextMenu("Into Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    //데이터 저장코드, 아직 진행중이고, 활용 못하는 단계
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
            case "MOVE":
                audioSource.clip = audioMove;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //멈출 시 사운드 멈추기
        if (Mathf.Abs(player.velocity.x) <= 0.3 && (Mathf.Abs(player.velocity.y) <= 0.3))
            audioSource.Stop();
        
        if (Input.GetButtonUp("Horizontal")) //Stop
        {
            player.velocity = new Vector2(player.velocity.normalized.x * 0.5f, player.velocity.y);                
        }
        if (Input.GetButtonUp("Vertical")) //Stop
        {
            player.velocity = new Vector2(player.velocity.normalized.x, player.velocity.y * 0.5f);              
        }

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }
    //수평키 입력시 x축 방향 flip = 뒤집기
        
        



    }

    private void FixedUpdate()
    {
        
        //walk sound on
        if (Input.GetButtonDown("Horizontal"))
        {
            PlaySound("MOVE");
            audioSource.Play();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            PlaySound("MOVE");
            audioSource.Play();
        }
       

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