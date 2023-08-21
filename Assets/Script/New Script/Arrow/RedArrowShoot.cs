using UnityEngine;

public class RedArrowShoot : MonoBehaviour
{
    [SerializeField]private float speed;
    private bool hit;

    private BoxCollider2D boxCollider2D;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        //float movementSpeed
    }
}
