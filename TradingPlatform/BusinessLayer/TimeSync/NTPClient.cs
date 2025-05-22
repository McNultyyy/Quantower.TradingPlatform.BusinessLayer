// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.TimeSync.NTPClient
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer.TimeSync;

/// <summary>
/// from:
/// http://www.codeguru.com/csharp/csharp/cs_date_time/timeroutines/article.php/c4207/C-SNTP-Client.htm
/// +++ добавлен диспозе, подправлен ToString(), убран лишний метод.
/// +++ ReceiveTimeoutбSendTimeout
/// 
/// NTPClient is a C# class designed to connect to time servers on the Internet.
/// The implementation of the protocol is based on the RFC 2030.
/// 
/// Public class members:
/// 
/// LeapIndicator - Warns of an impending leap second to be inserted/deleted in the last
/// minute of the current day. (See the _LeapIndicator enum)
/// 
/// VersionNumber - Version number of the protocol (3 or 4).
/// 
/// Mode - Returns mode. (See the _Mode enum)
/// 
/// Stratum - Stratum of the clock. (See the _Stratum enum)
/// 
/// PollInterval - Maximum interval between successive messages.
/// 
/// Precision - Precision of the clock.
/// 
/// RootDelay - Round trip time to the primary reference source.
/// 
/// RootDispersion - Nominal error relative to the primary reference source.
/// 
/// ReferenceTimestamp - The time at which the clock was last set or corrected.
/// 
/// OriginateTimestamp - The time at which the request departed the client for the server.
/// 
/// ReceiveTimestamp - The time at which the request arrived at the server.
/// 
/// Transmit Timestamp - The time at which the reply departed the server for client.
/// 
/// RoundTripDelay - The time between the departure of request and arrival of reply.
/// 
/// LocalClockOffset - The offset of the local clock relative to the primary reference
/// source.
/// 
/// Initialize - Sets up data structure and prepares for connection.
/// 
/// Connect - Connects to the time server and populates the data structure.
/// 
/// IsResponseValid - Returns true if received data is valid and if comes from
/// a NTP-compliant time server.
/// 
/// ToString - Returns a string representation of the object.
/// 
/// -----------------------------------------------------------------------------
/// Structure of the standard NTP header (as described in RFC 2030)
///                       1                   2                   3
///   0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |LI | VN  |Mode |    Stratum    |     Poll      |   Precision   |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                          Root Delay                           |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                       Root Dispersion                         |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                     Reference Identifier                      |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                                                               |
///  |                   Reference Timestamp (64)                    |
///  |                                                               |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                                                               |
///  |                   Originate Timestamp (64)                    |
///  |                                                               |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                                                               |
///  |                    Receive Timestamp (64)                     |
///  |                                                               |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                                                               |
///  |                    Transmit Timestamp (64)                    |
///  |                                                               |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                 Key Identifier (optional) (32)                |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
///  |                                                               |
///  |                                                               |
///  |                 Message Digest (optional) (128)               |
///  |                                                               |
///  |                                                               |
///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
/// 
/// -----------------------------------------------------------------------------
/// 
/// NTP Timestamp Format (as described in RFC 2030)
///                         1                   2                   3
///     0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
/// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
/// |                           Seconds                             |
/// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
/// |                  Seconds Fraction (0-padded)                  |
/// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
/// 
/// </summary>
public class NTPClient : IDisposable
{
  private const byte 핇퓷 = 48 /*0x30*/;
  private const byte 핇퓿 = 16 /*0x10*/;
  private const byte 핇픟 = 24;
  private const byte 핇퓧 = 32 /*0x20*/;
  private const byte 핇픰 = 40;
  private byte[] 핇퓢;
  public DateTime ReceptionTimestamp;
  private UdpClient 핇픫;
  private readonly string 핇픯;

  public byte VersionNumber => (byte) (((int) this.핇퓢[0] & 56) >> 3);

  public _Mode Mode
  {
    get
    {
      switch ((byte) ((uint) this.핇퓢[0] & 7U))
      {
        case 1:
          return _Mode.SymmetricActive;
        case 2:
          return _Mode.SymmetricPassive;
        case 3:
          return _Mode.Client;
        case 4:
          return _Mode.Server;
        case 5:
          return _Mode.Broadcast;
        default:
          return _Mode.Unknown;
      }
    }
  }

  public _Stratum Stratum
  {
    get
    {
      byte num = this.핇퓢[1];
      if (num == (byte) 0)
        return _Stratum.Unspecified;
      if (num == (byte) 1)
        return _Stratum.PrimaryReference;
      return num <= (byte) 15 ? _Stratum.SecondaryReference : _Stratum.Reserved;
    }
  }

  public double Precision => 1000.0 * Math.Pow(2.0, (double) this.핇퓢[3]);

  public DateTime ReferenceTimestamp
  {
    get => this.퓏(this.퓏((byte) 16 /*0x10*/)) + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
  }

  public DateTime OriginateTimestamp => this.퓏(this.퓏((byte) 24));

  public DateTime ReceiveTimestamp
  {
    get => this.퓏(this.퓏((byte) 32 /*0x20*/)) + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
  }

  public DateTime TransmitTimestamp
  {
    get => this.퓏(this.퓏((byte) 40)) + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
    set => this.퓏((byte) 40, value);
  }

  public int RoundTripDelay
  {
    get
    {
      return (int) (this.ReceiveTimestamp - this.OriginateTimestamp + (this.ReceptionTimestamp - this.TransmitTimestamp)).TotalMilliseconds;
    }
  }

  public int LocalClockOffset
  {
    get
    {
      return (int) ((this.ReceiveTimestamp - this.OriginateTimestamp - (this.ReceptionTimestamp - this.TransmitTimestamp)).TotalMilliseconds / 2.0);
    }
  }

  private DateTime 퓏([In] ulong obj0)
  {
    return new DateTime(1900, 1, 1) + TimeSpan.FromMilliseconds((double) obj0);
  }

  private ulong 퓏([In] byte obj0)
  {
    ulong num1 = 0;
    ulong num2 = 0;
    for (int index = 0; index <= 3; ++index)
      num1 = 256UL /*0x0100*/ * num1 + (ulong) this.핇퓢[(int) obj0 + index];
    for (int index = 4; index <= 7; ++index)
      num2 = 256UL /*0x0100*/ * num2 + (ulong) this.핇퓢[(int) obj0 + index];
    return num1 * 1000UL + num2 * 1000UL / 4294967296UL /*0x0100000000*/;
  }

  private void 퓏([In] byte obj0, [In] DateTime obj1)
  {
    DateTime dateTime = new DateTime(1900, 1, 1, 0, 0, 0);
    long totalMilliseconds = (long) (ulong) (obj1 - dateTime).TotalMilliseconds;
    ulong num1 = (ulong) totalMilliseconds / 1000UL;
    ulong num2 = (ulong) totalMilliseconds % 1000UL * 4294967296UL /*0x0100000000*/ / 1000UL;
    ulong num3 = num1;
    for (int index = 3; index >= 0; --index)
    {
      this.핇퓢[(int) obj0 + index] = (byte) (num3 % 256UL /*0x0100*/);
      num3 /= 256UL /*0x0100*/;
    }
    ulong num4 = num2;
    for (int index = 7; index >= 4; --index)
    {
      this.핇퓢[(int) obj0 + index] = (byte) (num4 % 256UL /*0x0100*/);
      num4 /= 256UL /*0x0100*/;
    }
  }

  private void 퓏()
  {
    this.핇퓢[0] = (byte) 27;
    for (int index = 1; index < 48 /*0x30*/; ++index)
      this.핇퓢[index] = (byte) 0;
    this.TransmitTimestamp = DateTime.Now;
  }

  public NTPClient(string host)
  {
    this.핇퓢 = new byte[48 /*0x30*/];
    this.핇픯 = host;
  }

  /// <summary>Connect to the time server</summary>
  public void Connect()
  {
    try
    {
      try
      {
        if (this.핇픫 != null)
          this.핇픫.Close();
      }
      catch
      {
      }
      IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostAddresses(this.핇픯)[0], 123);
      this.핇픫 = new UdpClient();
      this.핇픫.Connect(remoteEP);
      this.퓏();
      Socket client1 = this.핇픫.Client;
      Socket client2 = this.핇픫.Client;
      TimeSpan timeSpan = TimeSpan.FromSeconds(5.0);
      int totalMilliseconds;
      int num1 = totalMilliseconds = (int) timeSpan.TotalMilliseconds;
      client2.SendTimeout = totalMilliseconds;
      int num2 = num1;
      client1.ReceiveTimeout = num2;
      this.핇픫.Send(this.핇퓢, this.핇퓢.Length);
      this.핇퓢 = this.핇픫.Receive(ref remoteEP);
      if (!this.IsResponseValid())
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픀() + this.핇픯);
      this.ReceptionTimestamp = DateTime.Now;
    }
    catch (SocketException ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public bool IsResponseValid() => this.핇퓢.Length >= 48 /*0x30*/ && this.Mode == _Mode.Server;

  public override string ToString()
  {
    string str = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픖();
    switch (this.Mode)
    {
      case _Mode.SymmetricActive:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픓();
        break;
      case _Mode.SymmetricPassive:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픩();
        break;
      case _Mode.Client:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇필();
        break;
      case _Mode.Server:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓖();
        break;
      case _Mode.Broadcast:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픵();
        break;
      case _Mode.Unknown:
        str += \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓘();
        break;
    }
    return str + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픬() + this.TransmitTimestamp.ToString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓕() + this.LocalClockOffset.ToString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픐() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픭();
  }

  public void Dispose()
  {
    try
    {
      if (this.핇픫 != null)
        this.핇픫.Close();
      this.핇픫 = (UdpClient) null;
    }
    catch
    {
    }
  }
}
