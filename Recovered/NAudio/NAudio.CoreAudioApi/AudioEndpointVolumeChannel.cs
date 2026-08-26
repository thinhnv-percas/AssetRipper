using NAudio.CoreAudioApi.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeChannel
	{
		private readonly uint channel;

		private readonly IAudioEndpointVolume audioEndpointVolume;

		private Guid notificationGuid = Guid.Empty;

		public Guid NotificationGuid
		{
			get
			{
				return notificationGuid;
			}
			set
			{
				notificationGuid = value;
			}
		}

		public float VolumeLevel
		{
			get
			{
				Marshal.ThrowExceptionForHR(audioEndpointVolume.GetChannelVolumeLevel(channel, out float pfLevelDB));
				return pfLevelDB;
			}
			set
			{
				Marshal.ThrowExceptionForHR(audioEndpointVolume.SetChannelVolumeLevel(channel, value, ref notificationGuid));
			}
		}

		public float VolumeLevelScalar
		{
			get
			{
				Marshal.ThrowExceptionForHR(audioEndpointVolume.GetChannelVolumeLevelScalar(channel, out float pfLevel));
				return pfLevel;
			}
			set
			{
				Marshal.ThrowExceptionForHR(audioEndpointVolume.SetChannelVolumeLevelScalar(channel, value, ref notificationGuid));
			}
		}

		internal AudioEndpointVolumeChannel(IAudioEndpointVolume parent, int channel)
		{
			this.channel = (uint)channel;
			audioEndpointVolume = parent;
		}
	}
}
