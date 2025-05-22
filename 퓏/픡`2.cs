// Decompiled with JetBrains decompiler
// Type: 퓏.픡`2
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace 퓏;

internal class 픡<퓏, 퓬> : 핅<퓏, 퓬>
{
  private readonly object 퓲퓍;

  public 픡() => this.퓲퓍 = new object();

  public override int Count
  {
    get
    {
      lock (this.퓲퓍)
        return base.Count;
    }
  }

  public override 퓬 퓏([In] int obj0)
  {
    lock (this.퓲퓍)
      return base.퓏(obj0);
  }

  public override 퓬[] 퓏()
  {
    lock (this.퓲퓍)
      return base.퓏();
  }

  public override 퓬 this[[In] 퓏 obj0]
  {
    get
    {
      lock (this.퓲퓍)
        return base[obj0];
    }
    [param: In] set
    {
      lock (this.퓲퓍)
        base[obj0] = value;
    }
  }

  public override int 퓏([In] 퓏 obj0, [In] 퓬 obj1)
  {
    lock (this.퓲퓍)
      return base.퓏(obj0, obj1);
  }

  public override void 퓏([In] 퓏 obj0)
  {
    lock (this.퓲퓍)
      base.퓏(obj0);
  }

  public override void 퓬([In] int obj0)
  {
    lock (this.퓲퓍)
      base.퓬(obj0);
  }

  public override void 퓏([In] int obj0, [In] int obj1)
  {
    lock (this.퓲퓍)
      base.퓏(obj0, obj1);
  }

  public override void 퓏([In] 퓬 obj0)
  {
    lock (this.퓲퓍)
      base.퓏(obj0);
  }

  public override 퓏 핇([In] int obj0)
  {
    lock (this.퓲퓍)
      return base.핇(obj0);
  }

  public override void 퓬()
  {
    lock (this.퓲퓍)
      base.퓬();
  }

  public override bool 퓬([In] 퓏 obj0)
  {
    lock (this.퓲퓍)
      return base.퓬(obj0);
  }

  public override bool 퓬([In] 퓬 obj0)
  {
    lock (this.퓲퓍)
      return base.퓬(obj0);
  }

  public override ICollection<퓏> Keys
  {
    get
    {
      lock (this.퓲퓍)
        return base.Keys;
    }
  }

  public override ICollection<퓬> Values
  {
    get
    {
      lock (this.퓲퓍)
        return base.Values;
    }
  }

  public override IEnumerator<퓬> GetEnumerator()
  {
    lock (this.퓲퓍)
      return base.GetEnumerator();
  }

  public override bool 퓏([In] 퓏 obj0, out 퓬 _param2)
  {
    lock (this.퓲퓍)
      return base.퓏(obj0, out _param2);
  }
}
