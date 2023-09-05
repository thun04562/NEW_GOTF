using UnityEngine;

public class IncreaseGravity : MonoBehaviour
{
    public float customGravity = -20f; // Adjust this value to your preference

    void Start()
    {
        Physics2D.gravity = new Vector2(0f, customGravity);
    }
}
