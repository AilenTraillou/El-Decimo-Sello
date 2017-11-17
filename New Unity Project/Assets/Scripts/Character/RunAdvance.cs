using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAdvance : IAdvance {

    float _speed;
    Transform _transform;
    Rigidbody _rb;

    public void Advance()
    {
        if (Input.GetAxis("Vertical") < 0)
            _rb.transform.Translate(Vector3.forward * -_speed * Time.deltaTime);
        else
        if (Input.GetAxis("Vertical") > 0)
            _rb.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        else
        if (Input.GetAxis("Horizontal") < 0)
            _rb.transform.Translate(Vector3.right * -_speed * Time.deltaTime);
        else
        if (Input.GetAxis("Horizontal") > 0)
            _rb.transform.Translate(Vector3.right * _speed * Time.deltaTime);

        SoundsManager.instancia.channels[(int)SoundID.Footsteps].pitch = 1.2f;

    }

    public RunAdvance(Rigidbody rb, float speed)
    {
        _speed = speed;
        _rb = rb;
    }
}
