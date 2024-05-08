using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private CoinClass coinPrefab;
    [SerializeField]
    private Transform coinInstancePosition;
    [SerializeField]
    private Transform moveTarget;
    [SerializeField]
    private float instnaceForce;
    [SerializeField]
    private ColliderSensor clearCollider;
    private ObjectPool<CoinClass> coinPool;
    void Start()
    {
        clearCollider.OnTriggerEnterObject += i =>
            {
                CacheManager.instnace.Cache++;
            };
        coinPool =
        new ObjectPool<CoinClass>(
            () => CreateCoin(),
            i => OnTakeFromPool(i),
            i => OnReturnedToPool(i),
            i => OnDestroyPoolObject(i),
            true,
            10,
            20
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coinPool.Get();
        }
    }
    enum Tag
    {
        FollowObject
    }
    private CoinClass CreateCoin()
    {
        var coin = Instantiate(coinPrefab.gameObject, coinInstancePosition.position, Quaternion.identity).GetComponent<CoinClass>();
        var sensor = coin.gameObject.AddComponent<ColliderSensor>();
        sensor.OnTriggerEnterObject += i =>
        {
            if (!i.CompareTag(Tag.FollowObject.ToString())) return;
            coin.transform.SetParent(i.transform);
        };
        var coinRigidbody = coin.GetComponent<Rigidbody>();
        var randomCircle = Random.insideUnitCircle;
        coinRigidbody.AddForce(new Vector3(randomCircle.x, -1, randomCircle.y).normalized * instnaceForce, ForceMode.Impulse);
        return coin;
    }
    void OnTakeFromPool(CoinClass target)
    {
        target.gameObject.SetActive(true);
    }
    void OnReturnedToPool(CoinClass target)
    {
        target.gameObject.SetActive(false);
    }
    void OnDestroyPoolObject(CoinClass target)
    {
        Destroy(target.gameObject);
    }
}
