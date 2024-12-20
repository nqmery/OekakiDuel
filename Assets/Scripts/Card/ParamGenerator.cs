using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System;
using System.Data;
[DefaultExecutionOrder(-5)]
public class ParamGenerator : MonoBehaviour
{
    public static ParamGenerator paramGenerator;
    void Awake(){
        paramGenerator = this;
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //     paramGenerator = this;
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    //デバッグ用表示
    public void DebugLog(Texture2D image)
    {
        var a = GenerateParams(image);
        Debug.Log("CRC32: " + a.hashValue + "ATK: " + a.attack + "DEF: " + a.defense + "cost: " + a.cost + "SPD: " + a.speed + "EFF: " + a.effect);
    }

    public (uint hashValue,int attack,int defense, int cost, int speed, int effect) GenerateParams(Texture2D image)
    {
        CRC32 crc32 = new CRC32();
        uint hashValue = crc32.Calc(image.GetRawTextureData());

        crc32 = null;
        int attack = (int)(hashValue / 70000);
        int defense = (int)(hashValue / 140000);
        int cost = (int)(hashValue % 250);
        int speed = (int)(hashValue % 500);
        int effect = (int)(hashValue % 10);

        return (hashValue, attack, defense, cost, speed, effect);
    }

    //CRC32計算
    public class CRC32
    {
        private const int TABLE_LENGTH = 256;
        private uint[] crcTable;

        public CRC32()
        {
            BuildCRC32Table();
        }

        private void BuildCRC32Table()
        {
            crcTable = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                var x = i;
                for (var j = 0; j < 8; j++)
                {
                    x = (uint)((x & 1) == 0 ? x >> 1 : -306674912 ^ x >> 1);
                }
                crcTable[i] = x;
            }
        }

        public uint Calc(byte[] buf)
        {
            uint num = uint.MaxValue;
            for (var i = 0; i < buf.Length; i++)
            {
                num = crcTable[(num ^ buf[i]) & 255] ^ num >> 8;
            }

            return (uint)(num ^ -1);
        }
    }
}
