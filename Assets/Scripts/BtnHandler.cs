 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 
 public class BtnHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     public Text theText;
     private AudioSource audioSource;
 
     public void OnPointerEnter(PointerEventData eventData)
     {
         theText.color = Color.green; //Or however you do your color
         audioSource = GetComponent<AudioSource>();
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         theText.color = Color.white; //Or however you do your color
     }
 }