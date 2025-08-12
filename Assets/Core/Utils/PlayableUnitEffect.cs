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

        public void Play()
        {
            if (HasEffectAnimation)
            {
                EffectAnimation.Play();
            }

            if (HasEffectParticleSystem)
            {
                EffectParticleSystem.Play();
            }

            switch (EffectTransformAnimationType.AnimationType)
            {
                case AnimationTypes.Move:
                    EffectTransformAnimationType.TweenTransform.DOMove(EffectTransformAnimationType.To, 
                        EffectTransformAnimationType.EffectCurve.keys[^1].time).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                case AnimationTypes.Rotate:
                    EffectTransformAnimationType.TweenTransform.DORotate(EffectTransformAnimationType.To, 
                        EffectTransformAnimationType.EffectCurve.keys[^1].time).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                case AnimationTypes.Scale:
                    EffectTransformAnimationType.TweenTransform.DOScale(EffectTransformAnimationType.To, 
                        EffectTransformAnimationType.EffectCurve.keys[^1].time).SetEase(EffectTransformAnimationType.EffectCurve);
                    break;
                default:
                    return;
            }
        }
    }
}