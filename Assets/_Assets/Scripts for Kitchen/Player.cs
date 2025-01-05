using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{


   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private GameInput gameInput;
   [SerializeField] private LayerMask countersLayerMask;





   private bool isWalking;
   private Vector3 lastInteractDir;


   private void Start()
   {

      gameInput.OnInteractAction += GameInput_OnInteractACtion;

   }

   private void GameInput_OnInteractACtion(object sender, System.EventArgs e)
   { 

      Vector2 inputVector = gameInput.GetMovementVectorNormalized();
      Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
      if (moveDir != Vector3.zero)
      {

         lastInteractDir = moveDir;
      }


      float interactDistance = 2f;
      if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))        // raycasthit was defined directly 
      {
         if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
         {
            // Has a clearCounter or not
            clearCounter.Interact();
         
         }


      }
   }

   private void Update()
   {
      HandleMovment();
      HandleInteractions();
   }




   public bool IsWalking()
   {
      return isWalking;
   }



   private void HandleInteractions()
   {

      Vector2 inputVector = gameInput.GetMovementVectorNormalized();
      Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
      if (moveDir != Vector3.zero)
      {

         lastInteractDir = moveDir;
      }

      float interactDistance = 2f;
      if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))        // raycasthit was defined directly 
      {
         if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
         {
            // Has a clearCounter or not
           
            

         }

         // Has a clearCounter or not

         // it also can be done like this:-

         //  // ClearCounter clearCounter = raycastHit.transform.GetComponent<ClearCounter>();
         // // if (clearCounter != null )
         // {
         //    // means clear counter
         // }

      }
      else
      {
         Debug.Log("--");
      }


   }
   private void HandleMovment()
   {
      Vector2 inputVector = gameInput.GetMovementVectorNormalized();
      Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

      float moveDistance = moveSpeed * Time.deltaTime;
      float playerRadius = 0.7f;
      float playerHeight = 2f;
      bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

      // this was made to attempt to solve diagonal movement  

      if (!canMove)
      {
         //attempt to move only on the X movment 
         Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
         canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

         if (canMove)
         {
            // can only move on the X
            moveDir = moveDirX;
         }
         else // can not move only on the X
         {
            // Attempt only on the Z movment 
            Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);


            if (canMove)
            {  //can move only the Z
               moveDir = moveDirZ;
            }

            else
            {
               //Can not move in any direction so Empty 
            }
         }


      }


      if (canMove)
      {
         transform.position += moveDir * moveDistance;

      }

      isWalking = moveDir != Vector3.zero;

      float rotateSpeed = 10f;
      transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);


   }


}


