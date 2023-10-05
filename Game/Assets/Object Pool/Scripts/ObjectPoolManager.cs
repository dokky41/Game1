using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    // 1. ObjectPoolManager 싱글톤으로 선언
    public static ObjectPoolManager instance;

    // 2. 오브젝트 풀로 사용할 게임 오브젝트를 선언
    public GameObject prefab;

    // 3. 오브젝트 풀로 사용할 (Queue) 컨테이너 선언
    private Queue<GameObject> queue = new Queue<GameObject>();

    // 4. 오브젝트 생성 갯수
    [SerializeField] int createCount = 5;

    private void Start()
    {
        // 1. 싱글톤 설정
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
        // 2. 게임 오브젝트 생성
        for(int i = 0; i < createCount; i++) 
        {
            GameObject bullet = Instantiate(prefab);
            
            // 3. Queue 컨테이너에 데이터 삽입
            queue.Enqueue(bullet);

            // 4. 게임 오브젝트 비활성화
            bullet.SetActive(false);

        }
    }

    private void Update()
    {
        
    }


    public void InsertQueue(GameObject bullet)
    {
        queue.Enqueue(bullet);
        bullet.SetActive(false);
    }


    public GameObject GetQueue(Vector3 createPosition)
    {
        GameObject bullet = queue.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = createPosition;
        return bullet;
    }

}
