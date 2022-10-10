using Constants;
using GG.Events;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Raise Events")]
    [SerializeField] private VoidEventChannelSO _eventPlayerCollectFruit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Fruit))
        {
            CollectFruit(other.gameObject);
        }
    }

    private void CollectFruit(GameObject fruit)
    {
        var fruitController = fruit.GetComponent<FruitController>();
        if (fruitController != null)
        {
            fruitController.BeCollected();
            _eventPlayerCollectFruit.RaiseEvent();
        }
    }
}
