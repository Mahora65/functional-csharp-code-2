using NUnit.Framework;

namespace Examples.AppendixA.Immutable
{
   class A
   {
      public int B { get; }
      public string C { get; }
      public A(int b, string c) { B = b; C = c; }
   }

   
   public class Immutable_With_PropertyName
   {
      A original = new A(123, "hello");

      [Test]
      public void ItChangesTheDesiredProperty()
      {
         var @new = original.With("B", 777);

         ClassicAssert.AreEqual(777, @new.B); // updated
         ClassicAssert.AreEqual("hello", @new.C); // same as original
      }

      [Test]
      public void ItDoesNotChangesTheOriginal()
      {
         var @new = original.With("B", 777);

         ClassicAssert.AreEqual(123, original.B);
         ClassicAssert.AreEqual("hello", original.C);
      }
   }

   
   public class Immutable_With_PropertyExpression
   {
      A original = new A(123, "hello");

      [Test]
      public void ItChangesTheDesiredProperty()
      {
         var @new = original.With(a => a.C, "hi");

         ClassicAssert.AreEqual(123, original.B);
         ClassicAssert.AreEqual("hello", original.C);

         ClassicAssert.AreEqual(123, @new.B);
         ClassicAssert.AreEqual("hi", @new.C);
      }

      [Test]
      public void YouCanChainWith()
      {
         var @new = original
            .With(a => a.B, 345)
            .With(a => a.C, "howdy");

         ClassicAssert.AreEqual(345, @new.B);
         ClassicAssert.AreEqual("howdy", @new.C);      }
   }
}
