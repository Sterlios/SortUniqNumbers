using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ComparingTexts
{
	class Text
	{
		public const bool Founded = true;

		private string[] _words;
		private List<string> _delimiters;
		private int _index = 0;

		public Text(string text)
		{
			InitializeWords(text.ToLower());
		}

		public string Word => IsEnd ? string.Empty : _words[CurrentIndex];
		public bool IsEnd => _index >= _words.Length;

		private int CurrentIndex => IsEnd ? _words.Length - 1 : _index;

		public void MoveNext()
		{
			if (IsEnd)
				return;

			_index++;
		}

		public bool TryGetDistanceToClosest(string targetWord, out int distance)
		{
			distance = 0;

			if (_words.Length == 0)
				return !Founded;

			for (int i = CurrentIndex; i < _words.Length; i++)
			{
				if (_words[i] == targetWord)
				{
					distance = i - CurrentIndex;
					return Founded;
				}
			}

			return !Founded;
		}

		public int GetCurrentPosition()
		{
			int position = 0;

			for (int i = 0; i < CurrentIndex; i++)
				position += GetShift(_words[i], GetDelimeter(i));

			return position;
		}

		private string GetDelimeter(int index)
		{
			if (index >= 0 && index < _delimiters.Count)
				return _delimiters[index];

			return string.Empty;
		}

		private int GetShift(string word, string delimeter) =>
			word.Length + delimeter.Length;

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
