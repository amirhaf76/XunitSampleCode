

using Xunit.Extensions.Ordering;

namespace XunitTestSampleProject
{


    [Collection("Collection1"), Order(1)]
    public class UnitTest2
    {
        private readonly SharedMemory _memory;

        public UnitTest2(SharedMemory sharedMemory)
        {
            _memory = sharedMemory;
        }

        [Fact, Order(2)]
        public void Test2()
        {
            Assert.Equal(99, _memory.Number);
            _memory.Number = 6;
            Thread.Sleep(5000);
        }
    }

    [Collection("Collection1"), Order(400)]
    public class UnitTest4 : BaseUnitTest
    {
        public UnitTest4(SharedMemory _memory) : base(_memory)
        {

        }

        [Fact, Order(2)]
        public void Test2()
        {
            Assert.Equal(82, _memory.Number);
            _memory.Number = 303;
            Thread.Sleep(5000);
        }
    }

    
    public class BaseUnitTest
    {
        protected readonly SharedMemory _memory;


        public BaseUnitTest(SharedMemory sharedMemory)
        {
            _memory = sharedMemory;
        }
    }

    [Order(300)]
    public class UnitTest5 : BaseUnitTestNew
    {
        public UnitTest5(SharedMemory _memory) : base(_memory)
        {

        }

        [Fact, Order(2)]
        public void Test2()
        {
            Assert.Equal(3, _memory.Number);
            _memory.Number = 82;
            Thread.Sleep(5000);
        }
    }

    [Collection("Collection1"), Order(600)]
    public class BaseUnitTestNew
    {
        protected readonly SharedMemory _memory;


        public BaseUnitTestNew(SharedMemory sharedMemory)
        {
            _memory = sharedMemory;
        }
    }
}