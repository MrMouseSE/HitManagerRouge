using System;
using UnityEngine;

namespace Core.Utils
{
    [Serializable]
    public class TransformAnimationType
    {
        public AnimationTypes AnimationType;
        public Transform TweenTransform;
        public AnimationCurve EffectCurve;
        public Vector3 From;
        public Vector3 To;
    }
}