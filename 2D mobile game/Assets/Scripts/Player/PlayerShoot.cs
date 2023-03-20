using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls _controls;

    public GameObject bullet;
    public Transform firePoint;
    [SerializeField]
    private float force = 400;


    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Enable();

        _controls.Player.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        GameObject go = Instantiate(bullet, firePoint.position, bullet.transform.rotation);
        if(GetComponent<PlayerLocomotion>().isRight)
            go.AddComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
            go.AddComponent<Rigidbody2D>().AddForce(Vector2.left * force);

        Destroy(go, 1.2f);
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
