using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace vmnet
{
    public static class IReportableProcessorExtensions
    {
        public static string Report(this IReportableProcessor @this) =>
            new List<string>
            {
                $"Processor Name: {@this.Name}",
                $"Registers: {@this.Registers.Report()}",
                $"Memories: {@this.Memories.Report()}",
                $"Instructions: {@this.Instructions.Report()}",
            }
                .StringJoin(Environment.NewLine);

        private static string Report<T>(this IEnumerable<T> @this)
            where T : HasName =>
            @this
                .Select(named => named.Name)
                .Map(Functional.StringJoin(", "));
    }
}