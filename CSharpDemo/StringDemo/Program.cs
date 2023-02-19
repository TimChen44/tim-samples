//C# 语言--一些提高代码质量的小方法
//https://www.bilibili.com/video/BV1Gf4y187dk/?vd_source=cc25b2d81ad209c8003d1886d9140b31

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

var str1 = @"超超 TimChen44
            点赞😁
            投币😁
            收藏😁
";

var str2 = """
        超超 TimChen44"
        点赞😁
        投币😁
        收藏😁
        """;

var coin = "两个币";
var str3 = $"""
        超超 TimChen44
        点赞😁
        投币😁{coin}
        收藏😁
        """;

var str4 = """"
        超超 TimChen44"""
        点赞😁
        投币😁
        收藏😁
        """";
var ss = str4;

//Docs：https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals?WT.mc_id=DT-MVP-5004310
