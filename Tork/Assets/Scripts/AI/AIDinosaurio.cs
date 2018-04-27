using UnityEngine;

namespace Turok
{
    public enum EstadosDinosaurio
    {
        Normal, Alerta, Persecucion
    }
    public class AIDinosaurio : MonoBehaviour
    {

        //El dinosaurio contara con 2 detectores, el cual sera uno visual, y otro por sonido, el visual se activara si el jugador esta por delante del dinosaurio
        //El detector por sonido se activara si el jugador corre, y esta dentro del rango de un sphere trigger

        //El dinosaurio tendra un estado de caminar, (por ahora solo caminara en una direccion aleatoria que seria adelante en el bosque)
        //En este estado sigue un objetivo(algo asi como un objeto pegado que mantiene cierte distancia a éste). Para que siempre avance 
        //el dinosaurio, se utilizara un plano procedural, donde siempre se generen nuevos arboles

        //Si encuentra algun alimento como un cerdo muerto(si lo ve) entonces se acercara y se lo comera, luego seguira su camino

        //En cualquier estado si ve a un enemigo entonces se girara hacia él , pero es bueno tener una variable de "ver" donde actualice el objetivo si no hay obstaculos, entre los 2

        //Si el jugador golpea al dinosaurio, este gritara, si lo golpea por enfrente, retrocedera un poco,, y luego avanzara corriendo
        //si lo golpea por atras, gritara y se alejara un poco del jugador, cuando pase cierta distancia, se girara y correra contra el jugador

        //Si el dinosaurio pierde al jugador, entonces se quedara un rato dando vueltas, y luego seguira su camino

        private Estado estadoAlerta;
        private Estado estadoNormal;
        private Estado estadoPersecucion;

        private Estado estadoActual;

        private void Awake()
        {
            estadoAlerta = GetComponent<EstadoAlerta>();
            estadoNormal = GetComponent<EstadoNormal>();
            estadoPersecucion = GetComponent<EstadoPersecusion>();
            AsignarAction();
            estadoActual = estadoNormal;
        }

        private void AsignarAction()
        {
            estadoAlerta.OnChangedState += EvaluarEstadoActual;
            estadoNormal.OnChangedState += EvaluarEstadoActual;
            estadoPersecucion.OnChangedState += EvaluarEstadoActual;
        }

        private void EvaluarEstadoActual(EstadosDinosaurio estadoEnumActual, Transform objetivo)
        {
            switch (estadoEnumActual)
            {
                case EstadosDinosaurio.Normal:
                    estadoActual.enabled = false;
                    estadoActual = estadoNormal;
                    estadoActual.enabled = true;
                    estadoActual.objetivo = objetivo;
                    break;
                case EstadosDinosaurio.Alerta:
                    estadoActual.enabled = false;
                    estadoActual = estadoAlerta;
                    estadoActual.enabled = true;
                    estadoActual.objetivo = objetivo;
                    break;
                case EstadosDinosaurio.Persecucion:
                    estadoActual.enabled = false;
                    estadoActual = estadoPersecucion;
                    estadoActual.enabled = true;
                    estadoActual.objetivo = objetivo;
                    break;
            }
        }
    }
}