using UnityEngine;

public class EstablecerPosicionCamara : MonoBehaviour
{

    public Transform posicionCamara;
    private Transform miPosicion;

    private void Awake()
    {
        miPosicion = transform;
    }

    private void Update()
    {
        miPosicion.position = posicionCamara.position;
    }
}
