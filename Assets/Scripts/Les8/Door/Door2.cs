using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door2 : MonoBehaviour, iDoor
{
    public float liftHeight = 2f; // ������, �� ������� ����������� �����
    public float duration = 1f;  // ������������ ��������
    public float closeDelay = 3f; // �������� ����� ��������� ����� (� ��������)

    private Vector3 closedPosition; // ��������� ������� �����
    private bool isOpen = false;    // ��������� ����� (�������/�������)

    void Start()
    {
        // ��������� ��������� ������� �����
        closedPosition = transform.position;
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            // ��������� �����
            CloseDoor();
        }
        else
        {
            // ��������� �����
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // ��������� ����� �����

    }

    private void CloseDoor()
    {
        // �������� ����� ����
        transform.DOMove(closedPosition, duration);

        // ������ ��������� �����
        isOpen = false;
    }

    private System.Collections.IEnumerator CloseDoorAfterDelay()
    {
        // ���� ��������� ���������� ������
        yield return new WaitForSeconds(closeDelay);

        // ��������� �����
        CloseDoor();
    }

    void iDoor.OpenDoor()
    {
        ; transform.DOMove(closedPosition + Vector3.up * liftHeight, duration)
                 .OnComplete(() => StartCoroutine(CloseDoorAfterDelay())); // ��������� �������� ����� ���������� ��������

        // ������ ��������� �����
        isOpen = true;
    }
}
