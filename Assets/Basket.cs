using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;   //Подключаем библиотеку для работы с ГИП (графическим интерфейсом пользователя)

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TMPro.TextMeshProUGUI scoreGT;

    void Start()
    {
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<TMPro.TextMeshProUGUI>();
        //Установить начальное число очков равное 
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        //Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        //Преобразовать точку на двумерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переместить корзину вдоль оси Х в координату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Отыскать яблоко, попавшее в эту корзину
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }

        //Преобразовать текст в ScoreGT в целое число
        int score = int.Parse(scoreGT.text);
        //Добавить очки за пойманное яблоко
        score += 100;
        //Преобразовать число очков обратно в строку и вывести ее на экран
        scoreGT.text = score.ToString();

        //Запомнить высшее достижение
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
