// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "CollisionEvent", menuName = "Events/Two GameObjects Event Channel", order = 0)]
    public class TwoGameObjectsEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<GameObject,GameObject> OnEventRaised;
        public void RaiseEvent(GameObject gameObjectA, GameObject gameObjectB) => OnEventRaised?.Invoke(gameObjectA, gameObjectB);
    }
}