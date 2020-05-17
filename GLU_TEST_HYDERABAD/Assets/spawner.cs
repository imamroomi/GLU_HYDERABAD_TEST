using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public class bullets
    {

        public string tag;
        public GameObject prefab;
        public int size;
        public float speed;
    }
    public static spawner Instance;
    private void Awake()
    {
        Instance = this;
    }


    public List<bullets> type_of_gameobject;
    public Dictionary<string, Queue<GameObject>> pooldictionary;
    void Start()
    {

        Instantiating_WITH_DATA_STRUCTURE();

    }


    void Instantiating_WITH_DATA_STRUCTURE()
    {

        pooldictionary = new Dictionary<string, Queue<GameObject>>();


        for (int a = 0; a < type_of_gameobject.Count; a++)
        {
            Debug.LogError(type_of_gameobject.Count);
            Queue<GameObject> objectpool = new Queue<GameObject>();
            Debug.LogError(type_of_gameobject[a].size);
            for (int b = 0; b < type_of_gameobject[a].size; b++)
            {
                GameObject obj = Instantiate(type_of_gameobject[a].prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            pooldictionary.Add(type_of_gameobject[a].tag, objectpool);
        }
    }

    void disable_obj()
    {
        for (int a = 0; a < 4; a++)
        {
            GameObject go = pooldictionary["player_bullet"].Dequeue();
            go.SetActive(false);
            pooldictionary["player_bullet"].Enqueue(go);
        }

    }

    public void spawn_player_bullet(string tag, Vector3 position, Quaternion rotation)
    {

        GameObject bullet_to_spawn = pooldictionary[tag].Dequeue();
        bullet_to_spawn.SetActive(true);

        bullet_to_spawn.transform.position = position;
        bullet_to_spawn.transform.rotation = rotation;

        pooldictionary[tag].Enqueue(bullet_to_spawn);
        player_shooting.Instance.shooting_bullet(tag, bullet_to_spawn);

        // return bullet_to_spawn;
    }


    public void enemies_spawn(string tag, Vector3 position, Quaternion rotation,int type)

    {

        GameObject enemy_to_spawn = pooldictionary[tag].Dequeue();
        enemy_to_spawn.SetActive(true);
        enemy_to_spawn.transform.position = position;
        enemy_to_spawn.transform.rotation = rotation;
        pooldictionary[tag].Enqueue(enemy_to_spawn);
        asteroid_movement.instance.asteroid_move(tag, 1, enemy_to_spawn, position, rotation);


    }


    IEnumerator Delay()
    {

        yield return new WaitForSeconds(0.06f);
    }
    public void enemies_bullet(string tag, Vector3 position, Quaternion rotation, float speed, int number_of_bullet)
    {



        GameObject enemybullet_to_spawn = pooldictionary[tag].Dequeue();
        enemybullet_to_spawn.SetActive(true);
        enemybullet_to_spawn.transform.position = position;
        enemybullet_to_spawn.transform.rotation = rotation;
        pooldictionary[tag].Enqueue(enemybullet_to_spawn);


        //enemies.instance.enemies_shooting(tag, speed, enemybullet_to_spawn, position, rotation);

    }


    // Update is called once per frame
    void Update()
    {
        
        spawn_bullets();

    }


    void spawn_bullets()
    {if (Input.GetKeyDown(KeyCode.S))
        {
        spawn_player_bullet("player_bullet", this.transform.position, this.transform.rotation);


        
        }
    }
   

}
