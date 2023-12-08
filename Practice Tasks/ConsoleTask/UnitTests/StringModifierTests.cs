using Task1;
using Task1.Utility.Sorting;

namespace UnitTests
{
    [TestFixture]
    public class StringModifierTests
    {
        [Test]
        public void Constructor_NullOrEmptyString_ThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => new StringModifier(null, SortingMode.QuickSort));
            Assert.Throws<NullReferenceException>(() => new StringModifier("", SortingMode.QuickSort));
            Assert.Throws<NullReferenceException>(() => new StringModifier("   ", SortingMode.QuickSort));
        }
    
        [Test]
        public void ReverseByParity_EvenLength_ReturnsReversedString()
        {
            var modifier = new StringModifier("abccde", SortingMode.QuickSort);
            Assert.That(modifier.Result, Is.EqualTo("cbaedc"));
        }
    
        [Test]
        public void ReverseByParity_DisallowedChars_ThrowsException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                                                            () => new StringModifier("Abcd12#", SortingMode.QuickSort));
            Assert.That(exception.Message, Is.EqualTo("These disallowed chars was in Abcd12# string: A12#"));
        }
    
        [Test]
        public void ReverseByParity_OddLength_ReturnsReversedString()
        {
            var modifier = new StringModifier("abcde", SortingMode.QuickSort);
            Assert.That(modifier.Result, Is.EqualTo("edcbaabcde"));
        }
    
        [Test]
        public void GetMaxVowelString_ReturnsMaxVowelString_VowelLettersExists()
        {
            var modifier = new StringModifier("hello", SortingMode.QuickSort);
            Assert.That(modifier.MaxVowelString, Is.EqualTo("ollehhello"));
        }
        
        [Test]
        public void GetMaxVowelString_ReturnsMaxVowelString_VowelLettersIsNotExists()
        {
            var modifier = new StringModifier("ntxsts", SortingMode.QuickSort);
            Assert.That(modifier.MaxVowelString, Is.EqualTo(""));
        }
    
        [Test]
        public void CharCount_ReturnsCorrectCharCount()
        {
            var modifier = new StringModifier("abbcccddddaa", SortingMode.QuickSort);
            var expectedCharCount = new Dictionary<char, int>
            {
                {'a', 3},
                {'b', 2},
                {'c', 3},
                {'d', 4}
            };
            CollectionAssert.AreEquivalent(expectedCharCount, modifier.CharCount);
        }
    }
}