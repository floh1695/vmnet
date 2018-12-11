using System;

namespace vmnet
{
    public class Operation<TState>
        : IOperation<TState>
    {
        public Func<TState, TState> Function { get; }

        public Operation(Func<TState, TState> function)
        {
            Function = function;
        }

        public TState Run(TState state) =>
            Function(state);
    }
}