using UnityEngine;

public class meatSpin : MonoBehaviour
{
    public Transform center;    // 원운동 중심점
    public float radius = 2.0f; // 반지름
    public float speed = 2.0f;  // 속도

    private float angle = 0;

    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.position = center.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    }
}

