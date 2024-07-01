using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class DragDrop : NetworkBehaviour
{
    public PlayerManager playerManager;
    private bool isDraggable = true;
    private bool isDragging = false;
    public GameObject Canvas;
    public GameObject DropZone;

    private GameObject startParent;
    private GameObject dropZone;
    private Vector2 startPosition;
    private bool isOverDropZone;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("Main Area");
        
        if(!isOwned)
        {
            isDraggable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isOverDropZone = true;
        dropZone = other.gameObject;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isOverDropZone = false;
        dropZone = null;
    }
    public void StartDrag()
    {
        if(!isDraggable) return;

        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }
    public void EndDrag()
    {
        if(!isDraggable) return;

        isDragging = false;
        if(isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            
            isDraggable = false;
            
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            playerManager = networkIdentity.GetComponent<PlayerManager>();
            playerManager.PlayCard(gameObject);
        }
        else{
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
