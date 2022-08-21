
using Xunit.Extensions.Ordering;
using Xunit;
//Optional
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//Optional
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
//Optional
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]


[assembly: TestFramework("Xunit.Extensions.Ordering.TestFramework", "Xunit.Extensions.Ordering")]

namespace XunitTestSampleProject
{
    public class SharedMemory
    {
        public int Number { get; set; } = 10;
    }

    [CollectionDefinition("Collection1")]
    public class Collection1 : ICollectionFixture<SharedMemory>
    {

    }

    [Collection("Collection1"), Order(2)]
    public class UnitTest1
    {
        private readonly SharedMemory _memory;

        public UnitTest1(SharedMemory sharedMemory)
        {
            _memory = sharedMemory;
        }

        [Fact, Order(2)]
        public void Test1()
        {
            Assert.Equal(6, _memory.Number);
            _memory.Number = 3;
            Thread.Sleep(5000);
        }
    }


    [Collection("Collection1"), Order(-8)]
    public class UnitTest3
    {
        private readonly SharedMemory _memory;

        public UnitTest3(SharedMemory sharedMemory)
        {
            _memory = sharedMemory;
        }
        [Fact, Order(-8)]
        public void Test3()
        {
            Assert.Equal(10, _memory.Number);
            _memory.Number = 99;
            Thread.Sleep(5000);
        }
    }
}