using Muks.Tween;
using UnityEngine;

public class DoTweenAndMukTween : MonoBehaviour
{
    [SerializeField] private GameObject _obj;

    private void Start()
    {
        Vector3 target1 = _obj.transform.position + new Vector3(7, 0, 0);
        Vector3 target2 = target1 - new Vector3(7, 0, 0);
        _obj.TweenMove(target1, 2);
        _obj.TweenMove(target2, 2);
    }
} 
