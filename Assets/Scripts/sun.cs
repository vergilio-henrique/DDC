using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float dayDuration = 10f; // Duração de um dia em segundos

    public Color dayColor = Color.white; // Cor da luz do sol durante o dia
    public Color nightColor = Color.black; // Cor da luz do sol durante a noite

    private float elapsedTime = 0f;
    private bool isDay = true;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > dayDuration)
        {
            isDay = !isDay;
            elapsedTime = 0f;
        }

        if (isDay)
        {
            // Defina a intensidade e a cor da luz do sol para representar o dia
            sun.intensity = 1f;
            sun.color = dayColor;
        }
        else
        {
            // Defina a intensidade e a cor da luz do sol para representar a noite
            sun.intensity = 0.1f;
            sun.color = nightColor;
        }

        // Rotação do sol para simular o ciclo dia e noite
        float rotationSpeed = 360f / dayDuration; // Velocidade de rotação em graus por segundo
        sun.transform.rotation = Quaternion.Euler(rotationSpeed * elapsedTime, 0f, 0f);
    }
}
