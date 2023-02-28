using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private Vector3 _attraction;
    private Vector3 _direction;
    private float _dragCoeficient;
    private ParticleEmitter _emitter;
    
    void Start()
    {
        _attraction = new Vector3();
        _direction = Random.onUnitSphere * 5f;
        _dragCoeficient = (Random.value+0.3f) / 40f;
    }
    
    void Update()
    {
        
    }

    public void SetManager(ParticleEmitter emitter)
    {
        _emitter = emitter;
    }

    public void Attract(ForceField a)
    {
        Vector3 attraction = a.Position - transform.position;
        float distance = attraction.magnitude;
        attraction.Normalize();

        if (a.Mode == ForceField.FieldMode.Destroy && distance < a.range)
        {
            _emitter.RemoveParticle(this);
            Destroy(gameObject);
        }
        
        if (distance > 100)
        {
            attraction *= a.strength;
            if (a.Mode == ForceField.FieldMode.Attract)
            {
                _attraction += attraction * Time.deltaTime;
            }
        }
        else
        {
            attraction *= a.strength * Mathf.Clamp(Utils.Map(distance, 0, a.range, 1, 0), 0, 1);
            if (a.Mode == ForceField.FieldMode.Attract)
            {
                _attraction += attraction * Time.deltaTime;
            }
            else
            {
                _attraction -= attraction * Time.deltaTime;
            }
        }
    }

    public void Step()
    {
        Vector3 position = transform.position;
        Vector3 gravity = _emitter.transform.position - position;
        gravity.Normalize();
        gravity *= _emitter.gravity;
        _attraction += gravity * Time.deltaTime;
        _direction += _attraction;
        Vector3 drag = new Vector3();
        drag -= _direction * (_dragCoeficient * Utils.Map(_direction.magnitude, 0, 15, 0, 1));
        _direction += drag;
        position += _direction * (Time.deltaTime * _emitter.speed);
        transform.LookAt(position - _direction);
        transform.position = position;
        _attraction.Set(0,0,0);
    }
}
