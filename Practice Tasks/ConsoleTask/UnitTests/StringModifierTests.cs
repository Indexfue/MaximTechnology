using Task1;
using Task1.Utility.Sorting;

namespace UnitTests;

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
        var modifier = new StringModifier("abcd", SortingMode.QuickSort);
        Assert.That(modifier.Result, Is.EqualTo("badc"));
    }

    [Test]
    public void ReverseByParity_OddLength_ReturnsReversedString()
    {
        var modifier = new StringModifier("abcde", SortingMode.QuickSort);
        Assert.That(modifier.Result, Is.EqualTo("edcbaabcde"));
    }

    [Test]
    public void GetMaxVowelString_ReturnsMaxVowelString()
    {
        var modifier = new StringModifier("hello", SortingMode.QuickSort);
        Assert.That(modifier.MaxVowelString, Is.EqualTo("ollehhello"));
    }

    [Test]
    public void CharCount_ReturnsCorrectCharCount()
    {
        var modifier = new StringModifier("abbcccdddd", SortingMode.QuickSort);
        var expectedCharCount = new Dictionary<char, int>
        {
            {'a', 1},
            {'b', 2},
            {'c', 3},
            {'d', 4}
        };
        CollectionAssert.AreEquivalent(expectedCharCount, modifier.CharCount);
    }
}