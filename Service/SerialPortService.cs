﻿using System;
using System.IO.Ports;
using System.Windows;

namespace WPF_App_For_Shop.Service;

public class SerialPortService
{
    private static SerialPortService _instance;
    private SerialPort serialPort;
    public event Action<string> DataReceived;

    private SerialPortService(string portName)
    {
        InitializeSerialPort(portName);
    }

    public static SerialPortService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SerialPortService("COM1");
            }
            return _instance;
        }
    }

    public void InitializeSerialPort(string portName)
    {
        serialPort = new SerialPort(portName)
        {
            BaudRate = 9600,
            Parity = Parity.None,
            StopBits = StopBits.One,
            DataBits = 8,
            Handshake = Handshake.None
        };

        serialPort.DataReceived += SerialPort_DataReceived;
    }

    public void Open()
    {
        try
        {
            serialPort.Open();
            MessageBox.Show($"Port {serialPort.PortName} is open!");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void Close()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            MessageBox.Show("Serial port closed.");
        }
    }

    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string data = serialPort.ReadExisting();
        DataReceived?.Invoke(data);
    }

    public string[] GetAllSerialPorts()
    {
        return SerialPort.GetPortNames();
    }
}
