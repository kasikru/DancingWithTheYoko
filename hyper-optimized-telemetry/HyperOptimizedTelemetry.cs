using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var ret = new byte[9];

        if (reading >= short.MinValue && reading <= ushort.MaxValue)
        {
            ret[0] = 2;
        }
        else if (reading >= int.MinValue && reading <= uint.MaxValue)
        {
            ret[0] = 4;
        }
        else
        {
            ret[0] = 8;
        }

        Array.Copy(BitConverter.GetBytes(reading), 0, ret, 1, ret[0]);

        if (reading is < 0 or > ushort.MaxValue and <= int.MaxValue or > uint.MaxValue)
        {
            ret[0] = (byte)(-ret[0]);
        }
        
        return ret;
    }
    
    public static long FromBuffer(byte[] buffer)
    {
        return (sbyte)buffer[0] switch
        {
            -8 => BitConverter.ToInt64(buffer, 1),
            -4 => BitConverter.ToInt32(buffer, 1),
            -2 => BitConverter.ToInt16(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            _ => 0
        };
    }
}
