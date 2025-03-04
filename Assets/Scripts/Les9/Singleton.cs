using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� Singleton<T> ����������� �� MonoBehaviour � ������������ ��� T, ����� �� ��� MonoBehaviour
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ����������� ���������� ��� ������������, ��������� �� ����������
    public static bool isApplicationQuitting;

    // ����������� ���������� ��� �������� ������������� ���������� ������ T
    private static T _instance;

    // ������ ��� ������������� �������
    private static System.Object _lock = new System.Object();

    // ����������� �������� Instance ��� ��������� ������������� ���������� ������ T
    public static T Instance
    {
        get
        {
            // ���� ���������� ���������, ���������� null
            if (isApplicationQuitting)
                return null;

            // ��������� _lock, ����� ������������� ������������� ������ �� ������ �������
            lock (_lock)
            {
                // ���� ��������� ��� �� ������
                if (_instance == null)
                {
                    // �������� ����� ��������� ������ T � �����
                    _instance = FindObjectOfType<T>();

                    // ���� ��������� �� ������
                    if (_instance == null)
                    {
                        // ������� ����� GameObject � ������ "[SINGLETON] T"
                        var singleton = new GameObject("[SINGLETON] " + typeof(T));

                        // ��������� ��������� ������ T � ���������� GameObject
                        _instance = singleton.AddComponent<T>();

                        // �������������, ����� ������ �� ����������� ��� �������� ����� �����
                        DontDestroyOnLoad(singleton);
                    }
                }

                // ���������� ���������
                return _instance;
            }
        }
    }

    // ����������� ����� OnDestroy, ������� ���������� ��� ����������� �������
    public virtual void OnDestroy()
    {
        // ������������� ����, ��� ���������� ���������
        isApplicationQuitting = true;
    }
}
