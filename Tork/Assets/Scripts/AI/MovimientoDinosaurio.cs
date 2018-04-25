using UnityEngine;
using UnityEngine.AI;

public class MovimientoDinosaurio : MonoBehaviour
{
    private NavMeshAgent agente;
    private Animator animator;

    private int caminar = Animator.StringToHash("Caminar");
    private int correr = Animator.StringToHash("Correr");
    private bool moviendose;

    public Transform target;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        agente.destination = target.position;
        ActualizarAnimator();
    }

    private void ActualizarAnimator()
    {
        if (!moviendose && agente.velocity.magnitude >= 0.85f)
        {
            animator.SetBool(caminar, true);
            moviendose = true;
        }
        else if (moviendose && agente.velocity.magnitude < 0.85f)
        {
            animator.SetBool(caminar, false);
            moviendose = false;
        }

    }
}