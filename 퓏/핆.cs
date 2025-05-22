// Decompiled with JetBrains decompiler
// Type: 퓏.핆
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using TradingPlatform.BusinessLayer.Licence;

#nullable disable
namespace 퓏;

internal sealed class 핆 : JsonConverter<LicenceItem>
{
  private const string 퓲픍 = "StartDateTicks";
  private const string 퓲픆 = "EndDateTicks";

  public override LicenceItem Read(
    ref Utf8JsonReader reader,
    Type type,
    JsonSerializerOptions options)
  {
    string str1 = (string) null;
    string empty = string.Empty;
    string str2 = (string) null;
    DateTime dateTime1 = new DateTime();
    DateTime dateTime2 = new DateTime();
    while (reader.Read())
    {
      JsonTokenType tokenType = reader.TokenType;
      switch (tokenType)
      {
        case JsonTokenType.None:
        case JsonTokenType.StartObject:
        case JsonTokenType.StartArray:
        case JsonTokenType.EndArray:
        case JsonTokenType.Comment:
        case JsonTokenType.True:
        case JsonTokenType.False:
        case JsonTokenType.Null:
          continue;
        case JsonTokenType.EndObject:
          return new LicenceItem()
          {
            LicenceKey = empty,
            Value = str2,
            StartDate = dateTime1,
            EndDate = dateTime2
          };
        case JsonTokenType.PropertyName:
          str1 = reader.GetString();
          continue;
        case JsonTokenType.String:
          if (!(str1 == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓔()))
          {
            if (str1 == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣())
            {
              str2 = reader.GetString();
              continue;
            }
            continue;
          }
          empty = reader.GetString();
          continue;
        case JsonTokenType.Number:
          if (!(str1 == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픢()))
          {
            if (str1 == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓝())
            {
              dateTime2 = new DateTime(reader.GetInt64(), DateTimeKind.Utc);
              continue;
            }
            continue;
          }
          dateTime1 = new DateTime(reader.GetInt64(), DateTimeKind.Utc);
          continue;
        default:
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓶());
          interpolatedStringHandler.AppendFormatted<JsonTokenType>(tokenType);
          throw new ArgumentOutOfRangeException(interpolatedStringHandler.ToStringAndClear());
      }
    }
    return (LicenceItem) null;
  }

  public override void Write(
    Utf8JsonWriter writer,
    LicenceItem value,
    JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓔(), value.LicenceKey);
    writer.WriteString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓣(), value.LicenceKey);
    writer.WriteNumber(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픢(), value.StartDate.Ticks);
    writer.WriteNumber(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓝(), value.EndDate.Ticks);
    writer.WriteEndObject();
  }
}
