﻿namespace GBX.NET.Engines.Scene;

/// <remarks>ID: 0x0A005000</remarks>
[Node(0x0A005000)]
public abstract class CSceneObject : CMwNod
{
    protected CSceneObject()
    {

    }

    /// <summary>
    /// CSceneObject 0x001 chunk
    /// </summary>
    [Chunk(0x0A005001)]
    public class Chunk0A005001 : Chunk<CSceneObject>
    {
        public string? U01;

        public override void ReadWrite(CSceneObject n, GameBoxReaderWriter rw)
        {
            rw.Id(ref U01);
        }
    }

    /// <summary>
    /// CSceneObject 0x002 chunk
    /// </summary>
    [Chunk(0x0A005002)]
    public class Chunk0A005002 : Chunk<CSceneObject>
    {
        public bool U01;

        public override void ReadWrite(CSceneObject n, GameBoxReaderWriter rw)
        {
            rw.Boolean(ref U01);
        }
    }

    /// <summary>
    /// CSceneObject 0x003 chunk
    /// </summary>
    [Chunk(0x0A005003)]
    public class Chunk0A005003 : Chunk<CSceneObject>
    {
        public CMwNod? U01;

        public override void ReadWrite(CSceneObject n, GameBoxReaderWriter rw)
        {
            rw.NodeRef(ref U01); // CMotion?
        }
    }

    /// <summary>
    /// CSceneObject 0x004 chunk
    /// </summary>
    [Chunk(0x0A005004)]
    public class Chunk0A005004 : Chunk<CSceneObject>
    {
        public int U01;

        public override void ReadWrite(CSceneObject n, GameBoxReaderWriter rw)
        {
            rw.Int32(ref U01);
        }
    }
}
