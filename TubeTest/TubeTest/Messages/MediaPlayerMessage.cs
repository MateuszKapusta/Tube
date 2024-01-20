using CommunityToolkit.Mvvm.Messaging.Messages;
using TubeTest.Models;

namespace TubeTest.Messages
{
    public class MediaPlayerMessage : ValueChangedMessage<PlayerStatus>
    {
        public MediaPlayerMessage(PlayerStatus value) : base(value)
        {
        }
    }
}
