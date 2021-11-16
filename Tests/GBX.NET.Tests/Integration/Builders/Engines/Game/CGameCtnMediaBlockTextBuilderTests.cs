﻿using GBX.NET.Builders;
using GBX.NET.Builders.Engines.Control;
using GBX.NET.Builders.Engines.Game;
using GBX.NET.Engines.Control;
using GBX.NET.Engines.Game;
using GBX.NET.Tests.Integration.Builders.Engines.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GBX.NET.Tests.Integration.Builders.Engines.Game;

public class CGameCtnMediaBlockTextBuilderTests
{
    public static string GetSampleText() => "Random Text";
    public static CControlEffectSimi.Key[] GetSampleKeys() => CControlEffectSimiBuilderTests.GetSampleKeys();
    public static CControlEffectSimi GetSampleEffect() => CControlEffectSimi.Create()
        .WithKeys(GetSampleKeys())
        .ForTM2()
        .Build();

    private static CGameCtnMediaBlockText BuildNode(Func<ICGameCtnMediaBlockTextBuilderFor,
        GameBuilder<ICGameCtnMediaBlockTextBuilder, CGameCtnMediaBlockText>> func, string text, CControlEffectSimi effect)
    {
        var builder = new CGameCtnMediaBlockTextBuilder()
            .WithText(text)
            .WithEffect(effect);
        return func.Invoke(builder).Build();
    }

    private static void ForX_ParametersShouldMatch(Func<ICGameCtnMediaBlockTextBuilderFor,
        GameBuilder<ICGameCtnMediaBlockTextBuilder, CGameCtnMediaBlockText>> func)
    {
        var text = GetSampleText();
        var effect = GetSampleEffect();

        var node = BuildNode(func, text, effect);

        Assert.Equal(expected: text, actual: node.Text);
        Assert.Equal(expected: effect, actual: node.Effect);
    }

    private static void ForX_ChunksShouldMatch(Func<ICGameCtnMediaBlockTextBuilderFor,
        GameBuilder<ICGameCtnMediaBlockTextBuilder, CGameCtnMediaBlockText>> func, Action<CGameCtnMediaBlockText> chunkAssert)
    {
        var text = GetSampleText();
        var effect = GetSampleEffect();

        var node = BuildNode(func, text, effect);
        chunkAssert.Invoke(node);
    }

    [Fact] public void ForTMSX_ParametersShouldMatch() => ForX_ParametersShouldMatch(x => x.ForTMSX());
    [Fact] public void ForTMU_ParametersShouldMatch() => ForX_ParametersShouldMatch(x => x.ForTMU());
    [Fact] public void ForTMUF_ParametersShouldMatch() => ForX_ParametersShouldMatch(x => x.ForTMUF());
    [Fact] public void ForTM2_ParametersShouldMatch() => ForX_ParametersShouldMatch(x => x.ForTM2());

    [Fact]
    public void ForTMSX_ChunksShouldMatch()
    {
        ForX_ChunksShouldMatch(x => x.ForTMSX(), node =>
        {
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8001>());
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8002>());
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8003>());
        });
    }

    [Fact]
    public void ForTMU_ChunksShouldMatch()
    {
        ForX_ChunksShouldMatch(x => x.ForTMU(), node =>
        {
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8001>());
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8002>());
        });
    }

    [Fact]
    public void ForTMUF_ChunksShouldMatch()
    {
        ForX_ChunksShouldMatch(x => x.ForTMUF(), node =>
        {
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8001>());
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8002>());
        });
    }

    [Fact]
    public void ForTM2_ChunksShouldMatch()
    {
        ForX_ChunksShouldMatch(x => x.ForTM2(), node =>
        {
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8001>());
            Assert.NotNull(node.GetChunk<CGameCtnMediaBlockText.Chunk030A8002>());
        });
    }
}