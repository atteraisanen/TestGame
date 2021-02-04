using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static bool isDead;
    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private Vector2 mov;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + mov * speed * Time.deltaTime);
    }

    private void Die()
    {
        isDead = true;
        gameManager.UpdateBestTime();
        gameManager.SaveGame();
        Debug.Log("You died");
        SceneManager.LoadScene("MainMenu");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Die();
        }
    }
}
