using UnityEngine;
using UnityEngine.AI;

namespace Turok
{
    public class EstadoAlerta : Estado
    {
        private float interpolcaion;

        private Vector3 posicionVer;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            agenteDinosaurio.destination = miTransform.position;
            posicionVer = objetivo.position;
            ojos.OnFoundObject += CambiarEstadoOjos;
            oidos.OnFoundObject += CambiarEstadoOidos;
        }

        private void Update()
        {
            GirarAlObjetivo();
        }

        private void GirarAlObjetivo()
        {
            Interpolar();
            controladorAnimaciones.Caminar(agenteDinosaurio.velocity);
            ojos.VerEntorno();
            oidos.OirEntorno();
        }

        private void Interpolar()
        {
            Vector3 direccionObjetivo = (posicionVer - miTransform.position).normalized;
            direccionObjetivo.y = miTransform.position.y;
            Quaternion rotacionRelativa = Quaternion.LookRotation(direccionObjetivo, Vector3.up);
            miTransform.rotation = Quaternion.Slerp(miTransform.rotation, rotacionRelativa, Time.deltaTime);
        }

        private void CambiarEstadoOjos(Transform objetivo)
        {
            OnChangedState(EstadosDinosaurio.Persecucion, objetivo);
        }

        private void CambiarEstadoOidos(Transform objetivo)
        {
            posicionVer = objetivo.position;
        }

        private void OnDisable()
        {
            ojos.OnFoundObject -= CambiarEstadoOjos;
            oidos.OnFoundObject -= CambiarEstadoOidos;
        }
    }
}