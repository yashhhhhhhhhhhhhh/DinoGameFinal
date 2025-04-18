using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayShakeAnimation()
    {
        anim.Play("CactusShake");
    }
}
