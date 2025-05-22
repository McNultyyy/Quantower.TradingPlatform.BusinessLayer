// Decompiled with JetBrains decompiler
// Type: Platform.Utils.Encryptor
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using TradingPlatform.BusinessLayer;

#nullable disable
namespace Platform.Utils;

public static class Encryptor
{
  public static string UnicDeviceId { get; [param: In] private set; }

  internal static string 퓏([In] string obj0)
  {
    if (string.IsNullOrEmpty(obj0))
      return obj0;
    string str = string.Empty;
    try
    {
      using (Aes aes = Aes.Create())
      {
        byte[] bytes = Encoding.UTF8.GetBytes(Encryptor.UnicDeviceId);
        int count = Math.Min(aes.IV.Length, bytes.Length);
        byte[] numArray1 = new byte[aes.IV.Length];
        Buffer.BlockCopy((Array) bytes, 0, (Array) numArray1, 0, count);
        using (ICryptoTransform encryptor = aes.CreateEncryptor(numArray1, aes.IV))
        {
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
            {
              using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
                streamWriter.Write(obj0);
            }
            byte[] iv = aes.IV;
            byte[] array = memoryStream.ToArray();
            byte[] numArray2 = new byte[iv.Length + array.Length];
            Buffer.BlockCopy((Array) iv, 0, (Array) numArray2, 0, iv.Length);
            Buffer.BlockCopy((Array) array, 0, (Array) numArray2, iv.Length, array.Length);
            str = Convert.ToBase64String(numArray2);
          }
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return str;
  }

  internal static string 퓬([In] string obj0)
  {
    if (string.IsNullOrEmpty(obj0))
      return obj0;
    string str = (string) null;
    try
    {
      byte[] src = Convert.FromBase64String(obj0);
      using (Aes aes = Aes.Create())
      {
        byte[] numArray1 = new byte[aes.IV.Length];
        byte[] numArray2 = new byte[src.Length - numArray1.Length];
        Buffer.BlockCopy((Array) src, 0, (Array) numArray1, 0, numArray1.Length);
        Buffer.BlockCopy((Array) src, numArray1.Length, (Array) numArray2, 0, src.Length - numArray1.Length);
        byte[] bytes = Encoding.UTF8.GetBytes(Encryptor.UnicDeviceId);
        int count = Math.Min(aes.IV.Length, bytes.Length);
        byte[] numArray3 = new byte[aes.IV.Length];
        Buffer.BlockCopy((Array) bytes, 0, (Array) numArray3, 0, count);
        using (ICryptoTransform decryptor = aes.CreateDecryptor(numArray3, numArray1))
        {
          using (MemoryStream memoryStream = new MemoryStream(numArray2))
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
            {
              using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
                str = streamReader.ReadToEnd();
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return str;
  }
}
