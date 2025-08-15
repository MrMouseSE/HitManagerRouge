using System.Collections.Generic;
using Core.GameplayControllers;
using UnityEngine;

namespace Core.PlayerActionsScripts.PlayerInputLibrary
{
    public static class PlayerInputHandler
    {
        public static Camera RayCastCamera;
        
        private static Plane _raycastPlane = new Plane(Vector3.up, Vector3.zero);
        
        public static GestureResult CheckForTapThisFrame(UnitsController unitsController)
        {
            GestureResult result = new GestureResult();
            if(!Input.GetMouseButtonDown(0)) return result;
            Ray ray = RayCastCamera.ScreenPointToRay(Input.mousePosition);
            
            if (_raycastPlane.Raycast(ray, out float intersectDistance))
            {
                result.TapPositions.Add(ray.origin + ray.direction * intersectDistance);
            }

            foreach (var playerUnit in unitsController.GetUnitsList(false))
            {
                if (!playerUnit.GetUnitValuesContainer().Prefab.UnitCollider.bounds.Contains(result.TapPositions[0])) continue;
                result.IsTappedThisFrame = true;
                result.TappedUnits.Add(playerUnit);
            }

            foreach (var enemyUnit in unitsController.GetUnitsList(true))
            {
                if (!enemyUnit.GetUnitValuesContainer().Prefab.UnitCollider.bounds.Contains(result.TapPositions[0])) continue;
                result.IsTappedThisFrame = true;
                result.TappedUnits.Add(enemyUnit);
            }
            
            return result;
        }
    }
}