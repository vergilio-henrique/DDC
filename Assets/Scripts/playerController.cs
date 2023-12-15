using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 8f;
    public float gravity = 20f;

    private CharacterController characterController;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Capturar entrada do teclado e mouse
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        // Mover o jogador
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 move = transform.TransformDirection(moveDirection) * speed;

        // Aplicar gravidade
        ApplyGravity();

        // Lidar com pulo
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2f * jumpForce * gravity);
            }
        }

        // Aplicar movimento horizontal
        characterController.Move(move * Time.deltaTime);

        // Aplicar movimento vertical (pulo e gravidade)
        characterController.Move(velocity * Time.deltaTime);

        // Rotacionar o jogador com base no movimento do mouse
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

        // Inclinar a câmera verticalmente com base no movimento do mouse
        Camera mainCamera = Camera.main;
        mainCamera.transform.Rotate(new Vector3(mouseY * mouseSensitivity, 0f, 0f));

        // Limitar a rotação vertical da câmera para evitar inversões
        float verticalRotation = mainCamera.transform.localEulerAngles.x;
        if (verticalRotation > 180f)
        {
            verticalRotation -= 360f;
        }
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        mainCamera.transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -gravity * Time.deltaTime; // Evitar acumulação de gravidade quando estiver no chão
        }
    }
}
