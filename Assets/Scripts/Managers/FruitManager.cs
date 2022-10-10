using Events;
using GG.Events;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Managers
{
    /// <summary>
    /// This class manager all fruits in the game (spawning, pooling, etc)
    /// </summary>
    public class FruitManager : MonoBehaviour
    {
        [SerializeField] private GameObject _fruitPrefab;
        [SerializeField] private float _spawnInterval = 5.0f;
        [SerializeField] private int _fruitPoolInitSize = 10;
        [SerializeField] private Camera _mainCamera;

        [Header("Listen To Events")] [SerializeField]
        private FruitControllerEventChannelSO _eventFruitDisappear;

        private float _fruitHeight;
        private ObjectPool<GameObject> _fruitPool;

        #region Unity Events

        private void Awake()
        {
            InitFruitPool();
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnFruit), 0.0f, _spawnInterval);
            _fruitHeight = _mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        }

        private void OnEnable()
        {
            _eventFruitDisappear.OnEventRaised += OnFruitDisappear;
        }

        private void OnDisable()
        {
            _eventFruitDisappear.OnEventRaised -= OnFruitDisappear;
        }

        #endregion

        #region Pool

        private void InitFruitPool()
        {
            _fruitPool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(_fruitPrefab),
                actionOnGet: (obj) => obj.SetActive(true),
                actionOnRelease: (obj) => obj.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                defaultCapacity: _fruitPoolInitSize,
                maxSize: 25
            );
        }

        private Vector2 RandomFruitPosition()
        {
            var x = Random.Range(_mainCamera.ScreenToWorldPoint(new Vector2(0, 0)).x,
                _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            return new Vector2(x, _fruitHeight);
        }

        public void SpawnFruit()
        {
            var fruit = _fruitPool.Get();
            fruit.transform.position = RandomFruitPosition();
            var fruitController = fruit.GetComponent<FruitController>();
            if (fruitController != null)
            {
                fruitController.Fall();
            }
        }

        public void ReleaseFruit(GameObject fruit) => _fruitPool.Release(fruit);

        #endregion

        #region Events

        private void OnFruitDisappear(FruitController fruit)
        {
            ReleaseFruit(fruit.gameObject);
        }

        #endregion
    }
}