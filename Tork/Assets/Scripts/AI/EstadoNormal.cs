using UnityEngine;
using UnityEngine.AI;

namespace Turok
{
    public class EstadoNormal : Estado
    {
        public Transform target;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            ojos.OnFoundObject += CambiarEstadoOjos;
            oidos.OnFoundObject += CambiarEstadoOidos;
        }

        private void Update()
        {
            ActualizarDestino();
        }

        private void ActualizarDestino()
        {
            agenteDinosaurio.destination = target.position;
            controladorAnimaciones.Caminar(agenteDinosaurio.velocity);
            ojos.VerEntorno();
            oidos.OirEntorno();
        }

        private void CambiarEstadoOjos(Transform objetivoActual)
        {
            OnChangedState(EstadosDinosaurio.Persecucion, objetivoActual);
        }

        private void CambiarEstadoOidos(Transform objetivoActual)
        {
            OnChangedState(EstadosDinosaurio.Alerta, objetivoActual);
        }

        private void OnDisable()
        {
            ojos.OnFoundObject -= CambiarEstadoOjos;
            oidos.OnFoundObject -= CambiarEstadoOidos;
        }
    }
}