﻿namespace Examples.Chapter2;

static class HOFs
{
   [Test]
   public static void Swap()
   {
      var divide = (int dividend, int divisor) => dividend / divisor;
      var divideBy = divide.SwapArgs();

      Assert.That(5, Is.EqualTo(divide(10, 2)));
      Assert.That(5, Is.EqualTo(divideBy(2,10)));
   }

   public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> func)
      => (t2, t1) => func(t1, t2);
}
