using UnityEngine;

public class ControladorAnimaciones : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo animatorState;

    private int atackTohash = Animator.StringToHash("Atacar");
    private int varX = Animator.StringToHash("x");
    private int varY = Animator.StringToHash("y");
    private int valorAtaque = Animator.StringToHash("Ataque");
    private int correr = Animator.StringToHash("Correr");

    private int tagMover = Animator.StringToHash("Movimiento");
    private int tagAtacar = Animator.StringToHash("Atacando");

    private bool corriendo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool PoderMoverse()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.tagHash == tagMover)
            return true;
        else
            return false;
    }

    public bool PoderAtacar()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.tagHash != tagAtacar)
            return true;
        else
            return false;
    }

    public void Atacar(float valorAtaque)
    {
        animator.SetFloat(this.valorAtaque, valorAtaque);
        animator.SetTrigger(atackTohash);
    }

    public void CaminarPlayer(float x, float y)
    {
        if (corriendo)
        {
            animator.SetBool(correr, false);
            corriendo = false;
        }
        animator.SetFloat(varX, x);
        animator.SetFloat(varY, y);
    }

    public void CorrerPlayer(float y)
    {
        if (!corriendo)
        {
            animator.SetBool(correr, true);
            corriendo = true;
        }
        animator.SetFloat(varY, y);
    }
}