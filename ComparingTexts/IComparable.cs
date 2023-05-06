namespace ComparingTexts
{
	public interface IComparable
	{
		void Compare(string text1, string text2, out IColoredText coloredText1, out IColoredText coloredText2);
	}
}
