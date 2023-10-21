using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActivatedObjectScript : MonoBehaviour
{
   [SerializeField] private float delayDuration;

   [SerializeField] private GameObject objectToActivated;

   private bool _isOnYield;

   public void InvokeActivatedObject()
   {
      if(_isOnYield)
         return;
      
      StartCoroutine(YieldInvokeActivatedObject());
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A))
         InvokeActivatedObject();
   }

   IEnumerator YieldInvokeActivatedObject()
   {
      _isOnYield = true;
      
      objectToActivated.SetActive(false);

      yield return new WaitForSeconds(delayDuration);
      
      objectToActivated.SetActive(true);

      _isOnYield = false;
   }
}
