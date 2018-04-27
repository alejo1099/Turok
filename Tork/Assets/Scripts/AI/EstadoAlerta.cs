using UnityEngine;
using UnityEngine.AI;

namespace Turok
{
    public class EstadoAlerta : Estado
    {
        protected override void Awake()
        {
            base.Awake();
            controladorAnimaciones = GetComponent<ControladorAnimacionesDinosaurio>();
        }

        private void OnEnable()
        {
            agenteDinosaurio.destination = miTransform.position;
        }

        private void Update()
        {
            GirarAlObjetivo();
            controladorAnimaciones.Caminar(agenteDinosaurio.velocity);
        }

        private void GirarAlObjetivo()
        {
            Vector3 direccionObjetivo = (objetivo.position - miTransform.position).normalized;
            direccionObjetivo.y = miTransform.position.y;
            Quaternion rotacionRelativa = Quaternion.LookRotation(direccionObjetivo, Vector3.up);
            miTransform.rotation = Quaternion.Slerp(miTransform.rotation, rotacionRelativa, Time.deltaTime);
        }
    }
}