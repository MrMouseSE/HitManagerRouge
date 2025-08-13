using Core.Utils;
using UnityEngine;

namespace Core.Units
{
    public class UnitSceneContainer : MonoBehaviour
    {
        public Transform UnitTransform;
        public GameObject UnitGameObject;
        public Collider UnitCollider;
        public PlayableUnitEffect[] UnitEffects;

        [Space] public string Value;

        public void PlayEffect(PlayableUnitEffectTypes effectType)
        {
            var effect = UnitEffects[(int)effectType];
            float effectTime = effect.PlayAndReturnDuration();
            if (effectType == PlayableUnitEffectTypes.Death) Destroy(UnitGameObject, effectTime);
        }
    }
}