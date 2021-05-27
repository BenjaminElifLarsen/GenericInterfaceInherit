using System;

namespace GenericInterfaceInherit
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("TestRepo: " + new TestRepo().Type);
            Console.WriteLine("OtherRepo: " + new OtherRepo().Type);
            Console.WriteLine("GenericRepo Test: " + new GenericRepo<Test>().Type);
            Console.WriteLine("GenericRepo Other: " + new GenericRepo<Other>().Type);
            Console.WriteLine("GenericRepo string: " + new GenericRepo<string>().Type);
            new TestRepo().Add(new Test());
            new OtherRepo().Add(new Other());
            new GenericRepo<Test>().Add(new Test());
            new GenericRepo<Other>().Add(new Other());
            new GenericRepo<string>().Add("");


            Console.ReadKey();
            Environment.Exit(0);
        }
    }

    public class TestRepo : ITestInterface
    {
        public Test All => new Test();

        public string Type => typeof(Test).ToString();

        public void Add(Test entity)
        {
            Console.WriteLine(entity.GetType().Name + " added");
        }
    }

    public class OtherRepo : IOtherInterface
    {
        public Other All => new Other();

        public string Type => typeof(Other).ToString();

        public void Add(Other entity)
        {
            Console.WriteLine(entity.GetType().Name + " added");
        }
    }

    public class GenericRepo<T> : ISuperInterface<T>
    {
        public T All => throw new NotImplementedException();


        public string Type => typeof(T).ToString();

        public void Add(T entity)
        {
            Console.WriteLine(entity.GetType().Name + " added");
        }
    }

    public interface ISuperInterface<T>
    {
        public T All { get; }
        public void Add(T entity);

        public string Type { get; }
    }

    public interface ITestInterface : ISuperInterface<Test>
    {

    }

    public interface IOtherInterface : ISuperInterface<Other>
    {

    }

    public class Test
    {

    }

    public class Other
    {

    }
}
