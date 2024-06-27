using Otz.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Otz.Entities
{
    public static class EntityUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetLocalRotationForWorldRotation(Entity entity, out quaternion localRotation, quaternion targetWorldRotation,
            ref ComponentLookup<LocalToWorld> localToWorldLookup, ref ComponentLookup<Parent> parentLookup)
        {
            if(parentLookup.TryGetComponent(entity, out Parent parent) && localToWorldLookup.TryGetComponent(parent.Value, out LocalToWorld parentLTW))
            {
                localRotation = MathUtility.GetLocalRotationForWorldRotation(parentLTW.Rotation, targetWorldRotation);
                return;
            }

            localRotation = targetWorldRotation;
        }
    }
}