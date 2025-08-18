using Core.Utils;
using UnityEngine;

namespace Core.Units
{
    public class UnitSceneContainer : MonoBehaviour
    {
        public Transform UnitTransform;
        public GameObject UnitGameObject;
        public SphereCollider UnitSphereCollider;
        public PlayableUnitEffect[] UnitEffects;

        public SpriteRenderer UnitSpriteRenderer;
        public Color NoHP;
        public Color FullHp;

        public void UpdateColorByHp(float hp)
        {
            UnitSpriteRenderer.color = Color.Lerp(NoHP, FullHp, hp);
        }

        public void PlayEffect(PlayableUnitEffectTypes effectType)
        {
            var effect = UnitEffects[(int)effectType];
            float effectTime = effect.PlayAndReturnDuration();
            if (effectType == PlayableUnitEffectTypes.Death) Destroy(UnitGameObject, effectTime);
        }
    }
}