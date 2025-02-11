using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWAITerSMALL : RobotWaiter
{
    [SerializeField]
    private GameObject water;

    public override void Bring()
    {
        StartCoroutine(Choose());
    }

    public void Bring(int index)
    {
        if (index == 0)
        {
            Debug.Log("� ����� ��� ����!");
            Instantiate(water, transform.position + new Vector3(0, 1f, -1f),
                Quaternion.identity);
        }

        if (index == 1)
        {
            Debug.Log("� ����� ��� ����!");
            Instantiate(_coffe, transform.position + new Vector3(0, 1f, -1f),
                Quaternion.identity);
        }
    }

    public override void Use()
    {
        Debug.Log("������, ����� � ����� ��� ���� ��� ����? ������� 5 ��� 4 ��������������.");
    }

    IEnumerator Choose()
    {
        bool isStop = true;

        while (isStop)
        {
            if (Input.GetKey(KeyCode.Alpha4))
            {
                Bring(1);
                isStop = false;
            }

            if (Input.GetKey(KeyCode.Alpha5))
            {
                Bring(0);
                isStop = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
