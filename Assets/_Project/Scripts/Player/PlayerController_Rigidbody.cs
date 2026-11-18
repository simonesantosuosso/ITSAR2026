using UnityEngine;

public class PlayerController_Rigidbody : MonoBehaviour
{
    private Rigidbody rb;

    private Vector2 input;
    private GameControls controles;
    private float force = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controles = new GameControls();
    }

    private void OnEnable() => controles.Player.Enable();
    private void OnDisable() => controles.Player.Disable();
    private void OnDestroy() => controles.Player.Disable();
    

    private void Update()
    {
        input = controles.Player.Move.ReadValue<Vector2>();
        Debug.Log(input);
    }

    private void FixedUpdate()  // 50 volte al secondo: muovo
    {
        // dinamico: una spinta
        Vector3 input3 = new Vector3(input.x, 0f, input.y);
        Vector3 velocity = input3 * force;
;        //rb.AddForce(new Vector3(input.x, 0f, input.y) * force);

        // cinematico: decido io dove si trova (come Projectile)
         rb.MovePosition(rb.position +
            velocity * Time.fixedDeltaTime);
    }

}
