using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public enum Mode
    {
        AtOnce,
        Timed
    };
    
    private List<Particle> _particles;
    private ForceField[] _forceFields;
    private bool _emitting = true;
    private List<Particle> _deadParticles;
    
    public int numParticles = 100;
    public Mode releaseMode = Mode.AtOnce;
    public float releasePulseInSeconds = 0.05f;
    public int particlesPerPulse = 1;
    public GameObject particlePrefab;
    public float speed = 1.0f;
    public float gravity = 0.1f;
    public bool  keepEmitting = false;

    void Start()
    {
        _particles = new List<Particle>();
        _deadParticles = new List<Particle>();
        _forceFields = FindObjectsOfType<ForceField>();

        switch (releaseMode)
        {
            case Mode.AtOnce:
                _emitting = true;
                AddParticles(numParticles);
                _emitting = false;
                break;
            case Mode.Timed:
                StartCoroutine(TimedRelease(releasePulseInSeconds));
                break;
        }
    }
    
    void Update()
    {
        //Remove dead particles from previous frame
        for (int i = 0; i < _deadParticles.Count; i++)
        {
            _particles.Remove(_deadParticles[i]);
        }
        _deadParticles.Clear();
        
        if (keepEmitting && _particles.Count < numParticles && !_emitting)
        {
            if (releaseMode == Mode.Timed)
            {
                StartCoroutine(TimedRelease(releasePulseInSeconds));
            }
            else
            {
                AddParticles(numParticles - _particles.Count);
            }
        }
        
        for (int p = 0; p < _particles.Count; p++)
        {
            for (int a = 0; a < _forceFields.Length; a++)
            {
                if (_forceFields[a].Active)
                {
                    _particles[p].Attract(_forceFields[a]);
                }
            }

            _particles[p].Step();
        }
    }

    IEnumerator TimedRelease(float seconds)
    {
        _emitting = true;
        while (_particles.Count < numParticles)
        {
            AddParticles(particlesPerPulse);
            yield return new WaitForSeconds(seconds);
        }

        _emitting = false;
    }
    
    public void AddParticles(int num)
    {
        for (int i = 0; i < num; i++)
        {
            AddParticle();
        }
    }
    
    public void AddParticle()
    {
        GameObject go = Instantiate(particlePrefab, transform.position, transform.rotation, transform);
        Particle p = go.AddComponent<Particle>();
        p.SetManager(this);
        _particles.Add(p);
    }

    public void RemoveParticle(Particle p)
    {
        _deadParticles.Add(p);
    }
}

