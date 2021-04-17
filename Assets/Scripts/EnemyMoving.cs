using UnityEngine;
using DG.Tweening;

public class EnemyMoving : MonoBehaviour
{
    [Header("Point of the enemies path")]
    [SerializeField] private GameObject _point;
    [Header("Duration in seconds")]
    [SerializeField] private float _duration;

    private void Start()
    {
        transform.DOMoveX(_point.transform.position.x, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear); 
    }
}
