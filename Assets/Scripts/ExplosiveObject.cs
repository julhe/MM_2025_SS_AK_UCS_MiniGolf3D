using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosiveObject : MonoBehaviour
{
    public float explosionSpeed = 10.0f;
    public float explosionRadius = 5.0f;
    public UnityEvent OnIsBurning = new UnityEvent();
    bool isBurning = false;

    public void Explode()
    {
        if (!isBurning)
        {
            isBurning = true;
            StartCoroutine(ExplosionSequence());
            OnIsBurning.Invoke();
        }

    }

    IEnumerator ExplosionSequence()
    {
        yield return new WaitForSeconds(0.5f);
        // Finde objekte die von explositon betroffen sind.
        RaycastHit[] otherObjects = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.up);
        foreach (var otherObject in otherObjects)
        {
            if (otherObject.rigidbody)
            {
                // Lasse Objekte durch Explosion fliegen!
                otherObject.rigidbody.AddExplosionForce(explosionSpeed, transform.position, 100.0f);
            }

            ExplosiveObject otherExplosiveObject = null;
            if (otherObject.collider.gameObject.TryGetComponent<ExplosiveObject>(out otherExplosiveObject))
            {
                otherExplosiveObject.Explode();
            }
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<UnterrichtBallScript>())
        {
            Explode();  
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
