using System.Collections;
using System.Globalization;

namespace Module3HW2;

public class Contacts : IEnumerable
{
    public const string EnglishCultureName = "en-US";
    public const string UkrainianCultureName = "ua-UA";

    private const string NotSupportedLetterChapter = "#";
    private const string NumbersChapter = "0-9";

    private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string UkrainianAlphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";

    private Dictionary<string, List<IContact>> _english;
    private Dictionary<string, List<IContact>> _ukrainian;

    public Contacts()
    {
        _english = new Dictionary<string, List<IContact>>();
        _ukrainian = new Dictionary<string, List<IContact>>();
    }

    public IEnumerator GetEnumerator()
    {
        return new ContactsEnumerator(_english, _ukrainian);
    }

    public void Add(IContact contact, CultureInfo info)
    {
        if (info == null)
        {
            info = new CultureInfo(EnglishCultureName);
        }

        if (info.Name.Equals(EnglishCultureName, StringComparison.InvariantCultureIgnoreCase))
        {
            AddEnglishContact(contact, info);
        }
        else if (info.Name.Equals(UkrainianCultureName, StringComparison.InvariantCultureIgnoreCase))
        {
            AddUkrainianContact(contact, info);
        }
    }

    private void AddEnglishContact(IContact contact, CultureInfo info)
    {
        if (IsNotSupportedLetter(contact, info))
        {
            if (!_english.ContainsKey(NotSupportedLetterChapter))
            {
                _english.Add(NotSupportedLetterChapter, new List<IContact>());
            }

            _english[NotSupportedLetterChapter].Add(contact);
            return;
        }

        if (IsDigit(contact))
        {
            if (!_english.ContainsKey(NumbersChapter))
            {
                _english.Add(NumbersChapter, new List<IContact>());
            }

            _english[NumbersChapter].Add(contact);
            return;
        }

        if (!_english.ContainsKey(GetChapterLetter(contact)))
        {
            _english.Add(GetChapterLetter(contact), new List<IContact>());
        }

        _english[GetChapterLetter(contact)].Add(contact);
    }

    private void AddUkrainianContact(IContact contact, CultureInfo info)
    {
        if (IsNotSupportedLetter(contact, info))
        {
            if (!_ukrainian.ContainsKey(NotSupportedLetterChapter))
            {
                _ukrainian.Add(NotSupportedLetterChapter, new List<IContact>());
            }

            _ukrainian[NotSupportedLetterChapter].Add(contact);
            return;
        }

        if (IsDigit(contact))
        {
            if (!_ukrainian.ContainsKey(NumbersChapter))
            {
                _ukrainian.Add(NumbersChapter, new List<IContact>());
            }

            _ukrainian[NumbersChapter].Add(contact);
            return;
        }

        if (!_ukrainian.ContainsKey(GetChapterLetter(contact)))
        {
            _ukrainian.Add(GetChapterLetter(contact), new List<IContact>());
        }

        _ukrainian[GetChapterLetter(contact)].Add(contact);
    }

    private bool IsDigit(IContact contact)
    {
        if (contact.LastName.Length > 1)
        {
            return char.IsDigit(contact.LastName[0]);
        }

        return false;
    }

    private bool IsNotSupportedLetter(IContact contact, CultureInfo info)
    {
        if (info.Name.Equals(EnglishCultureName, StringComparison.InvariantCultureIgnoreCase))
        {
            return !EnglishAlphabet.Contains(contact.LastName[0].ToString().ToUpper());
        }

        if (info.Name.Equals(UkrainianCultureName, StringComparison.InvariantCultureIgnoreCase))
        {
            return !UkrainianAlphabet.Contains(contact.LastName[0].ToString().ToUpper());
        }

        return false;
    }

    private string GetChapterLetter(IContact contact)
    {
        if (contact.LastName.Length < 1)
        {
            return string.Empty;
        }

        return contact.LastName[0].ToString().ToUpper();
    }

    private class ContactsEnumerator : IEnumerator
    {
        private Dictionary<string, List<IContact>> _englishDictionary;
        private Dictionary<string, List<IContact>> _ukrainianDictionary;

        private int _countEn = -1;
        private int _countUk = -1;

        public ContactsEnumerator(Dictionary<string, List<IContact>> english, Dictionary<string, List<IContact>> ukrainian)
        {
            _englishDictionary = english;
            _ukrainianDictionary = ukrainian;
        }

        public object Current
        {
            get
            {
                int count = 0;
                if (_countEn <= _englishDictionary.Count - 1 && _countUk == -1)
                {
                    foreach (var item in _englishDictionary)
                    {
                        if (count == _countEn)
                        {
                            return item;
                        }

                        count++;
                    }
                }

                foreach (var item in _ukrainianDictionary)
                {
                    if (count == _countUk)
                    {
                        return item;
                    }

                    count++;
                }

                return null;
            }
        }

        public bool MoveNext()
        {
            if (_countEn < _englishDictionary.Count - 1)
            {
                _countEn++;
                return true;
            }

            if (_countUk < _ukrainianDictionary.Count - 1)
            {
                _countUk++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _countEn = -1;
            _countUk = -1;
        }
    }
}