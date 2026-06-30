using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private Vector3 originalScale;
    private void Start()
    {
        if (player != null)
        {
            originalScale = player.transform.localScale;
        }
    }
    public void DamageTaken()
    {
        LeanTween.scale(player, originalScale * 0.5f, 0.3f)
            .setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(NormalScale);
    }
    public void LifeTaken()
    {
        LeanTween.scale(player, originalScale * 1.5f, 0.3f)
            .setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(NormalScale);
    }
    public void NormalScale()
    {
        LeanTween.scale(player, originalScale, 0.3f)
            .setEase(LeanTweenType.easeInQuad);
    }
}
