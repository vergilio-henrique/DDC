using System.Collections;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public Transform gunTransform;
    public Transform muzzleTransform;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public int magazineSize = 10;

    private int currentAmmo;
    private bool isShooting = false;

    private void Start()
    {
        currentAmmo = magazineSize;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting && currentAmmo > 0)
        {
            Shoot();
        }

        // Remova a lógica de recarregamento automático

        // Adicione a lógica de recarregamento manual
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magazineSize)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (gunTransform != null && muzzleTransform != null && bulletPrefab != null && currentAmmo > 0)
        {
            // Lógica de disparo
            Vector3 shootDirection = muzzleTransform.forward; // Direção para onde o jogador está olhando
            Instantiate(bulletPrefab, muzzleTransform.position, Quaternion.LookRotation(shootDirection));

            // Atualizar a quantidade de munição
            currentAmmo--;

            // Adicione lógica adicional ao disparar (som, efeitos, etc.)
        }
        else if (currentAmmo <= 0)
        {
            // Se sem munição, você pode adicionar lógica de recarregamento aqui
            Debug.Log("Sem munição! Recarregue manualmente (R).");
        }
        else
        {
            Debug.LogError("gunTransform, muzzleTransform, or bulletPrefab is null. Please assign the references in the Unity Editor.");
        }
    }

    private void Reload()
    {
        // Adicione lógica de recarregamento manual (animação, som, etc.)
        Debug.Log("Recarregando...");
        currentAmmo = magazineSize;
    }
}
