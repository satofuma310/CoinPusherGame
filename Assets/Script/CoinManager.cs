using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private CoinClass coinPrefab; // コインのプレハブ
    [SerializeField]
    private Transform coinInstancePosition; // コインの生成位置
    [SerializeField]
    private Transform moveTarget; // コインの移動先
    [SerializeField]
    private float instnaceForce; // コインの生成時の力
    [SerializeField]
    private ColliderSensor clearCollider; // クリア条件を検知するコライダーセンサー
    private ObjectPool<CoinClass> coinPool; // コインのオブジェクトプール

    void Start()
    {
        // クリア条件を検知した時の処理を登録
        clearCollider.OnTriggerEnterObject += i =>
        {
            // キャッシュを増やす
            CacheManager.instance.Cache++;
        };

        // コインのオブジェクトプールを初期化
        coinPool = new ObjectPool<CoinClass>(
            () => CreateCoin(), // コインの生成関数
            i => OnTakeFromPool(i), // コインをプールから取り出す時の処理
            i => OnReturnedToPool(i), // コインをプールに返す時の処理
            i => OnDestroyPoolObject(i), // コインをプールから破棄する時の処理
            true, // プールにオブジェクトを自動で生成するかどうか
            10, // 初期生成数
            20 // プールの最大数
        );
    }

    void Update()
    {
        // スペースキーが押されたらコインを生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coinPool.Get();
        }
    }
    enum Tag
    {
        FollowObject,
    }
    // コインの生成
    private CoinClass CreateCoin()
    {
        // コインを生成して取得
        var coin = Instantiate(coinPrefab.gameObject, coinInstancePosition.position, Quaternion.identity).GetComponent<CoinClass>();

        // コインにトリガーイベントを検知するコライダーセンサーを追加
        var sensor = coin.gameObject.AddComponent<ColliderSensor>();
        sensor.OnTriggerEnterObject += i =>
        {
            // 移動先のオブジェクトに接触した場合、そのオブジェクトの子オブジェクトにする
            if (!i.CompareTag(Tag.FollowObject.ToString())) return;
            coin.transform.SetParent(i.transform);
        };

        // コインに力を加えて移動させる
        var coinRigidbody = coin.GetComponent<Rigidbody>();
        var randomCircle = Random.insideUnitCircle;
        coinRigidbody.AddForce(new Vector3(randomCircle.x, -1, randomCircle.y).normalized * instnaceForce, ForceMode.Impulse);

        return coin;
    }

    // コインをプールから取り出した時の処理
    void OnTakeFromPool(CoinClass target)
    {
        target.gameObject.SetActive(true); // コインをアクティブにする
    }

    // コインをプールに返した時の処理
    void OnReturnedToPool(CoinClass target)
    {
        target.gameObject.SetActive(false); // コインを非アクティブにする
    }

    // コインをプールから破棄する時の処理
    void OnDestroyPoolObject(CoinClass target)
    {
        Destroy(target.gameObject); // コインを破棄する
    }
}
