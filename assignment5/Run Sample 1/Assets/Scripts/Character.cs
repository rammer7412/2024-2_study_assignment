using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const float CharacterJumpPower = 7f;
    const int MaxJump = 2;
    int RemainJump = 0;
    GameManager GM;

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 RemainJump를 하나 소모하여 CharacterJumpPower의 힘으로 점프한다.
        // ---------- TODO ---------- 
        if (RemainJump > 0 && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            RemainJump--;
            Jump(CharacterJumpPower);
        }
        // -------------------- 
    }

    // Jump with power
    void Jump(float power)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, CharacterJumpPower, 0), ForceMode2D.Impulse);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Platform":
                RemainJump = MaxJump;
                break;
            case "Obstacle":
                GM.GameOver();
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Point":
                GM.GetPoint(1);
                Destroy(col.gameObject);
                break;
            default:
                break;
        }
    }
}
