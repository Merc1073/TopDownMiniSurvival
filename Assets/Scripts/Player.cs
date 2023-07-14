using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField]
    private LayerMask groundMask;

    [Header("Player variables")]
    public float health;
    public float hunger;
    public float stamina;
    public float moveSpeed;

    Rigidbody rb;

    private Camera mainCamera;

    Vector3 mousePos;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }



    void Update()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        rb.velocity = new Vector3(horizontalMovement, 0, verticalMovement).normalized * moveSpeed;

        Aim();

        rb.rotation = Quaternion.Euler(-90, 0, 0);

    }


    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }

        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();

        if(success)
        {
            var direction = position - transform.position;

            direction.y = -90;

            transform.forward = direction;
        }

    }

}
