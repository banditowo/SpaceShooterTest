using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Weapon weapon;

    [SerializeField] private float rotationSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

    }

    private void FixedUpdate()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * rotationSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.back * rotationSpeed);
    }
}
