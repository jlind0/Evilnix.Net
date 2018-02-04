using System;
using System.Collections.Generic;
using System.Text;

namespace Evilnix.Net
{
    [Serializable]
    public abstract class BasePacket
    {
        public IEnumerable<string> Data { get; set; } = new List<string>();
        public string SenderId { get; set; }
        public PacketType PacketType { get; set; }
    }
    [Serializable]
    public class Packet : BasePacket
    {
        public int SocketInt { get; set; }
        public int SocketBool { get; set; }
    }
    [Serializable]
    public class MotionPacket : BasePacket
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public enum PacketType
    {
        Registration,
        Chat
    }
}
