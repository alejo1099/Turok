using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Emperor;

public class Guerrero : MonoBehaviour
{
    private ControladorAnimaciones controladorAnimaciones;
    public Transform objetivo;

    private Transform miTransform;

    private void Awake()
    {
        miTransform = transform;
        controladorAnimaciones = GetComponent<ControladorAnimaciones>();
    }

    private void Update()
    {
        Atacar();
    }

    private void Atacar()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.LeftControl))
            CalcularMiradaEnemigo();
    }

    private void CalcularMiradaEnemigo()
    {
        Vector3 miVista = (objetivo.position - miTransform.position).normalized;
        Vector3 vistaObjetivo = objetivo.forward;
        miVista.y = vistaObjetivo.y = 0f;
        float angulo = Vector3.SignedAngle(miVista, vistaObjetivo, Vector3.up);

        float valorAtaque = DefinirAtaque(angulo);
        controladorAnimaciones.Atacar(valorAtaque);
    }

    private float DefinirAtaque(float angulo)
    {
        if (angulo < 36f && angulo > -36f)
            return 1F;
        else if (angulo < -36f && angulo > -108f)
            return 0.5f;
        else if (angulo > 36f && angulo < 108f)
            return -0.5f;
        else if (angulo > 108f && angulo < 180f)
            return -1f;
        else
            return 0f;
    }
}