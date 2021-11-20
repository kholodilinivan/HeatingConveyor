using S7.Net;
using S7.Net.Types;

using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "ScriptableObjects/PLCRegisters", order = 1)]
public class PLCDataItem : ScriptableObject
{
    public DataType DataType;
    public VarType VarType;
    public int DB;
    public int StartByteAdr;
    public byte BitAdr;
    public int Count;

    public override bool Equals(object obj)
    {
        return obj is PLCDataItem item &&
               base.Equals(obj) &&
               name == item.name &&
               hideFlags == item.hideFlags &&
               DataType == item.DataType &&
               VarType == item.VarType &&
               DB == item.DB &&
               StartByteAdr == item.StartByteAdr &&
               BitAdr == item.BitAdr &&
               Count == item.Count;
    }

    public override int GetHashCode()
    {
        int hashCode = -1191087931;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
        hashCode = hashCode * -1521134295 + hideFlags.GetHashCode();
        hashCode = hashCode * -1521134295 + DataType.GetHashCode();
        hashCode = hashCode * -1521134295 + VarType.GetHashCode();
        hashCode = hashCode * -1521134295 + DB.GetHashCode();
        hashCode = hashCode * -1521134295 + StartByteAdr.GetHashCode();
        hashCode = hashCode * -1521134295 + BitAdr.GetHashCode();
        hashCode = hashCode * -1521134295 + Count.GetHashCode();
        return hashCode;
    }

    public DataItem ToDataItem()
    {
        var dataItem = new DataItem();
        dataItem.DataType = DataType;
        dataItem.BitAdr = BitAdr;
        dataItem.Count = Count;
        dataItem.DB = DB;
        dataItem.StartByteAdr = StartByteAdr;
        dataItem.VarType = VarType;

        switch (dataItem.VarType)
        {
            case VarType.Bit:
                dataItem.Value = false;
                break;
            case VarType.Byte:
                dataItem.Value = (byte)0;
                break;
            case VarType.Int:
                dataItem.Value = 0;
                break;
            case VarType.Real:
                dataItem.Value = 0f;
                break;
            case VarType.String:
                dataItem.Value = "";
                break;
        }

        return dataItem;
    }

    public DataItem ToDataItem(object? value)
    {
        var dataItem = new DataItem();
        dataItem.DataType = DataType;
        dataItem.BitAdr = BitAdr;
        dataItem.Count = Count;
        dataItem.DB = DB;
        dataItem.StartByteAdr = StartByteAdr;
        dataItem.VarType = VarType;
        dataItem.Value = value;
        return dataItem;
    }
}