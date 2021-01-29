using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Spooky.Ui
{
    public class Module : MonoBehaviour
    {
        public UiStateSO UiState;
        protected CanvasGroup canvasGroup;
        protected RectTransform rectTransform;

        private bool _Active;// = true;

        public bool Active
        {
            get { return _Active; }
            set
            {
                //if (_Active == value) return;

                _Active = value;

                if (_Active)
                {
                    OnActivated();
                }
                else
                {
                    OnDeactivated();
                }
            }
        }

        protected virtual void OnActivated()
        {
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;
            }

            AnimateIn().Play();
        }

        protected virtual void OnDeactivated()
        {
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = false;
                canvasGroup.interactable = false;
            }

            AnimateOut().Play();
        }

        public Sequence AnimateIn()
        {
            Sequence sequence = DOTween.Sequence();
            if(canvasGroup != null)
            {
                sequence.Append(canvasGroup.DOFade(1f, .3f));
            }
            return sequence;
        }
        
        public Sequence AnimateOut()
        {
            Sequence sequence = DOTween.Sequence();
            if (canvasGroup != null)
            {
                sequence.Append(canvasGroup.DOFade(0f, .3f));
            }
            return sequence;
        }

        public void SetPosition(Vector2 position)
        {
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition = position;
        }

        protected virtual void Awake()
        {
            UiStateController.Instance.Subscribe(this);
            canvasGroup = GetComponent<CanvasGroup>();
            rectTransform = GetComponent<RectTransform>();
        }

        protected virtual void Start()
        {
            Active = UiStateController.Instance.GetState(UiState);
        }

        private void OnDestroy()
        {
            UiStateController.Instance.Unsubscribe(this);
        }

        protected void RebuildLayouts(RectTransform rectTransform)
        {
            StartCoroutine("RebuildLayoutsOnNextFrame", rectTransform);
        }

        private IEnumerator RebuildLayoutsOnNextFrame(RectTransform rectTransform)
        {
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }
    }
}