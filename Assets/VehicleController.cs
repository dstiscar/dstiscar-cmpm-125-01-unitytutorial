using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody rb;
    public float impulse,turnrate;
    public CheckpointController target;
    float starttime;
    public float laps;
    public TextMeshProUGUI timelbl;
    public TextMeshProUGUI laplbl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
        target.top.materials[0].color = Color.red;
        starttime = Time.time;
        laps = 0;
    }

    void OnMove(InputValue action)
    {
        movementInput = action.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(0, 0, movementInput.x * -impulse);
        rb.AddRelativeForce(movementInput.y * impulse, 0, 0);

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        timelbl.text = string.Format("Current time: {0:F2} seconds", (Time.time - starttime));
        laplbl.text = string.Format("Laps driven: {0:F2}", laps);
    }
}
