// ReSharper disable All
namespace WakaTime
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEditor;
	using UnityEngine;

	/// <summary>
	/// WakaTime plugin window.
	/// </summary>
	[SuppressMessage("ReSharper", "SA1310", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1400", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1408", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1202", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1600", Justification = "Hiding errors as is not my script.")]
	public class Window : EditorWindow
	{
		/// <summary>
		/// Url to wakatime.
		/// </summary>
		const string WAKATIME_URL = "https://wakatime.com/";

		[MenuItem("Window/WakaTime")]
		public static void ShowWindow()
		{
			EditorWindow.GetWindow(typeof(Window));
		}

		void OnGUI()
		{
			GUILayout.Label("WakaTime configuration", EditorStyles.boldLabel);

			if (GUILayout.Button("Visit " + WAKATIME_URL))
			{
				Application.OpenURL(WAKATIME_URL);
			}

			EditorGUILayout.Separator();

			Main.IsEnabled = EditorGUILayout.Toggle("Enabled", Main.IsEnabled);
			EditorGUILayout.Separator();

			Main.ApiKey = EditorGUILayout.TextField("API key", Main.ApiKey);
			if (Main.IsEnabled && Main.ApiKey == null || string.Empty.Equals(Main.ApiKey))
			{
				EditorGUILayout.HelpBox("API Key is required", MessageType.Error, false);
			}

			Main.MaxRequests = EditorGUILayout.IntField("Max Requests", Main.MaxRequests);
			EditorGUILayout.HelpBox("Maximum number of simultaneous requests to wakatime. Be cautious when increasing this value, since that might cause CPU problems.", MessageType.Info, true);

			EditorGUILayout.Separator();

			Main.IsDebug = EditorGUILayout.Toggle("Debug", Main.IsDebug);
			EditorGUILayout.HelpBox("Debug messages will appear in the console if this option is enabled. Mostly used for test purposes.", MessageType.Info, true);
		}

		public static bool IsFocused()
		{
			return EditorWindow.focusedWindow is Window;
		}

		public static EditorWindow GetWindow()
		{
			return EditorWindow.GetWindow(typeof(Window));
		}
	}
}