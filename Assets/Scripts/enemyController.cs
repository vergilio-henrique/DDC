using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Transform player;

    void Start()
    {
        // Encontrar o jogador na cena pelo nome (ou você pode atribuir o jogador de outra maneira)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Movimento e rotação em direção ao jogador
            MoveAndRotateTowardsPlayer();
        }
    }

    void MoveAndRotateTowardsPlayer()
    {
        // Calcula a direção para o jogador
        Vector3 directionToPlayer = player.position - transform.position;

        // Normaliza a direção para ter um comprimento de 1, para que o movimento seja suave
        directionToPlayer.Normalize();

        // Move o inimigo na direção do jogador
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);

        // Calcula a rotação necessária para olhar na direção do jogador
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Suaviza a rotação
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
