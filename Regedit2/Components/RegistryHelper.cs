namespace Regedit2.Components {
	using Microsoft.Win32;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Runtime.InteropServices;
	using System.Text;
	/// <summary>
	/// 
	/// </summary>
	public static class RegistryHelper {

		private const long ERROR_SUCCESS = 0x0;
		private const long FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
		private const long FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
		private const long FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;

		/// <summary>
		/// The format of the saved key or hive.
		/// </summary>
		private enum RegistryExportFormat {
			/// <summary>
			/// The key or hive is saved in standard format. The standard format is the only format supported by Windows 2000.
			/// </summary>
			REG_STANDARD_FORMAT = 1,
			/// <summary>
			/// The key or hive is saved in the latest format. The latest format is supported starting with Windows XP. After 
			/// the key or hive is saved in this format, it cannot be loaded on an earlier system.
			/// </summary>
			REG_LATEST_FORMAT = 2,
			/// <summary>
			/// The hive is saved with no compression, for faster save operations. The hKey parameter must specify the root 
			/// of a hive under HKEY_LOCAL_MACHINE  or HKEY_USERS. For example, HKLM\SOFTWARE  is the root of a hive.
			/// </summary>
			REG_NO_COMPRESSION = 4
		}

		private enum SECURITY_INFORMATION {
			OWNER_SECURITY_INFORMATION = 1,
			GROUP_SECURITY_INFORMATION = 2,
			DACL_SECURITY_INFORMATION = 4,
			SACL_SECURITY_INFORMATION = 8,
		}

		/*BOOL WINAPI GetSystemRegistryQuota(
			__out_opt  PDWORD pdwQuotaAllowed,
			__out_opt  PDWORD pdwQuotaUsed
		);*/
		/// <summary>
		/// Retrieves the current size of the registry and the maximum size that the registry is allowed to attain on the system.
		/// </summary>
		/// <param name="pdwQuotaAllowed">A pointer to a variable that receives the maximum size that the registry is allowed 
		/// to attain on this system, in bytes.</param>
		/// <param name="pdwQuotaUsed">A pointer to a variable that receives the current size of the registry, in bytes.</param>
		/// <returns>If the function succeeds, the return value is nonzero. 
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport ( "kernel32", EntryPoint = "GetSystemRegistryQuota" )]
		private static extern long GetSystemRegistryQuota ( [Out] out long pdwQuotaAllowed, [Out] out long pdwQuotaUsed );

		/*LONG WINAPI RegCopyTree(
			__in      HKEY hKeySrc,
			__in_opt  LPCTSTR lpSubKey,
			__in      HKEY hKeyDest
		);*/
		/// <summary>
		/// Copies the specified registry key, along with its values and subkeys, to the specified destination key.
		/// </summary>
		/// <param name="hKeySrc">A handle to an open registry key. The key must have been opened with the KEY_READ access 
		/// right. For more information, see Registry Key Security and Access Rights.</param>
		/// <param name="lpSubKey">The name of the key. This key must be a subkey of the key identified by the hKeySrc 
		/// parameter. This parameter can also be NULL.</param>
		/// <param name="hKeyDest">A handle to the destination key. The calling process must have KEY_CREATE_SUB_KEY 
		/// access to the key. </param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
		/// <remarks>This function also copies the security descriptor for the key.</remarks>
		[DllImport ( "advapi32", EntryPoint = "RegCopyTree" )]
		private static extern long RegCopyTree ( [In] IntPtr hKeySrc, [In] ref StringBuilder lpSubKey, [In] IntPtr hKeyDest );

		/*LONG WINAPI RegGetKeySecurity(
			__in       HKEY hKey,
			__in       SECURITY_INFORMATION SecurityInformation,
			__out_opt  PSECURITY_DESCRIPTOR pSecurityDescriptor,
			__inout    LPDWORD lpcbSecurityDescriptor
		);*/
		/// <summary>
		/// The RegGetKeySecurity function retrieves a copy of the security descriptor protecting the specified open registry key.
		/// </summary>
		/// <param name="hKey">A handle to an open key for which to retrieve the security descriptor.</param>
		/// <param name="lpSecurityInformation">A SECURITY_INFORMATION value that indicates the requested security information.</param>
		/// <param name="pSecurityDescriptor">A pointer to a buffer that receives a copy of the requested security descriptor.</param>
		/// <param name="lpcbSecurityDescriptor">A pointer to a variable that specifies the size, in bytes, of the buffer 
		/// pointed to by the pSecurityDescriptor parameter. When the function returns, the variable contains the number of 
		/// bytes written to the buffer.</param>
		/// <returns>If the function succeeds, the function returns ERROR_SUCCESS. </returns>
		[DllImport ( "advapi32", EntryPoint = "RegGetKeySecurity" )]
		private static extern long RegGetKeySecurity ( [In] IntPtr hKey, [In] ref SECURITY_ATTRIBUTES lpSecurityInformation, [Out] out SECURITY_ATTRIBUTES pSecurityDescriptor, ref long lpcbSecurityDescriptor );


		/*LONG WINAPI RegLoadKey(
			__in      HKEY hKey,
			__in_opt  LPCTSTR lpSubKey,
			__in      LPCTSTR lpFile
		);*/
		/// <summary>
		/// Creates a subkey under HKEY_USERS or HKEY_LOCAL_MACHINE 
		/// and loads the data from the specified registry hive into that subkey.
		/// </summary>
		/// <param name="hKey">A handle to the key where the subkey will be created. This can be a handle returned 
		/// by a call to RegConnectRegistry, or one of the following predefined handles:
		///
		/// HKEY_LOCAL_MACHINE
		/// HKEY_USERS</param>
		/// <param name="lpSubKey">The name of the key to be created under hKey. This subkey is where 
		/// the registration information from the file will be loaded.</param>
		/// <param name="lpFile">The name of the file containing the registry data. This file must be a local file 
		/// that was created with the RegSaveKey function. If this file does not exist, a file is created with the 
		/// specified name.</param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
		[DllImport ( "advapi32", EntryPoint = "RegLoadKey" )]
		private static extern long RegLoadKey ( [In] IntPtr hKey, [In] ref StringBuilder lpSubKey, [In] ref StringBuilder lpFile );

		/*LONG WINAPI RegSaveKeyEx(
			__in      HKEY hKey,
			__in      LPCTSTR lpFile,
			__in_opt  LPSECURITY_ATTRIBUTES lpSecurityAttributes,
			__in      DWORD Flags
		);*/

		/// <summary>
		/// Saves the specified key and all of its subkeys and values to a registry file, in the specified format.
		/// 
		/// This function does not support the HKEY_CLASSES_ROOT predefined key.
		/// </summary>
		/// <param name="hKey">A handle to an open registry key. </param>
		/// <param name="lpFile">The name of the file in which the specified key and subkeys are to be saved. If the 
		/// file already exists, the function fails. </param>
		/// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security 
		/// descriptor for the new file. If lpSecurityAttributes  is NULL, the file gets a default security descriptor. 
		/// The ACLs in a default security descriptor for a file are inherited from its parent directory.</param>
		/// <param name="flags">The format of the saved key or hive. This parameter can be one of the following values.</param>
		/// <remarks>
		/// Unlike RegSaveKey, this function does not support the HKEY_CLASSES_ROOT predefined key.
		/// 
		/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy Service instead of the registry functions.</remarks>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
		[DllImport ( "advapi32", EntryPoint = "RegSaveKeyEx" )]
		private static extern long RegSaveKeyEx ( IntPtr hKey, [In] ref StringBuilder lpFile, [In] ref SECURITY_ATTRIBUTES lpSecurityAttributes, int flags );

		/*LONG WINAPI RegSaveKey(
			__in      HKEY hKey,
			__in      LPCTSTR lpFile,
			__in_opt  LPSECURITY_ATTRIBUTES lpSecurityAttributes
		);*/

		/// <summary>
		/// Saves the specified key and all of its subkeys and values to a new file, in the standard format.
		/// </summary>
		/// <param name="hKey">A handle to an open registry key. </param>
		/// <param name="lpFile">The name of the file in which the specified key and subkeys are to be saved. If the 
		/// file already exists, the function fails.</param>
		/// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security 
		/// descriptor for the new file. If lpSecurityAttributes  is NULL, the file gets a default security descriptor. 
		/// The ACLs in a default security descriptor for a file are inherited from its parent directory.</param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
		[DllImport ( "advapi32", EntryPoint = "RegSaveKey" )]
		private static extern long RegSaveKey ( IntPtr hKey, [In] ref StringBuilder lpFile, [In] ref SECURITY_ATTRIBUTES lpSecurityAttributes );

		[DllImport ( "Kernel32.dll", SetLastError = true )]
		private static extern long FormatMessage ( long dwFlags, IntPtr lpSource, long dwMessageId, long dwLanguageId, [Out] StringBuilder lpBuffer, long nSize, long Arguments );
		[DllImport ( "kernel32.dll", SetLastError = true )]
		private static extern IntPtr LocalFree ( IntPtr hMem );

		/// <summary>
		/// 
		/// </summary>
		[StructLayout ( LayoutKind.Sequential )]
		public struct SECURITY_ATTRIBUTES {
			/// <summary>
			/// 
			/// </summary>
			public int nLength;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr lpSecurityDescriptor;
			/// <summary>
			/// 
			/// </summary>
			public int bInheritHandle;
		}

		[StructLayoutAttribute ( LayoutKind.Sequential )]
		struct SECURITY_DESCRIPTOR {
			public byte revision;
			public byte size;
			public short control;
			public IntPtr owner;
			public IntPtr group;
			public IntPtr sacl;
			public IntPtr dacl;
		}

		/// <summary>
		/// Retrieves the current size of the registry and the maximum size that the registry is allowed to attain on the system.
		/// </summary>
		/// <param name="allowed">The maximum size that the registry is allowed 
		/// to attain on this system, in bytes.</param>
		/// <param name="used">The current size of the registry, in bytes.</param>
		public static void GetQuota ( this RegistryKey rkey, out long allowed, out long used ) {
			GetSystemRegistryQuota ( out allowed, out used );
		}

		public static void CopyTree ( this RegistryKey rKey, string subKey, RegistryKey destination ) {
			StringBuilder lpSubKey = null;
			if ( !string.IsNullOrWhiteSpace ( subKey ) ) {
				lpSubKey = new StringBuilder ( subKey );
			}

			long result = RegCopyTree ( rKey.Handle.DangerousGetHandle ( ), ref lpSubKey, destination.Handle.DangerousGetHandle ( ) );
			if ( result != ERROR_SUCCESS ) {
				throw new RegistryException ( GetErrorMessage ( result ) );
			}
		}

		public static void ExportKey ( this RegistryKey rKey, string exportFile, SECURITY_ATTRIBUTES security, bool compress ) {
			if ( rKey.Name.Contains ( Registry.ClassesRoot.Name ) ) {
				try {
					if ( File.Exists ( exportFile ) ) {
						File.Delete ( exportFile );
					}
					if ( !compress ) {
						throw new RegistryException ( "Unable to specify format of HKEY_CLASSES_ROOT" );
					}
					StringBuilder lpFile = new StringBuilder ( exportFile );
					long result = RegSaveKey ( rKey.Handle.DangerousGetHandle ( ), ref lpFile, ref security );
					if ( result != ERROR_SUCCESS ) {
						throw new RegistryException ( GetErrorMessage ( result ) );
					}
				} catch ( Exception ) {
					throw;
				}
			} else {
				try {
					if ( File.Exists ( exportFile ) ) {
						File.Delete ( exportFile );
					}
					RegistryExportFormat flags = RegistryExportFormat.REG_LATEST_FORMAT;
					if ( !compress ) {
						flags &= RegistryExportFormat.REG_NO_COMPRESSION;
					}
					StringBuilder lpFile = new StringBuilder ( exportFile );
					long result = RegSaveKeyEx ( rKey.Handle.DangerousGetHandle ( ), ref lpFile, ref security, (int)flags );
					if ( result != ERROR_SUCCESS ) {
						throw new RegistryException ( GetErrorMessage ( result ) );
					}
				} catch ( Exception ) {
					throw;
				}
			}
		}

		public static void ExportKey ( this RegistryKey rKey, string exportFile, SECURITY_ATTRIBUTES security ) {
			ExportKey ( rKey, exportFile, security, true );
		}

		public static void ExportKey ( this RegistryKey rKey, string exportFile ) {

			SECURITY_ATTRIBUTES security = new SECURITY_ATTRIBUTES ( );
			security.bInheritHandle = 1;
			security.lpSecurityDescriptor = IntPtr.Zero;
			security.nLength = Marshal.SizeOf ( security );

			ExportKey ( rKey, exportFile, security, true );

		}

		public static void ExportKey ( this RegistryKey rKey, string exportFile, bool compress ) {
			SECURITY_ATTRIBUTES security = new SECURITY_ATTRIBUTES ( );
			security.bInheritHandle = 1;
			security.lpSecurityDescriptor = IntPtr.Zero;
			security.nLength = Marshal.SizeOf ( security );

			ExportKey ( rKey, exportFile, security, compress );
		}

		public static void LoadKey ( this RegistryKey rKey, string subKey, string importFile ) {
			StringBuilder lpSubKey = null;
			if ( !string.IsNullOrWhiteSpace ( subKey ) ) {
				lpSubKey = new StringBuilder ( subKey );
			}
			StringBuilder sbImport = new StringBuilder ( importFile );
			long result = RegLoadKey ( rKey.Handle.DangerousGetHandle ( ), ref lpSubKey, ref sbImport );
			if ( result != ERROR_SUCCESS ) {
				throw new RegistryException ( GetErrorMessage ( result ) );
			}
		}

		public static void LoadKey ( this RegistryKey rKey, string importFile ) {
			LoadKey ( rKey, null, importFile );
		}

		private static void ShellFile ( string arguments ) {
			var process1 = new Process ( );
			try {
				process1.StartInfo.FileName = "regedit.exe";
				process1.StartInfo.UseShellExecute = false;
				process1 = Process.Start ( "regedit.exe", arguments );
				process1.WaitForExit ( );
			} finally {
				process1.Dispose ( );
			}
		}

		private static string GetErrorMessage ( long errorCode ) {
			StringBuilder lpMsgBuffer = new StringBuilder();
			Console.WriteLine ( "Error Code: 0x{0:X8}", errorCode );
			/*long dwChars = FormatMessage (
					FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
					IntPtr.Zero,
					errorCode,
					0, // Default language
					lpMsgBuffer,
					0,
					0 );
			if ( dwChars == 0 ) {
				// Handle the error.
				int le = Marshal.GetLastWin32Error ( );
				return null;
			}*/
			return lpMsgBuffer.ToString();
		}
	}
}