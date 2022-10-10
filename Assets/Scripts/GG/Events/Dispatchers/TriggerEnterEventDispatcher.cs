using GG.Attributes;
using UnityEngine;

namespace GG.Events.Dispatchers
{
    public class TriggerEnterEventDispatcher : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _collideWithTag;
        [SerializeField] private TwoGameObjectsEventChannelSO _eventToDispatch;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(_collideWithTag))
            {
                _eventToDispatch.OnEventRaised(gameObject, col.gameObject);
            }
        }
    }
}