using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAdvance : IAdvance {

    public Rigidbody _rb;
    public float _jumpStr = 30;

    public void Advance()
    {
        SoundsManager.instancia.Play((int)SoundID.Jump, 1, false);
        _rb.AddForce(Vector3.up * _jumpStr, ForceMode.Impulse);

        SoundsManager.instancia.Play((int)SoundID.Jump, 1, false);

    }

    public JumpAdvance(Rigidbody rb, float jumpStr)
    {
        _jumpStr = jumpStr;
        _rb = rb;
    }

}
