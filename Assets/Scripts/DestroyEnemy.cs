using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == triggeringTag)
            {
                GameObject grandpa = transform.parent.transform.parent.gameObject;
                Destroy(grandpa);
            }
        }
}
