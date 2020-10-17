using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class DoorInteractor : XRBaseInteractable
{

    [SerializeField] private bool isOpen = false;
    [SerializeField] private Animator animator;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Start()
    {
        SetState();
    }

    protected override void OnHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log("OnHoverEnter");
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
        Debug.Log("OnActivate");
        Handle();
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        Debug.Log("OnSelectEnter");
        Handle();
    }

    

    private void SetState()
    {
        animator.SetBool(IsOpen, isOpen);
    }

    public void Handle()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        isOpen = true;
        SetState();
    }

    public void Close()
    {
        isOpen = false;
        SetState();
    }
}
