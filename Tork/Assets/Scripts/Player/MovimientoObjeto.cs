using UnityEngine;

namespace Emperor
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovimientoObjeto : MonoBehaviour
    {
        private ControladorAnimaciones controladorAnimaciones;
        public Vector3 desplazamientoJugador;

        private Transform transformPlayer;
        private Transform transformCamara;
        private Rigidbody rigidbodyPlayer;

        public float velocidadMovimiento;
        public float velocidadRotacion;
        public float fuerzaSalto;
        private float guardarvelocidadMovimiento;
        private float x, y;

        private bool saltando;

        private void Awake()
        {
            transformCamara = GetComponentInChildren<Camera>().transform;
        }

        private void Start()
        {
            controladorAnimaciones = GetComponent<ControladorAnimaciones>();
            transformPlayer = transform;
            rigidbodyPlayer = GetComponent<Rigidbody>();
            guardarvelocidadMovimiento = velocidadRotacion;
        }

        private void Update()
        {
            if (!controladorAnimaciones.PoderMoverse())
                return;

            MovimientoRigidbody();
            RotacionRigidbody();
            Saltar();
            MoverAnimator();
        }

        private void MoverAnimator()
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
                controladorAnimaciones.CorrerPlayer(y);
            else
                controladorAnimaciones.CaminarPlayer(x, y);
        }

        private void MovimientoRigidbody()
        {
            float velocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadMovimiento * 3f : velocidadMovimiento;
            desplazamientoJugador = ((transformPlayer.forward *
            Input.GetAxis("Vertical")) + (transformPlayer.right * Input.GetAxis("Horizontal"))) * velocidad;

            rigidbodyPlayer.MovePosition(transformPlayer.position + desplazamientoJugador);
        }

        private void RotacionRigidbody()
        {
            rigidbodyPlayer.MoveRotation(transformPlayer.rotation * Quaternion.Euler(0f, Input.GetAxis("Mouse X")
            * velocidadRotacion, 0f));

            transformCamara.localRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * -velocidadRotacion, 0f, 0f);

            velocidadRotacion = (transformCamara.localRotation.x >= 0.15f && Input.GetAxis("Mouse Y") < -0.1f)
             || (transformCamara.localRotation.x <= -0.09f && Input.GetAxis("Mouse Y") > 0.1f) ? 0 : guardarvelocidadMovimiento;
        }

        private void Saltar()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !saltando)
            {
                rigidbodyPlayer.AddForce(transformPlayer.up * fuerzaSalto);
                saltando = true;
            }
            if (saltando && Physics.Raycast(transform.position, -transform.up, 0.05f))
                saltando = false;
        }
    }
}