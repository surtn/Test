using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent), typeof(Animator))]

public class FSMBase : MonoBehaviour
{
	int test;

	public Rigidbody rigid;
	public Animator anim;
	public NavMeshAgent agent;

	public ActorState state = ActorState.Idle;

	public virtual void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	public virtual void OnEnable()
	{
		StartCoroutine("FSMMain");
	}

	IEnumerator FSMMain()
	{
		while (true)
		{
			yield return StartCoroutine(state.ToString());
		}
	}

	public virtual IEnumerator Idle()
	{
		///Enter
		while (state == ActorState.Idle)
		{
			yield return null;
			///Execute

		}
		///Exit
	}

	public void SetState(ActorState _state)
	{
		state = _state;
		anim.SetInteger("state", (int)state);
	}

	public bool IsDead()
	{
		return state == ActorState.Dead;
	}
}