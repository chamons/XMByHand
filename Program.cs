using System;
using System.IO;
using System.Runtime.InteropServices;
using AppKit;

namespace XMByHand
{
	class MainClass
	{
		[DllImport ("/usr/lib/libSystem.dylib")]
		static extern IntPtr dlopen (string path, int mode);

		[DllImport ("/usr/lib/libSystem.dylib")]
		static extern IntPtr dlerror ();

		public static void Main (string[] args)
		{
			var dylibPath = Path.Combine ("/Library/Frameworks/Xamarin.Mac.framework/Versions/Current/lib/libxammac.dylib");
			if (dlopen (dylibPath, 0) == IntPtr.Zero) {
				var errPtr = dlerror ();
				var errStr = (errPtr == IntPtr.Zero) ? "<unknown error>" : Marshal.PtrToStringAnsi (errPtr);
				Console.WriteLine ("WARNING: Cannot load {0}: {1}", dylibPath, errStr);
			}

			NSApplication.Init ();
			var v = NSApplication.SharedApplication;
			Console.WriteLine (v == null);
		}
	}
}
