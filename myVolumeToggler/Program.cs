using System;
using System.Runtime.InteropServices;
using System.Media;

namespace myVolumeToggler
{
	class Program
	{
		static void Main(string[] args)
		{
			float setVol = 1.0f;
			
			
			IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
			deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out IMMDevice speakers);
			Guid IID_IAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
			speakers.Activate(ref IID_IAudioSessionManager2, 0, IntPtr.Zero, out object o);
			IAudioSessionManager2 mgr = (IAudioSessionManager2)o;
			mgr.GetSessionEnumerator(out IAudioSessionEnumerator sessionEnumerator);

			sessionEnumerator.GetCount(out int count);

			Boolean first = true;
			for (int i = 0; i < count; i++)
			{
				sessionEnumerator.GetSession(i, out IAudioSessionControl ctl);
				Guid guid = Guid.Empty;
				ISimpleAudioVolume temp = ctl as ISimpleAudioVolume;
				if (first)
				{
					temp.GetMasterVolume(out float chkVol);

					if (chkVol == 1.0f)
					{
						SystemSounds.Exclamation.Play();
						setVol = 0.1f;
					}
					first = false;
				}
				
				/*ctl.GetDisplayName(out string dn);
				Debug.WriteLine(i + " : " + dn);*/
				
				temp.SetMasterVolume(setVol, ref guid);
				Marshal.ReleaseComObject(ctl);
			}
			Marshal.ReleaseComObject(sessionEnumerator);
			Marshal.ReleaseComObject(mgr);
			Marshal.ReleaseComObject(speakers);
			Marshal.ReleaseComObject(deviceEnumerator);
		}
	}

	[ComImport]
	[Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
	internal class MMDeviceEnumerator
	{
	}

	internal enum EDataFlow
	{
		eRender,
		eCapture,
		eAll,
		EDataFlow_enum_count
	}

	internal enum ERole
	{
		eConsole,
		eMultimedia,
		eCommunications,
		ERole_enum_count
	}

	[Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IMMDeviceEnumerator
	{
		int NotImpl1();

		[PreserveSig]
		int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppDevice);

		// the rest is not implemented
	}

	[Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IMMDevice
	{
		[PreserveSig]
		int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);

		// the rest is not implemented
	}

	[Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IAudioSessionManager2
	{
		int NotImpl1();
		int NotImpl2();

		[PreserveSig]
		int GetSessionEnumerator(out IAudioSessionEnumerator SessionEnum);

		// the rest is not implemented
	}

	[Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IAudioSessionEnumerator
	{
		[PreserveSig]
		int GetCount(out int SessionCount);

		[PreserveSig]
		int GetSession(int SessionCount, out IAudioSessionControl Session);
	}

	[Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IAudioSessionControl
	{
		int NotImpl1();

		[PreserveSig]
		int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

		// the rest is not implemented
	}

	[Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface ISimpleAudioVolume
	{
		[PreserveSig]
		int SetMasterVolume(float fLevel, ref Guid EventContext);

		[PreserveSig]
		int GetMasterVolume(out float pfLevel);

		/*[PreserveSig]
		int SetMute(bool bMute, ref Guid EventContext);

		[PreserveSig]
		int GetMute(out bool pbMute);*/
	}
}