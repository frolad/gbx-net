﻿namespace GBX.NET.Engines.Game;

/// <summary>
/// MediaTracker block - Dirty lens.
/// </summary>
/// <remarks>ID: 0x03165000</remarks>
[Node(0x03165000)]
[NodeExtension("GameCtnMediaBlockDirtyLens")]
public partial class CGameCtnMediaBlockDirtyLens : CGameCtnMediaBlock, CGameCtnMediaBlock.IHasKeys
{
    #region Fields

    private IList<Key> keys;

    #endregion

    #region Properties

    IEnumerable<CGameCtnMediaBlock.Key> IHasKeys.Keys
    {
        get => keys.Cast<CGameCtnMediaBlock.Key>();
        set => keys = value.Cast<Key>().ToList();
    }

    [NodeMember]
    public IList<Key> Keys
    {
        get => keys;
        set => keys = value;
    }

    #endregion

    #region Constructors

    protected CGameCtnMediaBlockDirtyLens()
    {
        keys = null!;
    }

    #endregion

    #region Chunks

    #region 0x000 chunk

    /// <summary>
    /// CGameCtnMediaBlockDirtyLens 0x000 chunk
    /// </summary>
    [Chunk(0x03165000)]
    public class Chunk03165000 : Chunk<CGameCtnMediaBlockDirtyLens>, IVersionable
    {
        private int version;

        public int Version { get => version; set => version = value; }

        public override void ReadWrite(CGameCtnMediaBlockDirtyLens n, GameBoxReaderWriter rw)
        {
            rw.Int32(ref version);
            rw.ListKey(ref n.keys!);
        }
    }

    #endregion

    #endregion
}
