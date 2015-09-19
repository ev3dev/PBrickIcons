using System;
using System.Runtime.InteropServices;

using Microsoft.Deployment.WindowsInstaller;

using DWORD = System.UInt32;
using HANDLE = System.IntPtr;
using HRESULT = System.Int32;
using PWSTR = System.IntPtr;
using REFKNOWNFOLDERID = System.Guid;

namespace DeviceMetadataStoreCustomAction
{
    public class CustomActions
    {
        // https://msdn.microsoft.com/en-us/library/dd378457%28v=vs.85%29.aspx
        readonly static REFKNOWNFOLDERID FOLDERID_DeviceMetadataStore = new Guid("5CE4A5E9-E4EB-479D-B89F-130C02886155");

        /// <summary>
        /// Looks up system path for Device Metadata Store and sets DeviceMetadataStorePath property to that value.
        /// </summary>
        /// <param name="session">The session passed from the installer.</param>
        /// <returns>Success or failure.</returns>
        [CustomAction]
        public static ActionResult SetDeviceMetadataStorePath(Session session)
        {
            session.Log("Begin Device Metadata Store Lookup");
            PWSTR pathPtr;
            var result = SHGetKnownFolderPath(FOLDERID_DeviceMetadataStore, 0, HANDLE.Zero, out pathPtr);
            if (FAILED(result)) {
                session.Log("Device Metadata Store Lookup failed with error: {0}", result);
                return ActionResult.Failure;
            }
            string path = Marshal.PtrToStringUni(pathPtr);
            Marshal.FreeCoTaskMem(pathPtr);

            session["DeviceMetadataStorePath"] = path;
            session.Log("Device Metadata Store path is: {0}", path);

            return ActionResult.Success;
        }

        // http://www.pinvoke.net/default.aspx/shell32/SHGetKnownFolderPath.html
        // https://msdn.microsoft.com/en-us/library/bb762188%28VS.85%29.aspx
        [DllImport("Shell32.dll")]
        static extern HRESULT SHGetKnownFolderPath(
          [MarshalAs(UnmanagedType.LPStruct)] REFKNOWNFOLDERID rfid,
          DWORD dwFlags,
          HANDLE hToken,
          out PWSTR ppszPath
        );

        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms693474%28v=vs.85%29.aspx
        static bool FAILED(HRESULT hr)
        {
            return hr < 0;
        }
    }
}
