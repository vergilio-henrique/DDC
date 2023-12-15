using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 10f;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Gera uma posição aleatória dentro de um raio especificado
            Vector3 randomPosition = GetRandomPosition();

            // Instancia um inimigo na posição gerada
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Obtém a posição do spawner
        Vector3 spawnerPosition = transform.position;

        // Gera coordenadas aleatórias dentro do raio especificado
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);

        // Calcula a posição final adicionando as coordenadas aleatórias à posição do spawner
        Vector3 randomPosition = spawnerPosition + new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }
}
