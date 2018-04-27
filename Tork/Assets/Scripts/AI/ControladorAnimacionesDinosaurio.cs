using UnityEngine;

namespace Turok
{
    public class ControladorAnimacionesDinosaurio : MonoBehaviour
    {

        private Animator animator;

        private int caminar = Animator.StringToHash("Caminar");
        private int correr = Animator.StringToHash("Correr");
        private bool moviendose;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Caminar(Vector3 velocidad)
        {
            if (!moviendose && velocidad.magnitude >= 0.85f)
            {
                animator.SetBool(caminar, true);
                moviendose = true;
            }
            else if (moviendose && velocidad.magnitude < 0.85f)
            {
                animator.SetBool(caminar, false);
                moviendose = false;
            }
        }
    }
}