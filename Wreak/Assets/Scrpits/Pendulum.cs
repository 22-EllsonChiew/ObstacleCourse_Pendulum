using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    [SerializeField, Range(0.0f, 360f)]
    private float _angle = 90.0f;

    [SerializeField, Range(0.0f, 5.0f)]
    private float _speed = 2.0f;

    Quaternion _start, _end;

    [SerializeField, Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;







    // Start is called before the first frame update
    void Start()
    {
        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }




    void ResetTimer()
    {
        _startTime = 0.0f;
    }



    Quaternion PendulumRotation(float angle)
    {
        var pendulumRoation = transform.rotation;
        var anglez = pendulumRoation.eulerAngles.z + angle;

        if(anglez> 180)
        {
            anglez -= 360;
        }
        else if(anglez < -180)
        {
            anglez += 360;
        }

        pendulumRoation.eulerAngles = new Vector3(pendulumRoation.eulerAngles.x, pendulumRoation.eulerAngles.y, anglez);
        return pendulumRoation;
    }
}
