using System.Collections.Generic;
using System.Drawing;

namespace ComparingTexts
{
	class TextComparer
	{
		private readonly Color _changedWordColor = Color.Yellow;
		private readonly Color _additionalWordColor = Color.LightGreen;

		private readonly List<SelectionRange> _sourceFoundedWords = new List<SelectionRange>();
		private readonly List<SelectionRange> _resultFoundedWords = new List<SelectionRange>();

		private readonly Text _source;
		private readonly Text _result;

		public TextComparer(string text1, string text2)
		{
			_source = new Text(text1);
			_result = new Text(text2);
		}

		public void Compare(out List<SelectionRange> sourceFoundedWords, out List<SelectionRange> resultFoundedWords)
		{
			while (!_source.IsEnd || !_result.IsEnd)
			{
				if (_source.Word == _result.Word)
				{
					_source.MoveNext();
					_result.MoveNext();

					continue;
				}

				if (_source.Word != string.Empty && _result.Word != string.Empty)
					AddWordsByMatch(); 
				else if (_source.Word == string.Empty)
					AddCurrentWord(_resultFoundedWords, _result, _additionalWordColor);
				else
					AddCurrentWord(_sourceFoundedWords, _source, _additionalWordColor);
			}

			sourceFoundedWords = _sourceFoundedWords;
			resultFoundedWords = _resultFoundedWords;
		}

		private void AddWordsByMatch()
		{
			bool sourceWordFounded = _source.TryGetDistanceToClosest(_result.Word, out int sourceWordDistance);
			bool resultWordFounded = _result.TryGetDistanceToClosest(_source.Word, out int resultWordDistance);

			if (!sourceWordFounded && !resultWordFounded)
				AddChangedWords();
			else if (sourceWordFounded && resultWordFounded)
				AddClosestWord(sourceWordDistance, resultWordDistance);
			else if (sourceWordFounded)
				AddCurrentWord(_sourceFoundedWords, _source, _additionalWordColor);
			else
				AddCurrentWord(_resultFoundedWords, _result, _additionalWordColor);
		}

		private void AddClosestWord(int sourceWordDistance, int resultWordDistance)
		{
			if (sourceWordDistance <= resultWordDistance)
				AddCurrentWord(_sourceFoundedWords, _source, _additionalWordColor);
			else
				AddCurrentWord(_resultFoundedWords, _result, _additionalWordColor);
		}

		private void AddChangedWords()
		{
			AddCurrentWord(_sourceFoundedWords, _source, _changedWordColor);
			AddCurrentWord(_resultFoundedWords, _result, _changedWordColor);
		}

		private void AddCurrentWord(List<SelectionRange> words, Text text, Color color)
		{
			words.Add(new SelectionRange(text.GetCurrentPosition(), text.Word.Length, color));

			text.MoveNext();
		}
	}
}
