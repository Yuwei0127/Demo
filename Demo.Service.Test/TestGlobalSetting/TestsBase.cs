namespace Demo.Service.Test.TestGlobalSetting;

public class TestsBase : IDisposable
{
    public TestsBase()
    {
        // 相當於 MSTest 的 [TestInitialize]
    }

    public void Dispose()
    {
        // 相當於 MSTest 的 [TestCleanup]
    }
}