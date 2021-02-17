using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CollisionEvent : UnityEvent<Collider2D>
{

}

public class CollisionHandler : MonoBehaviour
{
    public CollisionEvent OnTriggerEnterEvent = new CollisionEvent();
    public CollisionEvent OnTriggerStayEvent = new CollisionEvent();
    public CollisionEvent OnTriggerExitEvent = new CollisionEvent();
    public CollisionEvent OnCollisionEnterEvent = new CollisionEvent();
    public CollisionEvent OnCollisionStayEvent = new CollisionEvent();
    public CollisionEvent OnCollisionExitEvent = new CollisionEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnTriggerEnterEvent != null)
        {
            OnTriggerEnterEvent.Invoke(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (OnTriggerStayEvent != null)
        {
            OnTriggerStayEvent.Invoke(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnTriggerExitEvent != null)
        {
            OnTriggerExitEvent.Invoke(collision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnCollisionEnterEvent != null)
        {
            OnCollisionEnterEvent.Invoke(collision.collider);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (OnCollisionStayEvent != null)
        {
            OnCollisionStayEvent.Invoke(collision.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (OnCollisionExitEvent != null)
        {
            OnCollisionExitEvent.Invoke(collision.collider);
        }
    }
}
