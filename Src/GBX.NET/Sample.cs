namespace GBX.NET;

public class Sample
{
    public TimeInt32? Timestamp { get; internal set; }

    public byte? BufferType { get; set; }
    public Vec3 Position { get; set; }
    public Quat Rotation { get; set; }
    public Vec3 PitchYawRoll => Rotation.ToPitchYawRoll();
    public float Speed { get; set; }
    public Vec3 Velocity { get; set; }
    public float? Gear { get; set; }
    public byte? RPM { get; set; }
    public float? Steer { get; set; }
    public float? Brake { get; set; }
    public float? Gas { get; set; }

    public byte[] Data { get; set; }

    public Sample(byte[] data)
    {
        Data = data;
    }

    public override string ToString()
    {
        if (!BufferType.HasValue || BufferType == 0 || BufferType == 2 || BufferType == 4)
        {
            if (Timestamp.HasValue)
                return $"Sample: {Timestamp.ToTmString()} {Position}";
            return $"Sample: {Position}";
        }

        return $"Sample: {BufferType.ToString() ?? "unknown"}";
    }
}
