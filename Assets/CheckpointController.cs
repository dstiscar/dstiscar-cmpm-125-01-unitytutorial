using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public MeshRenderer left, right, top;
    private void OnTriggerEnter(Collider other)
    {
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null)
        {
            vehicle.target = next;
            vehicle.laps += 1;
            next.left.materials[0].color = Color.red;
            next.right.materials[0].color = Color.red;
            next.top.materials[0].color = Color.red;
            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;
            top.materials[0].color = Color.white;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
