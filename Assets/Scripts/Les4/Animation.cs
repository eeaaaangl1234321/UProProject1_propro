using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour
{
    public class AlwaysAnimatingButton : MonoBehaviour
    {
        public float duration = 0.2f;
        public Vector3 enlargedScale = new Vector3(1.2f, 1.2f, 1.2f);

        void Start()
        {
            Vector3 originalScale = transform.localScale;

            // Создаём последовательность анимаций
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(transform.DOScale(enlargedScale, duration))
                      .Append(transform.DOScale(originalScale, duration))
                      .SetLoops(-1, LoopType.Restart);
        }
    }
}
