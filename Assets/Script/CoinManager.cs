using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private CoinClass coinPrefab; // �R�C���̃v���n�u
    [SerializeField]
    private Transform coinInstancePosition; // �R�C���̐����ʒu
    [SerializeField]
    private Transform moveTarget; // �R�C���̈ړ���
    [SerializeField]
    private float instnaceForce; // �R�C���̐������̗�
    [SerializeField]
    private ColliderSensor clearCollider; // �N���A���������m����R���C�_�[�Z���T�[
    private ObjectPool<CoinClass> coinPool; // �R�C���̃I�u�W�F�N�g�v�[��

    void Start()
    {
        // �N���A���������m�������̏�����o�^
        clearCollider.OnTriggerEnterObject += i =>
        {
            // �L���b�V���𑝂₷
            CacheManager.instance.Cache++;
        };

        // �R�C���̃I�u�W�F�N�g�v�[����������
        coinPool = new ObjectPool<CoinClass>(
            () => CreateCoin(), // �R�C���̐����֐�
            i => OnTakeFromPool(i), // �R�C�����v�[��������o�����̏���
            i => OnReturnedToPool(i), // �R�C�����v�[���ɕԂ����̏���
            i => OnDestroyPoolObject(i), // �R�C�����v�[������j�����鎞�̏���
            true, // �v�[���ɃI�u�W�F�N�g�������Ő������邩�ǂ���
            10, // ����������
            20 // �v�[���̍ő吔
        );
    }

    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��R�C���𐶐�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coinPool.Get();
        }
    }
    enum Tag
    {
        FollowObject,
    }
    // �R�C���̐���
    private CoinClass CreateCoin()
    {
        // �R�C���𐶐����Ď擾
        var coin = Instantiate(coinPrefab.gameObject, coinInstancePosition.position, Quaternion.identity).GetComponent<CoinClass>();

        // �R�C���Ƀg���K�[�C�x���g�����m����R���C�_�[�Z���T�[��ǉ�
        var sensor = coin.gameObject.AddComponent<ColliderSensor>();
        sensor.OnTriggerEnterObject += i =>
        {
            // �ړ���̃I�u�W�F�N�g�ɐڐG�����ꍇ�A���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɂ���
            if (!i.CompareTag(Tag.FollowObject.ToString())) return;
            coin.transform.SetParent(i.transform);
        };

        // �R�C���ɗ͂������Ĉړ�������
        var coinRigidbody = coin.GetComponent<Rigidbody>();
        var randomCircle = Random.insideUnitCircle;
        coinRigidbody.AddForce(new Vector3(randomCircle.x, -1, randomCircle.y).normalized * instnaceForce, ForceMode.Impulse);

        return coin;
    }

    // �R�C�����v�[��������o�������̏���
    void OnTakeFromPool(CoinClass target)
    {
        target.gameObject.SetActive(true); // �R�C�����A�N�e�B�u�ɂ���
    }

    // �R�C�����v�[���ɕԂ������̏���
    void OnReturnedToPool(CoinClass target)
    {
        target.gameObject.SetActive(false); // �R�C�����A�N�e�B�u�ɂ���
    }

    // �R�C�����v�[������j�����鎞�̏���
    void OnDestroyPoolObject(CoinClass target)
    {
        Destroy(target.gameObject); // �R�C����j������
    }
}
