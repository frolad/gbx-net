﻿namespace GBX.NET.Engines.Plug;

/// <summary>
/// Bitmap address.
/// </summary>
/// <remarks>ID: 0x09047000</remarks>
[Node(0x09047000)]
public class CPlugBitmapAddress : CPlugBitmapSampler
{
    protected CPlugBitmapAddress()
    {

    }

    /// <summary>
    /// CPlugBitmapAddress 0x002 chunk
    /// </summary>
    [Chunk(0x09047002)]
    public class Chunk09047002 : Chunk<CPlugBitmapAddress>
    {
        public int U01;

        public override void ReadWrite(CPlugBitmapAddress n, GameBoxReaderWriter rw)
        {
            rw.Int32(ref U01); // SBitmapElemToPack array?
        }
    }

    /// <summary>
    /// CPlugBitmapAddress 0x005 chunk
    /// </summary>
    [Chunk(0x09047005)]
    public class Chunk09047005 : Chunk<CPlugBitmapAddress>
    {
        public byte[]? U01;

        public override void ReadWrite(CPlugBitmapAddress n, GameBoxReaderWriter rw)
        {
            rw.Bytes(ref U01, count: 21);
        }
    }

    /// <summary>
    /// CPlugBitmapAddress 0x007 chunk
    /// </summary>
    [Chunk(0x09047007)]
    public class Chunk09047007 : Chunk<CPlugBitmapAddress>
    {
        public int U01;
        public int U02;
        public byte U03;

        public override void ReadWrite(CPlugBitmapAddress n, GameBoxReaderWriter rw)
        {
            rw.Int32(ref U01);
            rw.Int32(ref U02);
            rw.Byte(ref U03);
        }
    }

    /// <summary>
    /// CPlugBitmapAddress 0x008 chunk
    /// </summary>
    [Chunk(0x09047008)]
    public class Chunk09047008 : Chunk<CPlugBitmapAddress>
    {
        public int U01;
        public float U02;

        public override void ReadWrite(CPlugBitmapAddress n, GameBoxReaderWriter rw)
        {
            rw.Int32(ref U01); // ArchiveCountAndElems SMapFxDescOld/SBitmapElemToPack count*0x14
            rw.Single(ref U02);
        }
    }
}
