using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNetwork : MonoBehaviour
{
    private void Start()
    {
        // ���b�Z�[�W��M���̏�����o�^
        NetworkManager.networkManager.OnMessageReceived += HandleMessage;

    }

    private void OnDestroy()
    {
        // �V�[���J�ڂ�I�u�W�F�N�g�j�����ɃC�x���g����
        if (NetworkManager.networkManager != null)
        {
            NetworkManager.networkManager.OnMessageReceived -= HandleMessage;
        }
    }

    private void HandleMessage(byte[] message)
    {
        Debug.Log($"GameScene received message: {BitConverter.ToString(message)}");

        // ���b�Z�[�W���e�ɉ���������
        if (message.Length > 0)
        {
            byte signal = message[0];
            
        }
    }
}
