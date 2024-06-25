using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float Speed = 100f;
    [SerializeField]
    private float Turn = 100f;
    [SerializeField]
    private float Brake = 100f;
    [SerializeField]
    private GameObject EffectBreak;

    private float Ver;
    private float Hori;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Ver = Input.GetAxis("Vertical");
        Hori = Input.GetAxis("Horizontal");
        MoveCar();
        TurnCar();
        if (Ver > 0 && Input.GetKey(KeyCode.LeftShift)) 
        {
            BrakeCar();
        }
    }

    public void MoveCar()
    {
        rb.AddRelativeForce(Vector3.forward * Ver * Speed);
        EffectBreak.SetActive(false);
    }

    public void TurnCar()
    {
        Quaternion re = Quaternion.Euler(Vector3.up * Hori * Turn * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * re);
    }

    public void BrakeCar()
    {
        if (rb.velocity.z != 0)
        {
           rb.AddRelativeForce(-Vector3.forward * Brake);
           EffectBreak.SetActive(true);
        }
    }
}
