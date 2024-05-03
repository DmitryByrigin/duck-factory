using System;
using UnityEngine.Events;
using UnityEngine;

namespace UnityEngine.XR.Content.Interaction
{
    public class Breakable : MonoBehaviour
    {
        [Serializable] public class BreakEvent : UnityEvent<GameObject, GameObject> { }

        [SerializeField]
        [Tooltip("The 'broken' version of this object.")]
        GameObject m_BrokenVersion;

        [SerializeField]
        [Tooltip("The tag a collider must have to cause this object to break.")]
        string m_ColliderTag = "Destroyer";

        [SerializeField]
        [Tooltip("The object that should be tagged as 'Roof' when this object is destroyed.")]
        GameObject m_RoofObject; // Объект, которому будет установлен тег "Roof"

        [SerializeField]
        [Tooltip("Events to fire when a matching object collides and break this object. " +
            "The first parameter is the colliding object, the second parameter is the 'broken' version.")]
        BreakEvent m_OnBreak = new BreakEvent();

        [SerializeField]
        [Tooltip("The sound of the box breaking.")]
        AudioClip m_BreakSound; // Звук разрезающейся коробки

        bool m_Destroyed = false;

        public BreakEvent onBreak => m_OnBreak;
        public UnityEvent OnEnterEvent;

        void OnCollisionEnter(Collision collision)
        {
            if (m_Destroyed)
                return;

            if (collision.gameObject.tag.Equals(m_ColliderTag, System.StringComparison.InvariantCultureIgnoreCase))
            {
                m_Destroyed = true;
                var brokenVersion = Instantiate(m_BrokenVersion, transform.position, transform.rotation);
                m_OnBreak.Invoke(collision.gameObject, brokenVersion);
                AudioSource.PlayClipAtPoint(m_BreakSound, transform.position); // Воспроизводим звук разрезающейся коробки
                m_RoofObject.tag = "Roof";
                OnEnterEvent.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
