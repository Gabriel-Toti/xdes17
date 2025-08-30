using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody2D _rb;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Vector2 direction = new (math.cos(math.TORADIANS * transform.eulerAngles.z), math.sin(math.TORADIANS * transform.eulerAngles.z));
        print(math.TORADIANS * transform.eulerAngles.z);
        _rb.linearVelocity = new Vector2 (speed, speed) * direction;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;

        Destroy(gameObject);
    }

}
