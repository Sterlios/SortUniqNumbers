using System.Collections.Generic;
using System.Drawing;

namespace ComparingTexts
{
	class TextComparer
	{
		private readonly Color _changingWordColor = Color.Yellow;
		private readonly Color _additionalWordColor = Color.LightGreen;
		private readonly List<SelectionRange> _sourceWordsSelection = new List<SelectionRange>();
		private readonly List<SelectionRange> _resultWordsSelection = new List<SelectionRange>();

		private Text _source;
		private Text _result;

		public TextComparer(string text1, string text2)
		{
			_source = new Text(text1);
			_result = new Text(text2);
		}

		public void Compare(out List<SelectionRange> sourceWordsSelection, out List<SelectionRange> resultWordsSelection)
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
					AddSelectionWordsBasedOnMatch();
				else if (_source.Word == string.Empty)
					AddSelectionWord(_resultWordsSelection, _result, _additionalWordColor);
				else
					AddSelectionWord(_sourceWordsSelection, _source, _additionalWordColor);
			}

			sourceWordsSelection = _sourceWordsSelection;
			resultWordsSelection = _resultWordsSelection;
		}

		private void AddSelectionWordsBasedOnMatch()
		{
			int sourceWordPosition = _source.GetClosestIndex(_result.Word);
			int resultWordPosition = _result.GetClosestIndex(_source.Word);

			bool sourceWordFounded = sourceWordPosition != Text.NotFounded;
			bool resultWordFounded = resultWordPosition != Text.NotFounded;

			if (!sourceWordFounded && !resultWordFounded)
				AddChangingWords();
			else if (sourceWordFounded && resultWordFounded)
				AddSelectionWordBasedOnPosition(sourceWordPosition, resultWordPosition);
			else if (sourceWordFounded)
				AddSelectionWord(_sourceWordsSelection, _source, _additionalWordColor);
			else
				AddSelectionWord(_resultWordsSelection, _result, _additionalWordColor);
		}

		private void AddSelectionWordBasedOnPosition(int sourceWordPosition, int resultWordPosition)
		{
			if (sourceWordPosition <= resultWordPosition)
				AddSelectionWord(_sourceWordsSelection, _source, _additionalWordColor);
			else
				AddSelectionWord(_resultWordsSelection, _result, _additionalWordColor);
		}

		private void AddChangingWords()
		{
			AddSelectionWord(_sourceWordsSelection, _source, _changingWordColor);
			AddSelectionWord(_resultWordsSelection, _result, _changingWordColor);
		}

		private void AddSelectionWord(List<SelectionRange> additionalWords, Text textWithAdditionalWord, Color color)
		{
			additionalWords.Add(new SelectionRange(textWithAdditionalWord.GetCurrentPosition(), textWithAdditionalWord.Word.Length, color));

			textWithAdditionalWord.MoveNext();
		}
	}
}
