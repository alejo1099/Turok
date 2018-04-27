using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDeGeneracion : MonoBehaviour
{
    public Transform player, objetivo;

    private Transform miTransform;

    private void Awake()
    {
        miTransform = transform;
    }

    private void Update()
    {
        Vector3 posicion = Vector3.Lerp(player.position, objetivo.position, 0.5f);
        posicion.y = 0;
        miTransform.position = posicion;
    }
}