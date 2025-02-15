﻿namespace GBX.NET;

/// <summary>
/// Identifies that the node can include user data in the serialized form.
/// </summary>
public interface INodeHeader
{
    public HeaderChunkSet HeaderChunks { get; }
    GameBox? GetGbx();
}
