using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear
/// </summary>
public class Asteroid : MonoBehaviour
{
    // death support
    const float RockLifespanSeconds = 2;
    Timer deathTimer;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // apply impulse force to get rock moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector3 direction = new Vector3(
            Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody>().AddForce(
            direction * magnitude,
            ForceMode.Impulse);

        // create and start timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = RockLifespanSeconds;
        deathTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Destroy the rock if it's no longer visible to camera  and timer is finished     
        OnBecameInvisible();       

    }

    void OnBecameInvisible()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
