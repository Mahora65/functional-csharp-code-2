using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using NuGet.Frameworks;

namespace Exercises.Chapter2
{
   static class Exercises
   {
      // 1. Write a function that negates a given predicate: whenvever the given predicate
      // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
      public static Func<T, bool> Negates<T>(this Func<T, bool> predicate) => (t) => !predicate(t);

      // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
      // rather than sorting it in place).
      public static List<int> MSort(this List<int> unsort)
         => unsort switch
         {
            [] => new List<int>(),
            [var pivot, .. var rest] =>
               rest.Where(i => i <= pivot).ToList().MSort()
                  .Append(pivot)
                  .Concat(rest.Where(i => pivot < i).ToList().MSort())
                  .ToList()
         };
      // 3. Generalize your implementation to take a `List<T>`, and additionally a
      // `Comparison<T>` delegate.

      static List<T> XSort<T>(this List<T> unsorted, Comparison<T> compare)
         => unsorted switch
         {
            [] => new List<T>(),
            [var pivot, .. var rest] =>
               rest.Where(x => compare(x, pivot) <= 0).ToList().XSort(compare)
                  .Append(pivot)
                  .Concat(rest.Where(x => compare(x, pivot) > 0).ToList().XSort(compare))
                  .ToList()
         };

      // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
      // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
      // takes a `Func<IDisposable>` as first
      // parameter, instead of the `IDisposable`. (This can be used to fix warnings
      // given by some code analysis tools about instantiating an `IDisposable` and
      // not disposing it.)

      static R Using<TDisp,R>(Func<TDisp> Disposable, Func<TDisp, R> func ) where TDisp: IDisposable
      {
         using (var disp = Disposable()) return func(disp);
      }

   }
}
