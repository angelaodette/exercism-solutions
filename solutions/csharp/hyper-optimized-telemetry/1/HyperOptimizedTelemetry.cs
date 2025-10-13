public static class TelemetryBuffer
{
    // 9-byte frame: [0]=prefix; [1..8]=LE value occupying N∈{2,4,8} bytes; rest zero
    // prefix: unsigned => N; signed => 256 - N
    public static byte[] ToBuffer(long reading)
    {
        int nBytes;
        bool isSigned;

        if (reading < 0)
        {
            // Negative → minimal SIGNED among {2,4,8}
            if (reading >= short.MinValue) { nBytes = 2; isSigned = true; }
            else if (reading >= int.MinValue) { nBytes = 4; isSigned = true; }
            else { nBytes = 8; isSigned = true; }
        }
        else
        {
            // Non-negative:
            // 1) 0..65535 -> 2-byte UNSIGNED
            // 2) 65536..Int32.MaxValue -> 4-byte SIGNED (matches your int test)
            // 3) (Int32.MaxValue+1)..UInt32.MaxValue -> 4-byte UNSIGNED
            // 4) > UInt32.MaxValue -> 8-byte SIGNED
            ulong u = (ulong)reading;

            if (u <= ushort.MaxValue)              { nBytes = 2; isSigned = false; }
            else if (reading <= int.MaxValue)      { nBytes = 4; isSigned = true;  }
            else if (u <= uint.MaxValue)           { nBytes = 4; isSigned = false; }
            else                                   { nBytes = 8; isSigned = true;  }
        }

        byte prefix = isSigned ? (byte)(256 - nBytes) : (byte)nBytes;

        var frame = new byte[9];
        frame[0] = prefix;

        // Write N least-significant bytes of the two's-complement pattern, LE
        ulong bits = unchecked((ulong)reading);
        for (int i = 0; i < nBytes; i++)
            frame[1 + i] = (byte)(bits >> (8 * i));

        return frame;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];

        bool isSigned;
        int nBytes;

        if (prefix == 1 || prefix == 2 || prefix == 4 || prefix == 8)
        {
            isSigned = false;
            nBytes = prefix;
        }
        else
        {
            // signed: prefix = 256 - N
            nBytes = 256 - prefix;
            if (nBytes != 1 && nBytes != 2 && nBytes != 4 && nBytes != 8)
                return 0;
            isSigned = true;
        }

        // Read little-endian value from bytes 1..N
        ulong val = 0;
        for (int i = 0; i < nBytes; i++)
        {
            val |= ((ulong)buffer[1 + i]) << (8 * i);
        }

        if (!isSigned)
        {
            // Zero-extend
            return unchecked((long)val);
        }
        else
        {
            // Sign-extend from N bytes
            int shift = (8 - nBytes) * 8;          // how many bits to shift to top
            long signed = unchecked((long)(val << shift)) >> shift;
            return signed;
        }
    }
}
