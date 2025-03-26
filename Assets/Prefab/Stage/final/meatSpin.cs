using UnityEngine;

public class meatSpin : MonoBehaviour
{
    public Transform center;    // ��� �߽���
    public float radius = 2.0f; // ������
    public float speed = 2.0f;  // �ӵ�

    private float angle = 0;

    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.position = center.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    }
}

