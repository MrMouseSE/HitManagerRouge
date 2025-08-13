using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Utils
{
    [Serializable]
    public class PlayableUnitEffect
    {
        public PlayableUnitEffectTypes Type;
        public bool HasEffectAnimation;
        public Animation EffectAnimation;
        public bool HasEffectParticleSystem;
        public ParticleSystem EffectParticleSystem;
        public TransformAnimationType EffectTransformAnimationType;

        public float PlayAndReturnDuration()
        {
            if (HasEffectParticleSystem)
            {
                EffectParticleSystem.Play();
            }
            
            if (HasEffectAnimation)
            {
                EffectAnimation.Play();
                return EffectAnimation.clip.length;
            }
            
            float duration = EffectTransformAnimationType.EffectCurve.keys[^1].time;
            switch (EffectTransformAnimationType.AnimationType)
            {
                case AnimationTypes.Move:
                    EffectTransformAnimationType.TweenTransform.DOMove(EffectTransformAnimationType.To, 
                        duration).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                case AnimationTypes.Rotate:
                    EffectTransformAnimationType.TweenTransform.DORotate(EffectTransformAnimationType.To, 
                        duration).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                case AnimationTypes.Scale:
                    EffectTransformAnimationType.TweenTransform.DOScale(EffectTransformAnimationType.To, 
                        duration).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                case AnimationTypes.None:
                    break;
            }
            return 0f;
        }
    }
}