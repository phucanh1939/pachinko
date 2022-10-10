using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [CreateAssetMenu(fileName = "FruitEvent", menuName = "Events/Fruit Controller Event Channel", order = 0)]
    public class FruitControllerEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<FruitController> OnEventRaised;
        public void RaiseEvent(FruitController fruitController) => OnEventRaised?.Invoke(fruitController);
    }
}