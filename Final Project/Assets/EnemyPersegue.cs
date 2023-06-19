using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersegue : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float chaseDistance = 10f;
    private Vector3 direita;
    private Vector3 esquerda;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direita = transform.localScale;
        esquerda = transform.localScale;
        esquerda.x = esquerda.x * -1;


        if (player == null)
        {
            Debug.LogError("Jogador não encontrado na cena!");
        }
    }

    void Update()
    {
        // Calcula a distância entre o inimigo e o jogador
        float distance = Vector3.Distance(transform.position, player.position);


        if (distance <= chaseDistance)
        {
            // Calcula a direção do jogador em relação ao inimigo
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move o inimigo na direção do jogador
            transform.position += direction * chaseSpeed * Time.deltaTime;


            if (direction.x > 0)
            {
                transform.localScale = direita;
            }
            else if (direction.x < 0)
            {
                transform.localScale = esquerda;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Pe"))
        {
            Destroy(gameObject);
            Debug.Log("Inimigo Morreu");
        }
    }
}
