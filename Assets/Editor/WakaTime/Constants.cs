// ReSharper disable All
namespace WakaTime
{
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// WakaTime constant.
	/// </summary>
	[SuppressMessage("ReSharper", "SA1310", Justification = "Hiding errors as is not my script.")]
	internal static class WakaTimeConstants
	{
		/// <summary>
		/// Name of the plugin.
		/// </summary>
		internal const string PLUGIN_NAME = "unity-wakatime";

		/// <summary>
		/// Name of the editor.
		/// </summary>
		internal const string EDITOR_NAME = "unity";

		/// <summary>
		/// Time in seconds to send heart beat.
		/// </summary>
		internal const int TIME_TO_HEARTBEAT = 120;
	}
}