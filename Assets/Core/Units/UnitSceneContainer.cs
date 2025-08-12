using Core.Utils;
using UnityEngine;

namespace Core.Units
{
    public class UnitSceneContainer : MonoBehaviour
    {
        public Transform UnitTransform;
        public GameObject UnitGameObject;
        public PlayableUnitEffect[] UnitEffects;

        public void PlayEffect(PlayableUnitEffectTypes effectType)
        {
            UnitEffects[(int)effectType].Play();
        }
    }
}