namespace ComparingTexts
{
	public interface IComparable
	{
		void Compare(string text1, string text2, out ColoredText coloredText1, out ColoredText coloredText2);
	}
}
