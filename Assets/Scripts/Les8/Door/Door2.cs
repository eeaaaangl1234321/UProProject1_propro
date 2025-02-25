using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door2 : MonoBehaviour, iDoor
{
    public float liftHeight = 2f; // Высота, на которую поднимается дверь
    public float duration = 1f;  // Длительность анимации
    public float closeDelay = 3f; // Задержка перед закрытием двери (в секундах)

    private Vector3 closedPosition; // Начальная позиция двери
    private bool isOpen = false;    // Состояние двери (открыта/закрыта)

    void Start()
    {
        // Сохраняем начальную позицию двери
        closedPosition = transform.position;
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            // Закрываем дверь
            CloseDoor();
        }
        else
        {
            // Открываем дверь
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Поднимаем дверь вверх

    }

    private void CloseDoor()
    {
        // Опускаем дверь вниз
        transform.DOMove(closedPosition, duration);

        // Меняем состояние двери
        isOpen = false;
    }

    private System.Collections.IEnumerator CloseDoorAfterDelay()
    {
        // Ждем указанное количество секунд
        yield return new WaitForSeconds(closeDelay);

        // Закрываем дверь
        CloseDoor();
    }

    void iDoor.OpenDoor()
    {
        ; transform.DOMove(closedPosition + Vector3.up * liftHeight, duration)
                 .OnComplete(() => StartCoroutine(CloseDoorAfterDelay())); // Запускаем корутину после завершения анимации

        // Меняем состояние двери
        isOpen = true;
    }
}
