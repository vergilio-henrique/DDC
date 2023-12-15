using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void Fire()
    {
        Vector3 shootDirection = transform.forward; // Direção para onde o jogador está olhando
        Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(shootDirection));

        // Adicione lógica adicional ao disparar (som, efeitos, etc.)
    }
}
