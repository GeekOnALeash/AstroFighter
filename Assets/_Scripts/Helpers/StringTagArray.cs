namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	[CreateAssetMenu(fileName = "NewTagArray", menuName = "Scriptable/Tags/TargetArray", order = 0)]
	public class StringTagArray : ScriptableObject
	{
		[SerializeField]
		private StringConstant[] stringTags;

		internal bool CompareTag(string tagToCompare)
		{
			foreach (var tag in stringTags)
			{
				if (tag.Value == tagToCompare)
				{
					return true;
				}
			}

			return false;
		}
	}
}