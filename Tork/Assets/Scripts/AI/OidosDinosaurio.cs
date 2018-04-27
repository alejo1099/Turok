using UnityEngine;
using System;
using Emperor;

namespace Turok
{
    public class OidosDinosaurio : MonoBehaviour
    {
        public Action<Transform> OnFoundObject;
        public float radioOido;

        private float tasaDeActualizacion = 0.2f;
        private float tiempoAcumulado;

        private LayerMask capaPlayer = 1 << 8;
        private Transform miTransform;

        private void Awake()
        {
            miTransform = transform;
        }

        public void OirEntorno()
        {
            if (Time.time > tiempoAcumulado)
            {
                tiempoAcumulado = Time.time + tasaDeActualizacion;
                Collider[] objetosOidos = Physics.OverlapSphere(miTransform.position, radioOido, capaPlayer, QueryTriggerInteraction.Ignore);
                for (int i = 0; i < objetosOidos.Length; i++)
                {
                    if (objetosOidos[i].GetComponent<MovimientoObjeto>() != null)
                    {
                        MovimientoObjeto movimientoObjeto = objetosOidos[i].GetComponent<MovimientoObjeto>();
                        if (movimientoObjeto.desplazamientoJugador.magnitude > 0.2f)
                            OnFoundObject(objetosOidos[i].transform);
                    }
                }
            }
        }
    }
}