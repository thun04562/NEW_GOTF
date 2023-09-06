using UnityEngine;

// Define an interface for all arrow types.
public interface IArrow
{
    void Shoot();
}

public class RedArrow : MonoBehaviour, IArrow
{
    public GameObject arrowPrefab;

    public void Shoot()
    {
        // Implement shooting behavior for the Red Arrow.
        // Instantiate and shoot the Red Arrow.
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        // Add force or velocity to move the Red Arrow in the desired direction.
    }
}

public class GreenArrow : MonoBehaviour, IArrow
{
    public GameObject arrowPrefab;

    public void Shoot()
    {
        // Implement shooting behavior for the Green Arrow.
        // Instantiate and shoot the Green Arrow.
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        // Add force or velocity to move the Green Arrow in the desired direction.
    }
}

public class BlueArrow : MonoBehaviour, IArrow
{
    public GameObject arrowPrefab;

    public void Shoot()
    {
        // Implement shooting behavior for the Blue Arrow.
        // Instantiate and shoot the Blue Arrow.
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        // Add force or velocity to move the Blue Arrow in the desired direction.
    }
}

public class YellowArrow : MonoBehaviour, IArrow
{
    public GameObject arrowPrefab;

    public void Shoot()
    {
        // Implement shooting behavior for the Yellow Arrow.
        // Instantiate and shoot the Yellow Arrow.
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        // Add force or velocity to move the Yellow Arrow in the desired direction.
    }
}
