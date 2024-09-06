using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager instance;

    public List<ZombieData> Level1;
    public List<ZombieData> Level2;
    public List<ZombieData> Level3;
    public List<ZombieData> zombies;
    public Transform place;
    public float timer;
    public float grade;


    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }

    private void Start()
    {
        zombies = Level1;
        grade = 1;
        //zombies = new List<ZombieData>();
        generateZombies();
    }


    public void generateZombies()
    {
        foreach(ZombieData zombieData in zombies)
        {
            for(int i = 0; i < zombieData.number; i++)
            {
                GameObject zombie=Instantiate(zombieData.zombie, place.position + new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity);
                zombie.GetComponent<Enemy>().grade(grade);
            }
        }
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            generateZombies();
            timer = 0;
            grade += 0.5f;
        }
    }

    public void setLevel(int x)
    {
        if (x == 1)
        {
            zombies = Level1;
        }else if (x == 2)
        {
            zombies = Level2;
        }else if (x == 3)
        {
            zombies = Level3;
        }
        else
        {
            return;
        }
    }


}
