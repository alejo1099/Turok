using System;
using UnityEngine;
using UnityEngine.AI;

namespace Turok
{
    public class Estado : MonoBehaviour
    {
        public Action<EstadosDinosaurio, Transform> OnChangedState;

        protected ControladorAnimacionesDinosaurio controladorAnimaciones;
        protected OjosDinosaurio ojos;
        protected OidosDinosaurio oidos;
        public Transform objetivo;
        protected Transform miTransform;
        protected NavMeshAgent agenteDinosaurio;

        protected virtual void Awake()
        {
            miTransform = transform;
            agenteDinosaurio = GetComponent<NavMeshAgent>();
            controladorAnimaciones = GetComponent<ControladorAnimacionesDinosaurio>();
            ojos = GetComponent<OjosDinosaurio>();
            oidos = GetComponent<OidosDinosaurio>();
        }
    }
}