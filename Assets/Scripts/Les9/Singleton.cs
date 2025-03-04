using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс Singleton<T> наследуется от MonoBehaviour и ограничивает тип T, чтобы он был MonoBehaviour
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Статическая переменная для отслеживания, завершено ли приложение
    public static bool isApplicationQuitting;

    // Статическая переменная для хранения единственного экземпляра класса T
    private static T _instance;

    // Объект для синхронизации потоков
    private static System.Object _lock = new System.Object();

    // Статическое свойство Instance для получения единственного экземпляра класса T
    public static T Instance
    {
        get
        {
            // Если приложение завершено, возвращаем null
            if (isApplicationQuitting)
                return null;

            // Блокируем _lock, чтобы предотвратить одновременный доступ из разных потоков
            lock (_lock)
            {
                // Если экземпляр еще не создан
                if (_instance == null)
                {
                    // Пытаемся найти экземпляр класса T в сцене
                    _instance = FindObjectOfType<T>();

                    // Если экземпляр не найден
                    if (_instance == null)
                    {
                        // Создаем новый GameObject с именем "[SINGLETON] T"
                        var singleton = new GameObject("[SINGLETON] " + typeof(T));

                        // Добавляем компонент класса T к созданному GameObject
                        _instance = singleton.AddComponent<T>();

                        // Устанавливаем, чтобы объект не уничтожался при загрузке новой сцены
                        DontDestroyOnLoad(singleton);
                    }
                }

                // Возвращаем экземпляр
                return _instance;
            }
        }
    }

    // Виртуальный метод OnDestroy, который вызывается при уничтожении объекта
    public virtual void OnDestroy()
    {
        // Устанавливаем флаг, что приложение завершено
        isApplicationQuitting = true;
    }
}
