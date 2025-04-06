using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] BossPrefabs;
    private float EnemyTime;
    private float BossTime;
    private int currentWaveSize; // ��ǰ���ε�����Ŀ
    private int lastKillNum;

    void Start()
    {
        EnemyTime = 0f;
        BossTime = 15.0f;
        currentWaveSize = 1; // ��ʼ���ε�����Ŀ����Ϊ1

        lastKillNum = AttackPlayer.KillNumber;
        EnemyCreat();
    }

    void Update()
    {
        if ( AttackPlayer.KillNumber != lastKillNum)
        {
            // ����Ƿ�ﵽ������һ�����������������ÿ4�����˱���ɱʱ������
            if ((AttackPlayer.KillNumber- lastKillNum) % (4*currentWaveSize) == 0)
            {
                NextWave();
            }
        }

        if (BossPrefabs != null)
        {
            BossGeneration();
        }
    }

    void NextWave()
    {
        lastKillNum = AttackPlayer.KillNumber;

        // ���Ӳ��ε�����������ȷ�����������ֵ10
        currentWaveSize += 1;
        currentWaveSize = Mathf.Min(currentWaveSize, 10);

        // �������ɵ�ǰ���ε����е���
        for (int i = 0; i < currentWaveSize; i++)
        {
            EnemyCreat();
        }

    }

    void EnemyCreat()
    {
        int num = Random.Range(0, enemyPrefab.Length);
        var enemy = Instantiate(enemyPrefab[num]);
        enemy.transform.parent = this.transform;
        enemy.transform.localPosition = Vector3.zero;
    }

    void BossGeneration()
    {
        if (BossTime > 0) { BossTime -= Time.deltaTime; }
        else
        {
            int num = Random.Range(0, BossPrefabs.Length);
            var boss = Instantiate(BossPrefabs[num]);
            boss.transform.parent = this.transform;
            boss.transform.localPosition = Vector3.zero;
            BossTime = Random.Range(15, 30);
        }
    }
}