﻿namespace GBX.NET.Attributes;

/// <summary>
/// Tells which chunk is used to write a certain node member.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class AppliedWithChunkAttribute : Attribute
{
    /// <summary>
    /// Type of the chunk.
    /// </summary>
    public Type ChunkType { get; }

    /// <summary>
    /// Since which version this member is written to the chunk. Ignored on chunks without <see cref="IVersionable"/>.
    /// </summary>
    public int SinceVersion { get; }

    /// <summary>
    /// Up to which version the member is written to the chunk. Null means there's no known version limit. Ignored on chunks without <see cref="IVersionable"/>.
    /// </summary>
    public int? UpToVersion { get; }

    /// <summary>
    /// Creates the <see cref="AppliedWithChunkAttribute"/>.
    /// </summary>
    /// <param name="chunkType">Type of the chunk.</param>
    /// <param name="sinceVersion">Since which version this member is written to the chunk. Can be ignored on chunks without <see cref="IVersionable"/>.</param>
    public AppliedWithChunkAttribute(Type chunkType, int sinceVersion = 0)
    {
        ChunkType = chunkType;
        SinceVersion = sinceVersion;
    }

    /// <summary>
    /// Creates the <see cref="AppliedWithChunkAttribute"/>.
    /// </summary>
    /// <param name="chunkType">Type of the chunk.</param>
    /// <param name="sinceVersion">Since which version this member is written to the chunk. Can be ignored on chunks without <see cref="IVersionable"/>.</param>
    /// <param name="upToVersion">Up to which version the member is written to the chunk. Can be ignored on chunks without <see cref="IVersionable"/>.</param>
    public AppliedWithChunkAttribute(Type chunkType, int sinceVersion, int upToVersion) : this(chunkType, sinceVersion)
    {
        UpToVersion = upToVersion;
    }
}
