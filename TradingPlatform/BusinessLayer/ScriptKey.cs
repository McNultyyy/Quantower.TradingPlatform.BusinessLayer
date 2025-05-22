// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ScriptKey
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public struct ScriptKey
{
  private const string 퓬퓙 = "|";

  public string[] FoldersHierarchy { get; [param: In] private set; }

  internal ScriptCreationType ScriptCreationType { get; [param: In] private set; }

  internal string RelativePath { get; [param: In] private set; }

  internal string AssemblyName { get; [param: In] private set; }

  internal string ScriptName { get; [param: In] private set; }

  public ScriptKey(
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName,
    string scriptName)
    : this()
  {
    this.ScriptCreationType = scriptCreationType;
    this.RelativePath = relativePath;
    this.AssemblyName = assemblyName;
    this.ScriptName = scriptName;
    this.FoldersHierarchy = relativePath.Split(new char[1]
    {
      Path.DirectorySeparatorChar
    }, StringSplitOptions.RemoveEmptyEntries);
  }

  public override bool Equals(object obj)
  {
    ScriptKey scriptKey = (ScriptKey) obj;
    return !(this.ScriptName != scriptKey.ScriptName) && !(this.AssemblyName != scriptKey.AssemblyName) && !(this.RelativePath != scriptKey.RelativePath) && this.ScriptCreationType == scriptKey.ScriptCreationType;
  }

  public override int GetHashCode()
  {
    return (((-2128831035 * 16777619 ^ this.ScriptCreationType.GetHashCode()) * 16777619 ^ (this.RelativePath ?? string.Empty).GetHashCode()) * 16777619 ^ (this.AssemblyName ?? string.Empty).GetHashCode()) * 16777619 ^ (this.ScriptName ?? string.Empty).GetHashCode();
  }

  public static bool operator !=(ScriptKey key1, ScriptKey key2) => !key1.Equals((object) key2);

  public static bool operator ==(ScriptKey key1, ScriptKey key2) => key1.Equals((object) key2);

  public static ScriptKey CreateScriptKeyFromString(string stringKey)
  {
    string[] strArray = stringKey.Split(new string[1]
    {
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픟()
    }, StringSplitOptions.None);
    ScriptCreationType enumValue;
    return strArray.Length != 4 || !strArray[0].TryParseEnum<ScriptCreationType, DescriptionAttribute>((Func<DescriptionAttribute, string>) (([In] obj0) => obj0.Description), out enumValue) ? new ScriptKey() : new ScriptKey(enumValue, strArray[1], strArray[2], strArray[3]);
  }

  public override string ToString()
  {
    return $"{this.ScriptCreationType.GetDescription()}{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픟()}{this.RelativePath}{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픟()}{this.AssemblyName}{\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픟()}{this.ScriptName}";
  }
}
