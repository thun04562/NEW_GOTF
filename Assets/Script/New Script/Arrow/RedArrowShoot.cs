using UnityEngine;

public class RedArrowShoot : MonoBehaviour
{
    /*[SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return; // Ignore triggers and enemies

        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        /*hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");*/
    /*}
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }*/
    private void Deactivate()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
