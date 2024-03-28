using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private Unit unit;
    [SerializeField] private GameObject equip;
    private bool isEquip = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
        if (equip!=null)
        {
            isEquip = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        ChooseAnimation(unit);
    }
    
    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttack", false);
        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                ShowEquip(false);
                break;
            case UnitState.Move:
                anim.SetBool("IsMove", true);
                ShowEquip(false);
                break;
            case UnitState.MoveToEnemy:
                anim.SetBool("IsMove", true);
                ShowEquip(false);
                break;
            case UnitState.AttackUnit:
                anim.SetBool("IsAttack", true);
                ShowEquip(true);
                break;
            case UnitState.MoveToResource:
                anim.SetBool("IsMove", true);
                ShowEquip(false);
                break;
            case UnitState.BuildProgress:
                anim.SetBool("IsAttack", true);
                ShowEquip(true);
                break;
            case UnitState.Gather:
                anim.SetBool("IsAttack", true);
                ShowEquip(true);
                break;
            case UnitState.DeliverToHQ:
                anim.SetBool("IsMove", true);
                ShowEquip(false);
                break;
            case UnitState.StoreAtHQ:
                anim.SetBool("IsIdle", true);
                ShowEquip(false);
                break;
            case UnitState.Die:
                anim.SetBool("IsDead", true);
                ShowEquip(true);
                break;
            case UnitState.MoveToEnemyBuilding:
                anim.SetBool("IsMove", true);
                ShowEquip(false);
                break;
            case UnitState.AttackBuilding:
                anim.SetBool("IsAttack", true);
                ShowEquip(true);
                break;
        }
    }

    private void ShowEquip(bool b)
    {
        if (!isEquip) return;
        equip.SetActive(b);
    }

}
