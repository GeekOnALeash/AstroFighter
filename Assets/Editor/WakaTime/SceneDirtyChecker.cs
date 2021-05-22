// ReSharper disable All
namespace WakaTime
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEditor;

	/// <summary>
	/// Checks if the scene is dirty.
	/// </summary>
	[InitializeOnLoad]
	[SuppressMessage("ReSharper", "SA1401", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1614", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1616", Justification = "Hiding errors as is not my script.")]
	[SuppressMessage("ReSharper", "SA1400", Justification = "Hiding errors as is not my script.")]
	public class SceneDirtyChecker
	{
		/// <summary>
		/// Whether the scene is dirty.
		/// </summary>
		public static bool sceneIsDirty = false;

        /// <summary>
        /// Initializes static members of the <see cref="SceneDirtyChecker"/> class.
        /// Checker.
        /// </summary>
		static SceneDirtyChecker()
		{
			Undo.postprocessModifications += OnPostProcessModifications;
			Undo.undoRedoPerformed += OnUndoRedo;
		}

		/// <summary>
		/// Handles undo and redo events.
		/// </summary>
		private static void OnUndoRedo()
		{
			string path = Main.GetProjectPath() + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			Main.OnSceneChanged(path);
		}

		/// <summary>
		/// Handles modifications events.
		/// </summary>
		/// <param name="propertyModifications"></param>
		/// <returns></returns>
		static UndoPropertyModification[] OnPostProcessModifications(UndoPropertyModification[] propertyModifications)
		{
			sceneIsDirty = true;

			string path = Main.GetProjectPath() + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			Main.OnSceneChanged(path);

			return propertyModifications;
		}
	}
}