// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.UserInfo
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Claims;

#nullable disable
namespace TradingPlatform.BusinessLayer.Licence;

public class UserInfo
{
  public string Name { get; [param: In] internal set; }

  public string Email { get; [param: In] internal set; }

  public string UserId { get; [param: In] internal set; }

  public UserInfo(IEnumerable<Claim> claims)
  {
    foreach (Claim claim in claims)
    {
      if (claim.Type == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲필())
        this.UserId = claim.Value;
      if (claim.Type == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫())
        this.Name = claim.Value;
      if (claim.Type == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓖())
        this.Email = claim.Value;
    }
  }
}
