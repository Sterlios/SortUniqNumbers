using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ComparingTexts
{
	class Text
	{
		public const int NotFounded = -1;
		private string[] _words;
		private List<string> _delimiters;
		private int _wordIndex = 0;

		public Text(string text)
		{
			InitializeWords(text.ToLower());
		}

		public string Word => IsEnd ? string.Empty : _words[WordIndex];
		public bool IsEnd => _wordIndex >= _words.Length;
		private int WordIndex => IsEnd ? _words.Length - 1 : _wordIndex;

		public bool MoveNext()
		{
			if (IsEnd)
				return false;

			_wordIndex++;
			return true;
		}

		public int GetClosestIndex(string word)
		{
			if (_words.Length == 0)
				return NotFounded;

			for (int i = WordIndex; i < _words.Length; i++)
				if (_words[i] == word)
					return i - WordIndex;

			return NotFounded;
		}

		public int GetCurrentPosition()
		{
			int position = 0;

			for (int i = 0; i < WordIndex; i++)
				position += GetSumLengthWordAndSpace(_words[i], GetDelimeter(i));

			return position;
		}

		private string GetDelimeter(int index)
		{
			if (index >= 0 && index < _delimiters.Count)
				return _delimiters[index];

			return string.Empty;
		}

		private int GetSumLengthWordAndSpace(string word, string space) =>
			word.Length + space.Length;

		private void InitializeWords(string text)
		{
			char[] separators = new char[] { ' ', ',', '.', '!', '?', ';', ':' };
			_words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			string pattern = $"[{Regex.Escape(string.Join(string.Empty, separators))}]+";
			MatchCollection matches = Regex.Matches(text, pattern);
			_delimiters = new List<string>();

			foreach (Match match in matches)
				_delimiters.Add(match.Value);
		}
	}
}
