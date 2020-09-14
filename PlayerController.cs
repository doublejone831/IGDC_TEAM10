using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    public float maxSpeed;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        pos = this.player.transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        player.AddForce(Vector2.right * moveHorizontal, ForceMode2D.Impulse);
        player.AddForce(Vector2.up * moveVertical, ForceMode2D.Impulse);

        if(player.velocity.x>maxSpeed)
        {
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        }
        else if (player.velocity.x < maxSpeed * (-1))
            player.velocity = new Vector2(maxSpeed * (-1), player.velocity.y);

        if (player.velocity.y > maxSpeed)
        {
            player.velocity = new Vector2(player.velocity.x, maxSpeed);
        }
        else if (player.velocity.y < maxSpeed * (-1))
        {
            player.velocity = new Vector2(player.velocity.x, maxSpeed * (-1));
        }

        if (player.transform.position.y > -4)
        {
            player.transform.position = new Vector3(pos.x, pos.y, -1);
        }
        if (player.transform.position.y < -4)
        {
            player.transform.position = new Vector3(pos.x, pos.y, -3);
        }
    }
}
