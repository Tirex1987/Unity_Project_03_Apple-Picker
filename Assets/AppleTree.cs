using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Ўаблон дл€ создани€ €блок
    public GameObject applePrefab;

    //—корость движени€ €блони
    public float speed = 1f;

    //–ассто€ние, на котором должно измен€тьс€ направление движени€ €блони
    public float leftAndRightEdge = 10f;

    //¬еро€тность случайного изменени€ направлени€ движени€
    public float chanceToChangeDirections = 0.1f;

    //„астота создани€ экземпл€ра €блок
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //—брасывать €блоки раз в секунду
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //ѕростое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //»зменение направлени€
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        //—лучайна€ смена направлени€ прив€зана к реальному времени
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
