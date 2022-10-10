// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "GameObjectEvent", menuName = "Events/GameObject Event Channel", order = 0)]
    public class GameObjectEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<GameObject> OnEventRaised;
        public void RaiseEvent(GameObject gameObject) => OnEventRaised?.Invoke(gameObject);
    }
}