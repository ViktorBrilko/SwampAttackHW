using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DistanceTransition : Transition
{
   [SerializeField] private float _transitionRange;
   [SerializeField] private float _rangeSpread; //чтобы враги не вставали все в одном месте
   
   private void Start()
   {
      _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);;
   }

   private void Update()
   {
      if (Target != null)
      {
         if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
         {
            NeedTransit = true;
         }
      }
   }
}
