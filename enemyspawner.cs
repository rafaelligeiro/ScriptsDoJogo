using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{

    private float fadeTime = 3f;
    public enum SpawnState{spawning, waiting, counting};
    public GameObject spawner;
    public GameObject dialogue;
    public AudioSource FightSound;
    public AudioSource FightSound1;
    [System.Serializable]

   public class wave
    {
        public Transform Enemy;
        public int count;
        public float rate;

    }
   
   public wave[] waves;
   public Transform[] spawnPoints;

   private int NextWave = 0;
   public float timeBTWWaves = 10f;
   public float waveCountdown;

   private float searchCountdown = 1f;

   private SpawnState estado = SpawnState.counting;

   void Start()
    {
        spawner.gameObject.SetActive(true);
        if (spawnPoints.Length == 0)
                {
                    Debug.LogError("Define os SpawnPoints");
                }

                
        waveCountdown = timeBTWWaves;


        if (dialogue.activeSelf)
            {
                this.gameObject.SetActive(false);
            }

    }

    void Update()
    {
        
        if (waveCountdown <= 0)
            {
                FightSound1.volume = 0.7f;
                FightSound.volume = 0f;
            }
        
        if (estado == SpawnState.waiting)
            {
                if (!EnemyIsAlive())
                    {
                        WaveCompleted();
                    } else {
                        return;
                    }
            }


        if(waveCountdown <= 0)
            {
                if (estado != SpawnState.spawning)
                    {
                    StartCoroutine(waveTime(waves[NextWave]));
                    }
            } else {
                waveCountdown -= Time.deltaTime;

            }
    }

    void WaveCompleted()
        {
            Debug.Log("All enemies killed");

            estado = SpawnState.counting;
            waveCountdown = timeBTWWaves;

            if(NextWave + 1 > waves.Length - 1)
                {
                NextWave = 0;
                if(NextWave == 0)
                    {
                    StartCoroutine(AudioFade.FadeOut(FightSound1, fadeTime));
                    StartCoroutine(Disable());
                    }
                Debug.Log("Level Completed!");
                } else {
                    NextWave++;
                }



        }

        bool EnemyIsAlive()
            {
                searchCountdown -= Time.deltaTime;

                if (searchCountdown <= 0f);
                    {
                        searchCountdown = 1f;
                        if (GameObject.FindGameObjectWithTag("Enemy") == null)
                            {
                                return false;
                            }
                    }
                    return true;
            }

    IEnumerator Disable()
        {
            yield return new WaitForSeconds(3f);
            FightSound.volume = 1f;

            this.gameObject.SetActive(false);

        }

    IEnumerator waveTime(wave _wave)
        {
            Debug.Log("Spawning Wave: ");
            estado = SpawnState.spawning;

            for( int i = 0; i < _wave.count; i++)
                {
                    EnemySpawn(_wave.Enemy);
                    yield return new WaitForSeconds(1f/_wave.rate);
                }

            estado = SpawnState.waiting;
            yield break;
        }


    void EnemySpawn(Transform _enemy)
        {
            Debug.Log("Enemy Spawned: " + _enemy.name);

            Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];
            Instantiate(_enemy, _sp.position, _sp.rotation);
        }


}
