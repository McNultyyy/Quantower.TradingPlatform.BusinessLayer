// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Chart.DrawingType
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using System.ComponentModel;
using System.Reflection;

#nullable disable
namespace TradingPlatform.BusinessLayer.Chart;

[Obfuscation(ApplyToMembers = true, Exclude = true)]
public enum DrawingType
{
  [Description("Trading tool")] TradingTool = 0,
  [Description("Horizontal line")] HorizontalLine = 1,
  [Description("Vertical line")] VerticalLine = 2,
  [Description("Line")] Line = 3,
  [Description("Rectangle")] Rectangle = 4,
  [Description("Triangle")] Triangle = 5,
  [Description("Poligon")] Polygon = 6,
  [Description("Circle")] Circle = 7,
  [Description("Ellipse")] Ellipse = 8,
  [Description("Andrew's pitchfork")] AndrewsPitchFork = 9,
  [Description("Price channel")] PriceChannel = 10, // 0x0000000A
  [Description("Fibonacci retracement")] FibonacciRetracement = 11, // 0x0000000B
  [Description("Fibonacci price expansion")] FibonacciPriceExpansion = 12, // 0x0000000C
  [Description("Fibonacci arc")] FibonacciArc = 13, // 0x0000000D
  [Description("Fibonacci spiral")] FibonacciSpiral = 14, // 0x0000000E
  [Description("Fibonacci ellipse")] FibonacciEllipse = 15, // 0x0000000F
  [Description("Fibonacci fans")] FibonacciFans = 16, // 0x00000010
  [Description("Fibonacci phi-channel")] FibonacciPhiChannel = 17, // 0x00000011
  [Description("Fibonacci time extension")] FibonacciTimeExtension = 18, // 0x00000012
  [Description("Fibonacci time zone")] FibonacciTimeZone = 19, // 0x00000013
  [Description("Gann line")] GannLine = 20, // 0x00000014
  [Description("Gann fan")] GannFan = 21, // 0x00000015
  [Description("Gann grid")] GannGrid = 22, // 0x00000016
  [Description("Ruler")] InfoLine = 23, // 0x00000017
  [Description("Symbol")] Symbol = 24, // 0x00000018
  [Description("Text")] Text = 25, // 0x00000019
  [Description("Up arrow")] UpArrow = 26, // 0x0000001A
  [Description("Down arrow")] DownArrow = 27, // 0x0000001B
  [Description("Uncpecified")] Unspecified = 28, // 0x0000001C
  [Description("Label")] Label = 29, // 0x0000001D
  [Description("Line by angle")] LineByAngle = 30, // 0x0000001E
  [Description("Regression channel")] RegressionChanel = 31, // 0x0000001F
  [Description("ABC Pattern")] ABCPatern = 32, // 0x00000020
  [Description("Gartley Butterfly")] ButterflyGartley = 35, // 0x00000023
  [Description("Custom profile")] CustomProfile = 36, // 0x00000024
  [Description("Line arrow")] LineArrow = 37, // 0x00000025
  [Description("Head&Shoulders")] HeadAndShoulders = 38, // 0x00000026
  [Description("Gann box")] GannBox = 39, // 0x00000027
  [Description("Price targets")] PriceTargets = 40, // 0x00000028
  [Description("Flag marker")] FlagMarker = 41, // 0x00000029
  [Description("Price marker")] PriceMarker = 42, // 0x0000002A
  [Description("Note")] NoteMarker = 43, // 0x0000002B
  [Description("Comment")] Comment = 44, // 0x0000002C
  [Description("Angled line")] AngledLine = 45, // 0x0000002D
  [Description("Horizontal alert")] AlertHorizontalLine = 46, // 0x0000002E
  [Description("Elliot triangle wave")] ElliotTriangleWave = 47, // 0x0000002F
  [Description("Three drives pattern")] ThreeDrivesPattern = 48, // 0x00000030
  [Description("Triangle pattern")] TrianglePattern = 49, // 0x00000031
  [Description("TPA Strategy")] TPAStrategy = 50, // 0x00000032
  [Description("Anchor VWAP")] CustomVWAP = 51, // 0x00000033
  [Description("Whale Splash")] WhaleSplash = 52, // 0x00000034
  [Description("Fibonacci time expansion")] FibonacciTimeExpansion = 53, // 0x00000035
  [Description("Fibonacci price extension")] FibonacciPriceExtension = 54, // 0x00000036
  [Description("Minotauro Fibonacci price extension")] MinotauroFibonacciPriceExtension = 55, // 0x00000037
  [Description("Minotauro Move Up")] MinotauroFibonacciRetracementMoveUp = 56, // 0x00000038
  [Description("Minotauro Move Down")] MinotauroFibonacciRetracementMoveDown = 57, // 0x00000039
  [Description("POC line")] POCLine = 58, // 0x0000003A
  [Description("Week POC line")] WeekPOCLine = 59, // 0x0000003B
  [Description("VIP Analysis")] VIPAnalysis = 60, // 0x0000003C
  [Description("Brush")] Brush = 61, // 0x0000003D
  [Description("Marker")] Marker = 62, // 0x0000003E
  [Description("Cross line")] CrossLine = 63, // 0x0000003F
  [Description("Vertical alert")] AlertVerticalLine = 64, // 0x00000040
}
