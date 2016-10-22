﻿namespace CoCSharp.Network.Messages
{
    /// <summary>
    /// Message that is sent by the client to server to ask
    /// for the profile of an avatar.
    /// </summary>
    public class AvatarProfileRequestMessage : Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarProfileRequestMessage"/> class.
        /// </summary>
        public AvatarProfileRequestMessage()
        {
            // Space
        }

        /// <summary>
        /// Gets the ID of the <see cref="AvatarProfileRequestMessage"/>.
        /// </summary>
        public override ushort ID { get { return 14325; } }

        /// <summary>
        /// User ID of avatar whose profile was requested.
        /// </summary>
        public long UserID;
        /// <summary>
        /// User ID of avatar whose profile was requested again?
        /// Might be Home ID.
        /// </summary>
        public long UserID2;

        /// <summary>
        /// Unknown byte 1.
        /// </summary>
        public byte Unknown1;

        /// <summary>
        /// Reads the <see cref="AvatarProfileRequestMessage"/> from the specified <see cref="MessageReader"/>.
        /// </summary>
        /// <param name="reader">
        /// <see cref="MessageReader"/> that will be used to read the <see cref="AvatarProfileRequestMessage"/>.
        /// </param>
        public override void ReadMessage(MessageReader reader)
        {
            UserID = reader.ReadInt64();
            if (reader.ReadBoolean())
                UserID2 = reader.ReadInt64();

            Unknown1 = reader.ReadByte();
        }

        /// <summary>
        /// Writes the <see cref="AvatarProfileRequestMessage"/> to the specified <see cref="MessageWriter"/>.
        /// </summary>
        /// <param name="writer">
        /// <see cref="MessageWriter"/> that will be used to write the <see cref="AvatarProfileRequestMessage"/>.
        /// </param>
        public override void WriteMessage(MessageWriter writer)
        {
            writer.Write(UserID);
            if (UserID2 != 0)
                writer.Write(UserID2);

            writer.Write(Unknown1);
        }
    }
}
