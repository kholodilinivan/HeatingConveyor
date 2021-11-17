﻿using S7.Net;
using S7.Net.Types;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PLCDispatcher : MonoBehaviour
{
    public PLCConnectData conectionData;

    public List<PLCReceiveItem> receiveData = new List<PLCReceiveItem>();
    public List<PLCSendItem> sendData = new List<PLCSendItem>();

    private Dictionary<DataItem, PLCReceiveItem> sceneReceiveDependency = new Dictionary<DataItem, PLCReceiveItem>();
    private Plc plc;

    private void Awake()
    {
        if (conectionData == null)
        {
            Debug.LogError("[PLC] Укажите настройки подключения");
            return;
        }

        plc = CreatePlc(conectionData);
        plc.Open();

        var keys = new HashSet<int>();
        foreach (var receive in receiveData)
        {
            var hash = receive.data.GetHashCode();
            if (!keys.Contains(hash))
            {
                keys.Add(hash);
                var key = receive.data.ToDataItem(null);
                sceneReceiveDependency.Add(key, receive);
            }
        }

        foreach (var send in sendData)
        {
            send.OnValueChange += Send;
        }

        StartCoroutine(UpdateLoop(conectionData.updateTime));
    }

    IEnumerator UpdateLoop(float time)
    {
        var delay = new WaitForSeconds(time);
        var keys = sceneReceiveDependency.Keys.ToList();

        while (true)
        {
            yield return delay;
            plc.ReadMultipleVars(keys);

            foreach(var key in keys)
            {
                sceneReceiveDependency[key].ChangeState(key.Value);
            }
        }
    }

    public void Send(object? value, PLCDataItem dataItem)
    {
        plc.Write(dataItem.ToDataItem(value));
    }

    private Plc CreatePlc(PLCConnectData data)
    {
        return new Plc(conectionData.cpuType, conectionData.ip, conectionData.rack, conectionData.slot);
    }

    public void Close()
    {
        StopAllCoroutines();
        foreach (var send in sendData)
        {
            send.OnValueChange -= Send;
        }
        plc.Close();
    }

    private void OnDestroy()
    {
        if (plc != null)
        {
            Close();
        }
    }
}