using System.Collections.Generic;
using Core.Units;
using UnityEngine;

namespace Core.PlayerActionsScripts.PlayerInputLibrary
{
    public class GestureResult
    {
        public bool IsTappedThisFrame;
        public List<Vector3> TapPositions = new List<Vector3>();
        public List<IPlayableUnit> TappedUnits = new List<IPlayableUnit>();
    }
}