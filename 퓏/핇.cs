// Decompiled with JetBrains decompiler
// Type: 퓏.핇
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using AuthenticodeExaminer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal static class 핇
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static void 퓏([In] string obj0)
  {
    if (핇.퓬(obj0))
      return;
    Environment.Exit(0);
  }

  internal static bool 퓬([In] string obj0_1)
  {
    try
    {
      FileInspector fileInspector = new FileInspector(obj0_1);
      SignatureCheckResult signatureCheckResult = fileInspector.Validate();
      IEnumerable<AuthenticodeSignature> signatures = fileInspector.GetSignatures();
      if (Path.GetFileName(obj0_1) == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓏())
      {
        if (signatureCheckResult != SignatureCheckResult.Valid || !signatures.Any<AuthenticodeSignature>((Func<AuthenticodeSignature, bool>) (([In] obj0_2) => obj0_2.SigningCertificate.Thumbprint.ToUpper() == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픑())))
          return false;
      }
      else if (signatureCheckResult != SignatureCheckResult.Valid && signatureCheckResult != SignatureCheckResult.UntrustedRoot || !signatures.Any<AuthenticodeSignature>((Func<AuthenticodeSignature, bool>) (([In] obj0_3) => obj0_3.SigningCertificate.Thumbprint.ToUpper() == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓍픿())))
        return false;
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
}
