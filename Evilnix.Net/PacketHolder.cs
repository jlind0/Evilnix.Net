using System;
using System.Collections.Generic;
using System.Text;

namespace Evilnix.Net
{
    public class Packeter<TPacket, TSerializer>
        where TPacket : BasePacket, new()
        where TSerializer : ISerializer
    {
        protected ISerializer Serializer { get; private set; }
        public TPacket Packet { get; protected set; }
        public Packeter(TSerializer serializer, string senderId, PacketType packetType = default(PacketType))
        {
            this.Serializer = serializer;
            this.Packet = new TPacket()
            {
                SenderId = senderId,
                PacketType = packetType
            };
        }
        public virtual byte[] Serialize()
        {
            return this.Serializer.Serialize(this.Packet);
        }
        public virtual void Deserialize(byte[] data)
        {
            this.Packet = this.Serializer.Deserialize<TPacket>(data);
        }
    }
}
