using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public Transform nextBasePosition;
    [SerializeField] BaseGeneration baseGeneration;

    public List<Transform> rotatingObstacle;
    float rotating_speed = 2f;
    public bool IsPooled;

    private void OnEnable()
    {
        baseGeneration.gameObject.SetActive(true);
    }


    private void Update()
    {
        for (int i = 0; i < rotatingObstacle.Count; i++)
        {
            rotatingObstacle[i].transform.eulerAngles = new Vector3(0f, Time.deltaTime * rotating_speed, 0f);

        }
    }
}
