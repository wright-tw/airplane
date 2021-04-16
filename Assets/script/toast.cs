using DG.Tweening;
using UnityEngine.UI; //使用UI
using UnityEngine;

public class Toast
{
	public static void alert(GameObject obj, string msg)
	{
		CanvasGroup tipCanvasGroup = obj.GetComponentInChildren<CanvasGroup>();
		tipCanvasGroup.GetComponentInChildren<Text>().text = msg;
		tipCanvasGroup.alpha = 0;
		DOTween.Kill(tipCanvasGroup);
		Sequence sequence = DOTween.Sequence();
		sequence.target = tipCanvasGroup;
		sequence.Append(tipCanvasGroup.DOFade(1, 0.8f));
		sequence.AppendInterval(0.5f);
		sequence.Append(tipCanvasGroup.DOFade(0, 1.0f));
	}
}