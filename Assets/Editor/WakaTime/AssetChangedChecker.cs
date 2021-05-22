// ReSharper disable All
namespace WakaTime
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEditor;

	/// <inheritdoc />
	/// <summary>
	/// Asset postprocessor to act when some assets have changed.
	/// </summary>
	[SuppressMessage("ReSharper", "SA1311", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1401", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1616", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1614", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1206", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1615", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1612", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1400", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "ClassCanBeSealed.Global", Justification = "Hiding errors as is not my script.")]
	public class AssetChangedChecker : AssetPostprocessor
	{
		/// <summary>
		/// Subscribes to assets modifications.
		/// </summary>
		/// <param name="importedAssets"></param>
		/// <param name="deletedAssets"></param>
		/// <param name="movedAssets"></param>
		/// <param name="movedFromAssetPaths"></param>
		[SuppressMessage("ReSharper", "AnnotateNotNullParameter", Justification = "Hiding errors as is not my script.")]
		[SuppressMessage("ReSharper", "ArrangeTypeMemberModifiers", Justification = "Hiding errors as is not my script.")]
		static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
			foreach (var str in importedAssets)
			{
				Main.OnAssetSaved(Main.GetProjectPath() + str);
			}

			foreach (var str in deletedAssets)
			{
				Main.OnAssetChanged(Main.GetProjectPath() + str);
			}

			foreach (var str in movedAssets)
			{
				Main.OnAssetChanged(Main.GetProjectPath() + str);
			}

			foreach (var str in movedFromAssetPaths)
			{
				Main.OnAssetChanged(Main.GetProjectPath() + str);
			}
		}
	}
}