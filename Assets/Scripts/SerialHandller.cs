using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class SerialHandller : MonoBehaviour
{

    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived = delegate { };

    public string portName = "COM7";
    public int baudRate = 115200;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;

    // Use this for initialization
    void Start()
    {
//        Debug.LogWarning("Start");
        Open();
    }

    // Update is called once per frame
    void Update()
    {
 //       Debug.LogWarning("Serial-update");
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }
    void OnDestroy()
    {
//        Debug.LogWarning("OnDestroy");
        Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
        //serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();

        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Read()
    {
 //       Debug.LogWarning("Read1");
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
 //           Debug.LogWarning("Read2");
            try
            {

                message_ = serialPort_.ReadLine();
                serialPort_.ReadTimeout = 1000;
                //Debug.LogWarning(message_);
                isNewMessageReceived_ = true;

            }
            catch (System.Exception e)
            {
//                Debug.LogWarning(e.Message);
            }
        }
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort_.Write(message);
        }
        catch (System.Exception e)
        {
 //           Debug.LogWarning(e.Message);
        }
    }
}
