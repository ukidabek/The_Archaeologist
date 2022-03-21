using System.Collections;
using UnityEngine;

namespace Code.StateLogic
{
    public static class StateLogicHelpers
    {
        public static IEnumerator SetLayerWeight(Animator animator, int index, float target, float speed, float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            var current = animator.GetLayerWeight(index);
            while (current != target)
            {
                current = Mathf.MoveTowards(current, target, Time.deltaTime * speed);
                animator.SetLayerWeight(index, current);
                yield return null;
            }
        }
    }
}