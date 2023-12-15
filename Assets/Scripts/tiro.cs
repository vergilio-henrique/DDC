using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float destroyTime = 2f;

    private void Start()
    {
        // Inicia a contagem regressiva para destruir o tiro após um determinado tempo
        StartCoroutine(DestroyBulletAfterTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto atingido tem a tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Adicione aqui lógica adicional para o impacto no inimigo (som, efeitos, etc.)

            // Destroi o inimigo
            Destroy(other.gameObject);

            // Destroi o tiro
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Move o tiro em linha reta
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyBulletAfterTime()
    {
        // Aguarda um determinado tempo e depois destroi o tiro
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
