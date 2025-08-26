using ClassLibraryHW1;

namespace TestHW1;

public class UnitTest1
{
    private readonly Class1 passwordChecker = new();

    [Fact] public void Returns_Ineligible_WhenEmpty() => Assert.Equal("INELIGIBLE", passwordChecker.CheckPassword(""));

    // Weak Cases (1 Tests Passed)
    [Fact] public void Returns_Weak_For_One_Criteria_Lowercase() => Assert.Equal("WEAK", passwordChecker.CheckPassword("awsty"));
    [Fact] public void Returns_Weak_For_One_Criteria_Uppercase() => Assert.Equal("WEAK", passwordChecker.CheckPassword("QWERTY"));
    [Fact] public void Returns_Weak_For_One_Criteria_Number() => Assert.Equal("WEAK", passwordChecker.CheckPassword("6473"));
    [Fact] public void Returns_Weak_For_One_Criteria() => Assert.Equal("WEAK", passwordChecker.CheckPassword("awsty"));

    // Medium Cases (2 Tests Passed)
    [Fact] public void Returns_Medium_For_Two_Criteria_LowerUpperCase() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("awstyEERT"));
    [Fact] public void Returns_Medium_For_Two_Criteria_LowercaseNumber() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("djc1524"));
    [Fact] public void Returns_Medium_For_Two_Criteria_LowercaseSymbol() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("adj$@#"));
    [Fact] public void Returns_Medium_For_Two_Criteria_UppercaseNumber() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("1234EERT"));
    [Fact] public void Returns_Medium_For_Two_Criteria_UpperSymbol() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("#$FTRE"));
    [Fact] public void Returns_Medium_For_Two_Criteria_SymbolNumber() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("1234$%%^"));

    // Medium Cases (3 Tests Passed)
    [Fact] public void Returns_Medium_For_Three_Criteria_UpperLowerCaseNumber() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("1234EERTcjcna"));
    [Fact] public void Returns_Medium_For_Three_Criteria_UpperLowerCaseSymbol() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("#$sxFTcsEsca"));
    [Fact] public void Returns_Medium_For_Three_Criteria_UppercaseNumberSymbol() => Assert.Equal("MEDIUM", passwordChecker.CheckPassword("HXB34RF34#@2"));

    // Strong Case (4 Tests Passed)
    [Fact] public void Returns_Strong_For_Four_Criteria_UpperLowerCaseNumberSymbol() => Assert.Equal("STRONG", passwordChecker.CheckPassword("HXB34RF34#@2ss^gx"));
}
