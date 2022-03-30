using Logic.Items;
using UnityEngine;

public abstract class EquipLogicBase : MonoBehaviour
{
    public abstract bool CanBeHandled(IEquipment equipment);
    public abstract void Equip(IEquipment equipment);
}