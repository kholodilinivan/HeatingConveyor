using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S7.Net;
using System;

using UnityEngine;
using S7.Net;




public class MainProg : MonoBehaviour

{
    private bool x1;
    private bool x2;
    private bool x3;
    private bool x4;
    private bool x5;
    private bool x7;

    private ImageChanger iamgechanger;

    Plc plc;

    // Start is called before the first frame update
    void Start()
    {
        plc = new Plc(CpuType.S71200, "127.0.0.1", 0, 1);
        plc.Open();
    }

    // Update is called once per frame
    void Update()
    {
        // Read data
        // Y1 - conveyour control
        bool y1 = (bool)plc.Read("DB1.DBX0.0");
        if (y1 == true)
        {
            // вкл конвейер
            GameObject.Find("ImageY1").GetComponent<ImageChanger>().On();
        }
        else
        {
            // выкл конвейер
            GameObject.Find("ImageY1").GetComponent<ImageChanger>().Off();
        }

        // Y2 - open front door
        bool y2 = (bool)plc.Read("DB1.DBX0.1");
        if (y2 == true)
        {
            // открывать переднюю дверь
            GameObject.Find("ImageY2").GetComponent<ImageChanger>().On();
        }
        else
        {
            // перестать открывать переднюю дверь
            GameObject.Find("ImageY2").GetComponent<ImageChanger>().Off();
        }

        // Y3 - close front door
        bool y3 = (bool)plc.Read("DB1.DBX0.2");
        if (y3 == true)
        {
            // закрывать переднюю дверь
            GameObject.Find("ImageY3").GetComponent<ImageChanger>().On();
        }
        else
        {
            // перестать закрывать переднюю дверь
            GameObject.Find("ImageY3").GetComponent<ImageChanger>().Off();
        }

        // Y4 - open back door
        bool y4 = (bool)plc.Read("DB1.DBX0.3");
        if (y4 == true)
        {
            // открывать заднюю дверь
            GameObject.Find("ImageY4").GetComponent<ImageChanger>().On();
        }
        else
        {
            // перестать открывать заднюю дверь
            GameObject.Find("ImageY4").GetComponent<ImageChanger>().Off();
        }

        // Y5 - close back door
        bool y5 = (bool)plc.Read("DB1.DBX0.4");
        if (y5 == true)
        {
            // закрывать заднюю дверь
            GameObject.Find("ImageY5").GetComponent<ImageChanger>().On();
        }
        else
        {
            // перестать закрывать заднюю дверь
            GameObject.Find("ImageY5").GetComponent<ImageChanger>().Off();
        }

        // Y6 - heating
        bool y6 = (bool)plc.Read("DB1.DBX0.5");
        if (y6 == true)
        {
            // вкл нагрев (от 25С до 100С должно доходить примерно за 5с) - отображать нагрев на индикаторе ПК
            GameObject.Find("ImageY6").GetComponent<ImageChanger>().On();
        }
        else
        {
            // выкл нагрев (должно медленно охлаждаться до 25С)
            GameObject.Find("ImageY6").GetComponent<ImageChanger>().Off();
        }

        // Y7 - cooling
        bool y7 = (bool)plc.Read("DB1.DBX0.6");
        if (y7 == true)
        {
            // вкл охлаждение (от 100С до 0С должно доходить примерно за 5с) - отображать охлажение на индикаторе ПК
            GameObject.Find("ImageY7").GetComponent<ImageChanger>().On();
        }
        else
        {
            // выкл нагрев (должно медленно доъходить до 25С)
            GameObject.Find("ImageY7").GetComponent<ImageChanger>().Off();
        }


        // Write data
        // object is positioned at X1
        if (x1 == true)
        {
            plc.Write("DB1.DBX0.7", true);
            GameObject.Find("ImageX1").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.7", false);
            GameObject.Find("ImageX1").GetComponent<ImageChanger>().Off();
        }

        // the front door is open
        if (x2 == true)
        {
            plc.Write("DB1.DBX0.8", true);
            GameObject.Find("ImageX2").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.8", false);
            GameObject.Find("ImageX2").GetComponent<ImageChanger>().Off();
        }

        // the front door is closed
        if (x3 == true)
        {
            plc.Write("DB1.DBX0.9", true);
            GameObject.Find("ImageX3").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.9", false);
            GameObject.Find("ImageX3").GetComponent<ImageChanger>().Off();
        }


        // the back door is open
        if (x4 == true)
        {
            plc.Write("DB1.DBX0.10", true);
            GameObject.Find("ImageX4").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.10", false);
            GameObject.Find("ImageX4").GetComponent<ImageChanger>().Off();
        }

        // the back door is closed
        if (x5 == true)
        {
            plc.Write("DB1.DBX0.11", true);
            GameObject.Find("ImageX5").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.11", false);
            GameObject.Find("ImageX5").GetComponent<ImageChanger>().Off();
        }

        // the temmperature is 100C
        if (x7 == true)
        {
            plc.Write("DB1.DBX0.12", true);
            GameObject.Find("ImageX7").GetComponent<ImageChanger>().On();
        }
        else
        {
            plc.Write("DB1.DBX0.12", false);
            GameObject.Find("ImageX7").GetComponent<ImageChanger>().Off();
        }
    }

}
