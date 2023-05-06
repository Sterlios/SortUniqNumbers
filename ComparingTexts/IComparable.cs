namespace ComparingTexts
{
	public interface IComparable
	{
		void Compare(string text1, string text2, out IReadOnlyColoredText coloredText1, out IReadOnlyColoredText coloredText2);
	}
}
